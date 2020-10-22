//=====================================================================
//
// THIS CODE AND INFORMATION IS PROVIDED TO YOU FOR YOUR REFERENTIAL
// PURPOSES ONLY, AND IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE,
// AND MAY NOT BE REDISTRIBUTED IN ANY MANNER.
//
// Copyright (C) 2003  Microsoft Corporation.  All rights reserved.
//
//=====================================================================
using System;
using System.Security;
using System.Security.Principal;
using System.Web.Security;
using System.Web;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace SqlAdmin {
	/// <summary>
	/// General Security functions.
	/// </summary>
	public class Security {

		public Security() {
			this.context = HttpContext.Current;
			this.webserver = System.Configuration.ConfigurationSettings.AppSettings["WebServer"];
		}

		#region properties
				
		private WindowsIdentity  identity;
		private HttpContext context;
		private string webserver;

		/// <summary>
		/// What type of webserver is this IIS or Cassini
		/// </summary>
		public string WebServer {
			get { return webserver.ToLower(); }
		}

		/// <summary>
		/// The current identity of the user
		/// </summary>
		public WindowsIdentity  Identity {
			get { return identity; }
			set { identity = value; }
		}

		#endregion

		#region methods
		/// <summary>
		/// Used for forms auth. currently aren't using.
		/// </summary>
		/// <param name="username">The username of the current user</param>
		/// <param name="password">The password of the current user</param>
		/// <param name="persist">Should we persist this data</param>
		/// <param name="loginType">What type of login</param>
		public void WriteCookieForFormsAuthentication(string username, string password, bool persist, SqlLoginType loginType) {
			//Create the ticket, and add the groups.
			bool isCookiePersistent = persist;
			string userData =null;
			userData = password + "," + loginType.ToString();
			FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, userData);
			
			//Encrypt the ticket.
			String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
				
			//Create a cookie, and then add the encrypted ticket to the cookie as data.
			HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
		
			if(true == isCookiePersistent)
				authCookie.Expires = authTicket.Expiration;
						
			//Add the cookie to the outgoing cookies collection.
			context.Response.Cookies.Add(authCookie);		
				
		}

		/// <summary>
		/// Starts the impersonation process. If an exception occurs it is rolled up to the caller.
		/// </summary>
		/// <param name="username">Username</param>
		/// <param name="domain">domain</param>
		/// <param name="password">password</param>
		/// <returns>Indicates whether the impersonation process was successful.</returns>
		public bool Impersonate(string username, string domain, string password) {
			try {
				if ( this.WebServer == "iis" ) 
					return false;
				return this.DoImpersonate(username, domain, password);
			} catch (Exception ex){
				throw ex;
				return false;
			}
		}		

		/// <summary>
		/// Ends impersonation 
		/// </summary>
		public void EndImpersonate() {
			this.StopImpersonate();
		}
		#endregion

		#region interop/unsafe methods

		IntPtr tokenHandle = new IntPtr(0);
		IntPtr dupeTokenHandle = new IntPtr(0);


		[DllImport("advapi32.dll", SetLastError=true)]
		public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, 
			int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

		[DllImport("kernel32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private unsafe static extern int FormatMessage(int dwFlags, ref IntPtr lpSource, 
			int dwMessageId, int dwLanguageId, ref String lpBuffer, int nSize, IntPtr *Arguments);

		[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
		public extern static bool CloseHandle(IntPtr handle);

		[DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
		public extern static bool DuplicateToken(IntPtr ExistingTokenHandle, 
			int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

		// GetErrorMessage formats and returns an error message
		// corresponding to the input errorCode.
		public unsafe static string GetErrorMessage(int errorCode) {
			int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
			int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
			int FORMAT_MESSAGE_FROM_SYSTEM  = 0x00001000;

			//int errorCode = 0x5; //ERROR_ACCESS_DENIED
			//throw new System.ComponentModel.Win32Exception(errorCode);

			int messageSize = 255;
			String lpMsgBuf = "";
			int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;

			IntPtr ptrlpSource = IntPtr.Zero;
			IntPtr prtArguments = IntPtr.Zero;
        
			int retVal = FormatMessage(dwFlags, ref ptrlpSource, errorCode, 0, ref lpMsgBuf, messageSize, &prtArguments);
			if (0 == retVal) {
				throw new Exception("Failed to format message for error code " + errorCode + ". ");
			}

			return lpMsgBuf;
		}

		WindowsImpersonationContext impersonatedUser; 

		/// <summary>
		/// Starts the impersonation process
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="domain">The domain name</param>
		/// <param name="password">The password</param>
		/// <returns></returns>
		public  bool DoImpersonate(string username, string domain,string password) {

			if ( System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower() == domain + @"\" + username )
				return true;

			const int LOGON32_PROVIDER_DEFAULT = 0;
			//This parameter causes LogonUser to create a primary token.
			const int LOGON32_LOGON_INTERACTIVE = 2;
			const int SecurityImpersonation = 2;

			tokenHandle = IntPtr.Zero;
			dupeTokenHandle = IntPtr.Zero;

			// Call LogonUser to obtain a handle to an access token.
			bool returnValue = LogonUser(username, domain, password, 
				LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
				ref tokenHandle);

			if (false == returnValue) {
				int ret = Marshal.GetLastWin32Error();
				int errorCode = 0x5; //ERROR_ACCESS_DENIED
				throw new System.ComponentModel.Win32Exception(errorCode);
			}

			bool retVal = DuplicateToken(tokenHandle, SecurityImpersonation, ref dupeTokenHandle);

			if (false == retVal) {
				CloseHandle(tokenHandle);
				return retVal;
			}

			// The token that is passed to the following constructor must 
			// be a primary token in order to use it for impersonation.
			WindowsIdentity newId = new WindowsIdentity(dupeTokenHandle);
			impersonatedUser = newId.Impersonate();

			return retVal;
		}


		/// <summary>
		/// Stops the impersonation process
		/// </summary>
		public  void StopImpersonate() {
		
			//impersonatedUser.Undo();
			// Free the tokens.
			if (tokenHandle != IntPtr.Zero)
				CloseHandle(tokenHandle);
			if (dupeTokenHandle != IntPtr.Zero) 
				CloseHandle(dupeTokenHandle);

		
		}






















//		public const int LOGON32_LOGON_INTERACTIVE = 2;
//		public const int LOGON32_PROVIDER_DEFAULT = 0;
//
//		WindowsImpersonationContext impersonationContext; 
//
//		[DllImport("advapi32.dll", CharSet=CharSet.Auto)]
//		private static extern int LogonUser(String lpszUserName, 
//			String lpszDomain,
//			String lpszPassword,
//			int dwLogonType, 
//			int dwLogonProvider,
//			ref IntPtr phToken);
//		[DllImport("advapi32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto,
//			 SetLastError=true)]
//		private extern static int DuplicateToken(IntPtr hToken, 
//			int impersonationLevel,  
//			ref IntPtr hNewToken);
//
//
//		private bool StartImpersonation(String userName, String domain, String password) {
//			WindowsIdentity tempWindowsIdentity;
//			IntPtr token = IntPtr.Zero;
//			IntPtr tokenDuplicate = IntPtr.Zero;
//
//			if(LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE, 
//				LOGON32_PROVIDER_DEFAULT, ref token) != 0) {
//				if(DuplicateToken(token, 2, ref tokenDuplicate) != 0) {
//					tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
//					impersonationContext = tempWindowsIdentity.Impersonate();
//					if (impersonationContext != null)
//						return true;
//					else
//						return false; 
//				}
//				else
//					return false;
//			} 
//			else
//				return false;
//		}
//		private void EndImpersonation() {
//			// Throws exception
//			try {
//				impersonationContext.Undo();
//			} catch {}
//		} 

		#endregion

	}
}
