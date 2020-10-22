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
using System.Runtime.InteropServices;

namespace SqlAdmin {

	/// <summary>
	/// Primary Interop class. COM methods not used are primarily prefixed with Bogus. 
	/// For information on how to extend this class please post to the support forum. There are some
	/// interfaces and classes in this file that are not used implemented throughout the application.
	/// </summary>
    internal sealed class NativeMethods {

        private NativeMethods() {}

				public class SQLDMO_PRIVILEGE_TYPE {
					public const int SQLDMOPriv_Unknown = 0;
					public const int SQLDMOPriv_Select = 1;
					public const int SQLDMOPriv_Insert = 2;
					public const int SQLDMOPriv_Update = 4;
					public const int SQLDMOPriv_Delete = 8;
					public const int SQLDMOPriv_Execute = 16;
					public const int SQLDMOPriv_References = 32;
					public const int SQLDMOPriv_AllObjectPrivs = 63;
					public const int SQLDMOPriv_CreateTable = 128;
					public const int SQLDMOPriv_CreateDatabase = 256;
					public const int SQLDMOPriv_CreateView = 512;
					public const int SQLDMOPriv_CreateProcedure = 1024;
					public const int SQLDMOPriv_DumpDatabase = 2048;
					public const int SQLDMOPriv_CreateDefault = 4096;
					public const int SQLDMOPriv_DumpTransaction = 8192;
					public const int SQLDMOPriv_CreateRule = 16384;
					public const int SQLDMOPriv_DumpTable = 32768;
					public const int SQLDMOPriv_CreateFunction = 0x00010000;
					public const int SQLDMOPriv_AllDatabasePrivs = 0x0001ff80;		
				}

				public class SQLDMO_NTACCESS_TYPE {
					public const int SQLDMONTAccess_Unknown = 0;
					public const int SQLDMONTAccess_Grant = 1;
					public const int SQLDMONTAccess_Deny = 2;
					public const int SQLDMONTAccess_NonNTLogin = 99;
				}

				public class SQLDMO_LOGIN_TYPE {

					public const int SQLDMOLogin_NTUser = 0;			
					public const int SQLDMOLogin_NTGroup = 1;
					public const int SQLDMOLogin_Standard = 2;
				
				}

        public class SQLDMO_SCRIPT_TYPE {
            public const int SQLDMOScript_None = 0;
            public const int SQLDMOScript_Default = 4;
            public const int SQLDMOScript_Drops = 1;
            public const int SQLDMOScript_ObjectPermissions = 2;
            public const int SQLDMOScript_PrimaryObject = 4;
            public const int SQLDMOScript_ClusteredIndexes = 8;
            public const int SQLDMOScript_Triggers = 16;
            public const int SQLDMOScript_DatabasePermissions = 32;
            public const int SQLDMOScript_Permissions = 34;
            public const int SQLDMOScript_ToFileOnly = 64;
            public const int SQLDMOScript_Bindings = 128;
            public const int SQLDMOScript_AppendToFile = 256;
            public const int SQLDMOScript_NoDRI = 512;
            public const int SQLDMOScript_UDDTsToBaseType = 1024;
            public const int SQLDMOScript_IncludeIfNotExists = 4096;
            public const int SQLDMOScript_NonClusteredIndexes = 8192;
            public const int SQLDMOScript_Indexes = 0x00012008;
            public const int SQLDMOScript_Aliases = 16384;
            public const int SQLDMOScript_NoCommandTerm = 32768;
            public const int SQLDMOScript_DRIIndexes = 0x00010000;
            public const int SQLDMOScript_IncludeHeaders = 0x00020000;
            public const int SQLDMOScript_OwnerQualify = 0x00040000;
            public const int SQLDMOScript_TimestampToBinary = 0x00080000;
            public const int SQLDMOScript_SortedData = 0x00100000;
            public const int SQLDMOScript_SortedDataReorg = 0x00200000;
            public const int SQLDMOScript_TransferDefault = 0x000670ff;
            public const int SQLDMOScript_DRI_NonClustered = 0x00400000;
            public const int SQLDMOScript_DRI_Clustered = 0x00800000;
            public const int SQLDMOScript_DRI_Checks = 0x01000000;
            public const int SQLDMOScript_DRI_Defaults = 0x02000000;
            public const int SQLDMOScript_DRI_UniqueKeys = 0x04000000;
            public const int SQLDMOScript_DRI_ForeignKeys = 0x08000000;
            public const int SQLDMOScript_DRI_PrimaryKey = 0x10000000;
            public const int SQLDMOScript_DRI_AllKeys = 0x1c000000;
            public const int SQLDMOScript_DRI_AllConstraints = 0x1f000000;
            public const int SQLDMOScript_DRI_All = 0x1fc00000;
            public const int SQLDMOScript_DRIWithNoCheck = 0x20000000;
            public const int SQLDMOScript_NoIdentity = 0x40000000;
            // Too big for int, need uint, but we don't use it anyway
            //public const int SQLDMOScript_UseQuotedIdentifiers = 0x80000000;
        }

        public class SQLDMO_DBSTATUS_TYPE {
            public const int SQLDMODBStat_Normal = 0;
            public const int SQLDMODBStat_Loading = 32;
            public const int SQLDMODBStat_Recovering = 192;
            public const int SQLDMODBStat_Suspect = 256;
            public const int SQLDMODBStat_Offline = 512;
            public const int SQLDMODBStat_Inaccessible = 992;
            public const int SQLDMODBStat_EmergencyMode = 32768;
            public const int SQLDMODBStat_Standby = 1024;
            public const int SQLDMODBStat_All = 34784;
        }

        public class SQLDMO_GROWTH_TYPE {
            public const int SQLDMOGrowth_MB = 0;
            public const int SQLDMOGrowth_Percent = 1;
            public const int SQLDMOGrowth_Invalid = 99;
        }

        public class SQLDMO_KEY_TYPE {
            public const int SQLDMOKey_Unknown = 0;
            public const int SQLDMOKey_Primary = 1;
            public const int SQLDMOKey_Unique = 2;
            public const int SQLDMOKey_Foreign = 3;
        }


        [ComVisible(true), ComImport(), Guid("10020200-E260-11CF-AE68-00AA004A34D5")]
        public class SqlServer {
        }

        [ComVisible(true), ComImport(), Guid("10020206-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface ISqlServer {
            int Bogus_Application(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_Parent(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_UserData1(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_UserData2(); // HRESULT UserData([in] long pRetVal);
            int Bogus_TypeOf(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_Properties(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

            IDatabases GetDatabases(); //HRESULT Databases([out, retval] Databases** ppVBObjRet);

            int Bogus_Password1(); // HRESULT Password([out, retval] BSTR* pRetVal);
            int Bogus_Password2(); // HRESULT Password([in] BSTR pRetVal);
            int Bogus_Name1(); // HRESULT Name([out, retval] BSTR* pRetVal);
            int Bogus_Name2(); // HRESULT Name([in] BSTR pRetVal);
            int Bogus_Login1(); // HRESULT Login([out, retval] BSTR* pRetVal);
            int Bogus_Login2(); // HRESULT Login([in] BSTR pRetVal);
            int Bogus_VersionString(); // HRESULT VersionString([out, retval] BSTR* pRetVal);
            int Bogus_BackupDevices(); // HRESULT BackupDevices([out, retval] BackupDevices** ppVBObjRet);
            int Bogus_VersionMajor(); // HRESULT VersionMajor([out, retval] long* pRetVal);
            int Bogus_VersionMinor(); // HRESULT VersionMinor([out, retval] long* pRetVal);
            int Bogus_CommandTerminator1(); // HRESULT CommandTerminator([out, retval] BSTR* pRetVal);
            int Bogus_CommandTerminator2(); // HRESULT CommandTerminator([in] BSTR pRetVal);
            int Bogus_TrueName(); // HRESULT TrueName([out, retval] BSTR* pRetVal);
            int Bogus_ConnectionID(); // HRESULT ConnectionID([out, retval] long* pRetVal);
            int Bogus_TrueLogin(); // HRESULT TrueLogin([out, retval] BSTR* pRetVal);
            int Bogus_IntegratedSecurity(); // HRESULT IntegratedSecurity([out, retval] IntegratedSecurity** ppVBObjRet);
			ILanguages GetLanguages(); // HRESULT Languages([out, retval] Languages** ppVBObjRet);
			int Bogus_RemoteServers(); // HRESULT RemoteServers([out, retval] RemoteServers** ppVBObjRet);
			ILogins GetLogins();// HRESULT Logins([out, retval] Logins** ppVBObjRet);
			int Bogus_UserProfile(); // HRESULT UserProfile([out, retval] SQLDMO_SRVUSERPROFILE_TYPE* pRetVal);
            int Bogus_MaxNumericPrecision(); // HRESULT MaxNumericPrecision([out, retval] long* pRetVal);
            int Bogus_NextDeviceNumber(); // HRESULT NextDeviceNumber([out, retval] long* pRetVal);
            int Bogus_QueryTimeout1(); // HRESULT QueryTimeout([out, retval] long* pRetVal);
            int Bogus_QueryTimeout2(); // HRESULT QueryTimeout([in] long pRetVal);
            int Bogus_LoginTimeout1(); // HRESULT LoginTimeout([out, retval] long* pRetVal);
            int Bogus_LoginTimeout2(); // HRESULT LoginTimeout([in] long pRetVal);
            int Bogus_NetPacketSize1(); // HRESULT NetPacketSize([out, retval] long* pRetVal);
            int Bogus_NetPacketSize2(); // HRESULT NetPacketSize([in] long pRetVal);
            int Bogus_HostName1(); // HRESULT HostName([out, retval] BSTR* pRetVal);
            int Bogus_HostName2(); // HRESULT HostName([in] BSTR pRetVal);
            int Bogus_ApplicationName1(); // HRESULT ApplicationName([out, retval] BSTR* pRetVal);
            int Bogus_ApplicationName2(); // HRESULT ApplicationName([in] BSTR pRetVal);
            int Bogus_LoginSecure1(); // HRESULT LoginSecure([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_LoginSecure2(bool pRetVal); // HRESULT LoginSecure([in] VARIANT_BOOL pRetVal);
            int Bogus_ProcessID(); // HRESULT ProcessID([out, retval] long* pRetVal);
            int Bogus_Status(); // HRESULT Status([out, retval] SQLDMO_SVCSTATUS_TYPE* pRetVal);
            int Bogus_Registry(); // HRESULT Registry([out, retval] Registry** ppVBObjRet);
            int Bogus_Configuration(); // HRESULT Configuration([out, retval] Configuration** ppVBObjRet);
            int Bogus_JobServer(); // HRESULT JobServer([out, retval] JobServer** ppVBObjRet);
            int Bogus_ProcessOutputBuffer1(); // HRESULT ProcessInputBuffer([in] long ProcessID, [out, retval] BSTR* pRetVal);
            int Bogus_ProcessOutputBuffer2(); // HRESULT ProcessOutputBuffer([in] long ProcessID, [out, retval] BSTR* pRetVal);
            int Bogus_Language1(); // HRESULT Language([out, retval] BSTR* pRetVal);
            int Bogus_Language2(); // HRESULT Language([in] BSTR pRetVal);
            int Bogus_AutoReConnect1(); // HRESULT AutoReConnect([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_AutoReConnect2(); // HRESULT AutoReConnect([in] VARIANT_BOOL pRetVal);
            int Bogus_StatusInfoRefetchInterval1(); // HRESULT StatusInfoRefetchInterval([in] SQLDMO_STATUSINFO_TYPE StatusInfoType, [out, retval] long* pRetVal);
            int Bogus_StatusInfoRefetchInterval2(); // HRESULT StatusInfoRefetchInterval([in] SQLDMO_STATUSINFO_TYPE StatusInfoType, [in] long pRetVal);
            int Bogus_SaLogin(); // HRESULT SaLogin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_AnsiNulls1(); // HRESULT AnsiNulls([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_AnsiNull2(); // HRESULT AnsiNulls([in] VARIANT_BOOL pRetVal);

            //[PreserveSig]
            int Connect([In, MarshalAs(UnmanagedType.Struct)] object ServerName, [In, MarshalAs(UnmanagedType.Struct)] object Login, [In, MarshalAs(UnmanagedType.Struct)] object Password); //HRESULT Connect([in, optional] VARIANT ServerName, [in, optional] VARIANT Login, [in, optional] VARIANT Password);

            int Bogus_Close(); // HRESULT Close();

            [PreserveSig]
            int DisConnect(); //HRESULT DisConnect();

            int Bogus_KillProcess(); // HRESULT KillProcess([in] long lProcessID);
            int Bogus_ExecuteImmediate(); // HRESULT ExecuteImmediate([in] BSTR Command, [in, optional, defaultvalue(0)] SQLDMO_EXEC_TYPE ExecType, [in, optional] VARIANT Length);
            int Bogus_ReConnect(); // HRESULT ReConnect();
            int Bogus_Shutdown(); // HRESULT Shutdown([in, optional] VARIANT Wait);
            int Bogus_Start(); // HRESULT Start([in] VARIANT_BOOL StartMode, [in, optional] VARIANT Server, [in, optional] VARIANT Login, [in, optional] VARIANT Password);
            int Bogus_UnloadODSDLL(); // HRESULT UnloadODSDLL([in] BSTR DLLName);
            int Bogus_KillDatabase(); // HRESULT KillDatabase([in] BSTR DatabaseName);
            int Bogus_ExecuteWithResults(); // HRESULT ([in] BSTR Command, [in, optional] VARIANT Length, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_ListStartupProcedures(); // HRESULT ListStartupProcedures([out, retval] SQLObjectList** ppVBObjRet);
            int Bogus_BeginTransaction(); // HRESULT BeginTransaction([in, optional] VARIANT TransactionName);
            int Bogus_CommitTransaction(); // HRESULT CommitTransaction([in, optional] VARIANT TransactionName);
            int Bogus_SaveTransaction(); // HRESULT SaveTransaction([in] BSTR SavepointName);
            int Bogus_RollbackTransaction(); // HRESULT RollbackTransaction([in, optional] VARIANT TransactionOrSavepointName);
            int Bogus_CommandShellImmediate(); // HRESULT CommandShellImmediate([in] BSTR Command);
            int Bogus_ReadErrorLog(); // HRESULT ReadErrorLog([in, optional] VARIANT LogNumber, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumErrorLogs(); // HRESULT EnumErrorLogs([out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumAvailableMedia(); // HRESULT EnumAvailableMedia([in, optional, defaultvalue(15)] SQLDMO_MEDIA_TYPE MediaType, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumDirectories(); // HRESULT EnumDirectories([in] BSTR PathName, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumServerAttributes(); // HRESULT EnumServerAttributes([out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumVersionInfo(); // HRESULT EnumVersionInfo([in, optional] VARIANT Prefixes, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumLocks(); // HRESULT EnumLocks([in, optional] VARIANT WhoByID, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_CommandShellWithResults(); // HRESULT CommandShellWithResults([in] BSTR Command, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_ReadBackupHeader(); // HRESULT ReadBackupHeader([in] Restore* LoadSpec, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumProcesses(); // HRESULT EnumProcesses([in, optional] VARIANT WhoByNameOrID, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_Pause(); // HRESULT Pause();
            int Bogus_Continue(); // HRESULT Continue();
            int Bogus_VerifyConnection(); // HRESULT VerifyConnection([in, optional] VARIANT ReconnectIfDead, [out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_IsOS(); // HRESULT IsOS([in] SQLDMO_OS_TYPE lType, [out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_AddStartParameter(); // HRESULT AddStartParameter([in] BSTR NewParam);
            int Bogus_NetName(); // HRESULT NetName([out, retval] BSTR* pRetVal);
            int Bogus_ExecuteWithResultsAndMessages(); // HRESULT ExecuteWithResultsAndMessages([in] BSTR Command, [in, optional] VARIANT Length, [out] BSTR* Messages, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumLoginMappings(); // HRESULT EnumLoginMappings([out, retval] QueryResults** ppVBObjRet);
            int Bogus_Replication(); // HRESULT Replication([out, retval] Replication** pRetVal);
            int Bogus_EnableBcp1(); // HRESULT EnableBcp([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_EnableBcp2(); // HRESULT EnableBcp([in] VARIANT_BOOL pRetVal);
            int Bogus_BlockingTimeout1(); // HRESULT BlockingTimeout([out, retval] long* pRetVal);
            int Bogus_BlockingTimeout2(); // HRESULT BlockingTimeout([in] long pRetVal);
            IServerRoles GetServerRoles();
						//int Bogus_ServerRoles(); // HRESULT ServerRoles([out, retval] ServerRoles** ppVBObjRet);
            int Bogus_Isdbcreator(); // HRESULT Isdbcreator([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdiskadmin(); // HRESULT Isdiskadmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isprocessadmin(); // HRESULT Isprocessadmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Issecurityadmin(); // HRESULT Issecurityadmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isserveradmin(); // HRESULT Isserveradmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Issetupadmin(); // HRESULT Issetupadmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Issysadmin(); // HRESULT Issysadmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_EnumNTDomainGroups(); // HRESULT EnumNTDomainGroups([in, optional] VARIANT Domain, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumAccountInfo(); // HRESULT EnumAccountInfo([in, optional] VARIANT Account, [in, optional] VARIANT ListAll, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_ListMembers(); // HRESULT ListMembers([in] SQLDMO_ROLE_TYPE Type, [out, retval] NameList** ppVBObjRet);
            int Bogus_IsLogin(); // HRESULT IsLogin([in] BSTR LoginName, [out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Abort(); // HRESULT Abort();
            int Bogus_DetachDB(); // HRESULT DetachDB([in] BSTR DBName, [in, optional] VARIANT_BOOL bCheck, [out, retval] BSTR* pRetVal);
            int Bogus_AttachDB(); // HRESULT AttachDB([in] BSTR DBName, [in] BSTR DataFiles, [out, retval] BSTR* pRetVal);
            int Bogus_QuotedIdentifier1(); // HRESULT QuotedIdentifier([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_QuotedIdentifier2(); // HRESULT QuotedIdentifier([in] VARIANT_BOOL pRetVal);
            int Bogus_LinkedServers(); // HRESULT LinkedServers([out, retval] LinkedServers** ppVBObjRet);
            int Bogus_CodePageOverride(); // HRESULT CodePageOverride([in] long rhs);
            int Bogus_FullTextService(); // HRESULT FullTextService([out, retval] FullTextService** ppVBObjRet);
            int Bogus_ODBCPrefix1(); // HRESULT ODBCPrefix([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_ODBCPrefix2(); // HRESULT ODBCPrefix([in] VARIANT_BOOL pRetVal);
            int Bogus_Stop(); // HRESULT Stop();
            int Bogus_PingSQLServerVersion(); // HRESULT PingSQLServerVersion([in, optional] VARIANT ServerName, [in, optional] VARIANT Login, [in, optional] VARIANT Password, [out, retval] SQLDMO_SQL_VER* pRetVal);
            int Bogus_IsPackage(); // HRESULT IsPackage([out, retval] SQLDMO_PACKAGE_TYPE* pRetVal);
            int Bogus_RegionalSetting1(); // HRESULT RegionalSetting([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_RegionalSetting2(); // HRESULT RegionalSetting([in] VARIANT_BOOL pRetVal);
            int Bogus_CodePage(); // HRESULT CodePage([out, retval] long* pRetVal);
            int Bogus_AttachDBWithSingleFile(); // HRESULT AttachDBWithSingleFile([in] BSTR DBName, [in] BSTR DataFile, [out, retval] BSTR* pRetVal);
            int Bogus_IsNTGroupMember(); // HRESULT IsNTGroupMember([in] BSTR NTGroup, [in] BSTR NTUser, [out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_ServerTime(); // HRESULT ServerTime([out, retval] BSTR* pRetVal);
            int Bogus_TranslateChar1(); // HRESULT TranslateChar([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_TranslateChar2(); // HRESULT TranslateChar([in] VARIANT_BOOL pRetVal);
        }

        [ComVisible(true), ComImport(), Guid("10020303-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IDatabases {
            int Bogus_Application(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_Parent(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_UserData1(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_UserData2(); // HRESULT UserData([in] long pRetVal);
            int Bogus_TypeOf(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

            IDatabase Item(object Index, object Owner); // HRESULT Item([in] VARIANT Index, [in, optional] VARIANT Owner, [out, retval] Database** ppVBObjRet);

            int Bogus_NewEnum(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);

            int GetCount(); // HRESULT Count([out, retval] long* pRetVal);

            int Bogus_ItemByID(); // HRESULT ItemByID([in] long ID, [out, retval] Database** ppVBObjRet);

            int Add(IDatabase Object); // HRESULT Add([in] Database* Object);

            int Bogus_Remove(); // HRESULT Remove([in] VARIANT Index, [in, optional] VARIANT Owner);
            int Refresh(object ReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10020300-E260-11CF-AE68-00AA004A34D5")]
        public class Database {
        }

        [ComVisible(true), ComImport(), Guid("10020306-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IDatabase {
            int Bogus_Application(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_Parent(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_UserData1(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_UserData2(); // HRESULT UserData([in] long pRetVal);
            int Bogus_TypeOf(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_Properties(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

            string GetName(); // HRESULT Name([out, retval] BSTR* pRetVal);
            int SetName(string pRetVal); // HRESULT Name([in] BSTR pRetVal);

            ITables GetTables(); // HRESULT Tables([out, retval] Tables** ppVBObjRet);

            int Bogus_SystemObject(); // HRESULT SystemObject([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_ID(); // HRESULT ID([out, retval] long* pRetVal);
            int Bogus_UserProfile(); // HRESULT UserProfile([out, retval] SQLDMO_DBUSERPROFILE_TYPE* pRetVal);
            int Bogus_CreateForAttach1(); // HRESULT CreateForAttach([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_CreateForAttach2(); // HRESULT CreateForAttach([in] VARIANT_BOOL pRetVal);

            string GetOwner(); // HRESULT Owner([out, retval] BSTR* pRetVal);

            int Bogus_Version(); // HRESULT Version([out, retval] long* pRetVal);

            string GetCreateDate(); // HRESULT CreateDate([out, retval] BSTR* pRetVal);

            int Bogus_DataSpaceUsage(); // HRESULT DataSpaceUsage([out, retval] single* pRetVal);
            int Bogus_GetUserName(); // HRESULT UserName([out, retval] BSTR* pRetVal);
            int Bogus_UserName(); // HRESULT UserName([in] BSTR pRetVal);

            int GetStatus(); // HRESULT Status([out, retval] SQLDMO_DBSTATUS_TYPE* pRetVal);

            int GetSize(); // HRESULT Size([out, retval] long* pRetVal);

            int GetSpaceAvailable(); // HRESULT SpaceAvailable([out, retval] long* pRetVal);

            int Bogus_IndexSpaceUsage(); // HRESULT IndexSpaceUsage([out, retval] single* pRetVal);
            int Bogus_SpaceAvailableInMB(); // HRESULT SpaceAvailableInMB([out, retval] single* pRetVal);
            int Bogus_Views(); // HRESULT Views([out, retval] Views** ppVBObjRet);

            IStoredProcedures GetStoredProcedures(); // HRESULT StoredProcedures([out, retval] StoredProcedures** ppVBObjRet);

            int Bogus_Defaults(); // HRESULT Defaults([out, retval] Defaults** ppVBObjRet);
            int Bogus_Rules(); // HRESULT Rules([out, retval] Rules** ppVBObjRet);
            int Bogus_UserDefinedDatatypes(); // HRESULT UserDefinedDatatypes([out, retval] UserDefinedDatatypes** ppVBObjRet);

            IUsers GetUsers(); // HRESULT Users([out, retval] Users** ppVBObjRet);

            int Bogus_Groups(); // HRESULT Groups([out, retval] Groups** ppVBObjRet);
            int Bogus_SystemDatatypes(); // HRESULT SystemDatatypes([out, retval] SystemDatatypes** ppVBObjRet);

            ITransactionLog GetTransactionLog(); // HRESULT TransactionLog([out, retval] TransactionLog** ppVBObjRet);

            int Bogus_DBOption(); // HRESULT DBOption([out, retval] DBOption** ppVBObjRet);
            int Bogus_DboLogin(); // HRESULT DboLogin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Grant(); // HRESULT Grant([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR GranteeNames);
            int Bogus_Revoke(); // HRESULT Revoke([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR RevokeeNames);
            int Bogus_ExecuteImmediate(); // HRESULT ExecuteImmediate([in] BSTR Command, [in, optional, defaultvalue(0)] SQLDMO_EXEC_TYPE ExecType, [in, optional] VARIANT Length);
            int Bogus_GetObjectByName(); // HRESULT GetObjectByName([in] BSTR ObjectName, [in, optional, defaultvalue(4607)] SQLDMO_OBJECT_TYPE ObjectType, [in, optional] VARIANT Owner, [out, retval] DBObject** ppVBObjRet);
            int Bogus_Checkpoint(); // HRESULT Checkpoint();
            int Bogus_CheckTables(); // HRESULT CheckTables([in, optional, defaultvalue(0)] SQLDMO_DBCC_REPAIR_TYPE RepairType, [out, retval] BSTR* pRetVal);
            int Bogus_CheckAllocations(); // HRESULT CheckAllocations([in, optional, defaultvalue(0)] SQLDMO_DBCC_REPAIR_TYPE RepairType, [out, retval] BSTR* pRetVal);
            int Bogus_CheckCatalog(); // HRESULT CheckCatalog([out, retval] BSTR* pRetVal);
            int Bogus_GetMemoryUsage(); // HRESULT GetMemoryUsage([out, retval] BSTR* pRetVal);
            int Bogus_ExecuteWithResults(); // HRESULT ExecuteWithResults([in] BSTR Command, [in, optional] VARIANT Length, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_ListObjectPermissions(); // HRESULT ListObjectPermissions([in, optional, defaultvalue(63)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes, [out, retval] SQLObjectList** ppVBObjRet);
            int Bogus_EnumLocks(); // HRESULT EnumLocks([in, optional] VARIANT Who, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_ListObjects(); // HRESULT ListObjects([in, optional, defaultvalue(4607)] SQLDMO_OBJECT_TYPE ObjectTypes, [in, optional, defaultvalue(0)] SQLDMO_OBJSORT_TYPE SortBy, [out, retval] SQLObjectList** ppVBObjRet);
            int Bogus_EnumDependencies(); // HRESULT EnumDependencies([in, optional, defaultvalue(0)] SQLDMO_DEPENDENCY_TYPE DependencyType, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_SetOwner(); // HRESULT SetOwner([in] BSTR LoginName, [in, optional] VARIANT TransferAliases, [in, optional] VARIANT OverrideIfAlreadyUser);
            int Bogus_ListDatabasePermissions(); // HRESULT ListDatabasePermissions([in, optional, defaultvalue(130944)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes, [out, retval] SQLObjectList** ppVBObjRet);

            int Remove(); // HRESULT Remove();

            int Bogus_RecalcSpaceUsage(); // HRESULT RecalcSpaceUsage();
            int Bogus_EnumCandidateKeys(); // HRESULT EnumCandidateKeys([out, retval] QueryResults** ppVBObjRet);
            int Bogus_IsValidKeyDatatype(); // HRESULT IsValidKeyDatatype([in] BSTR KeyColType, [in, optional] VARIANT ReferencingColType, [out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_GetDatatypeByName(); // HRESULT GetDatatypeByName([in] BSTR TypeName, [out, retval] _IVSQLDMOStdObject** ppVBObjRet);
            int Bogus_Transfer(); // HRESULT Transfer([in] Transfer* TransferSpec);
            int Bogus_ScriptTransfer(); // HRESULT ScriptTransfer([in] Transfer* TransferSpec, [in, optional, defaultvalue(1)] SQLDMO_XFRSCRIPTMODE_TYPE ScriptFileMode, [in, optional] VARIANT ScriptFilePath, [out, retval] BSTR* pRetVal);
            int Bogus_CheckIdentityValues(); // HRESULT CheckIdentityValues();
            int Bogus_ExecuteWithResultsAndMessages(); // HRESULT ExecuteWithResultsAndMessages([in] BSTR Command, [in, optional] VARIANT Length, [out] BSTR* Messages, [out, retval] QueryResults** ppVBObjRet);

            string Script(int ScriptType, object ScriptFilePath, int Script2Type); // HRESULT Script([in, optional, defaultvalue(4)] SQLDMO_SCRIPT_TYPE ScriptType, [in, optional] VARIANT ScriptFilePath, [in, optional, defaultvalue(0)] SQLDMO_SCRIPT2_TYPE Script2Type, [out, retval] BSTR* pRetVal);

            int Bogus_CheckTablesDataOnly(); // HRESULT CheckTablesDataOnly([out, retval] BSTR* pRetVal);
            int Bogus_CheckAllocationsDataOnly(); // HRESULT CheckAllocationsDataOnly([out, retval] BSTR* pRetVal);
            int Bogus_UpdateIndexStatistics(); // HRESULT UpdateIndexStatistics();
            int Bogus_EnumLoginMappings(); // HRESULT EnumLoginMappings([out, retval] QueryResults** ppVBObjRet);
            int Bogus_PrimaryFilePath(); // HRESULT PrimaryFilePath([out, retval] BSTR* pRetVal);

            IFileGroups GetFileGroups(); // HRESULT FileGroups([out, retval] FileGroups** ppVBObjRet);

            IDatabaseRoles GetDatabaseRoles(); // HRESULT DatabaseRoles([out, retval] DatabaseRoles** ppVBObjRet);

            int GetPermissions(); // HRESULT Permissions([out, retval] SQLDMO_PRIVILEGE_TYPE* Permissions);

            int Bogus_Isdb_accessadmin(); // HRESULT Isdb_accessadmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_datareader(); // HRESULT Isdb_datareader([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_ddladmin(); // HRESULT Isdb_ddladmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_denydatareader(); // HRESULT Isdb_denydatareader([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_denydatawriter(); // HRESULT Isdb_denydatawriter([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_backupoperator(); // HRESULT Isdb_backupoperator([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_owner(); // HRESULT Isdb_owner([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_securityadmin(); // HRESULT Isdb_securityadmin([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_Isdb_datawriter(); // HRESULT Isdb_datawriter([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_EnumFiles(); // HRESULT EnumFiles([out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumFileGroups(); // HRESULT EnumFileGroups([out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumUsers(); // HRESULT EnumUsers([in, optional] VARIANT Who, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnumNTGroups(); // HRESULT EnumNTGroups([in, optional] VARIANT Who, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_Deny(); // HRESULT Deny([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR DenyeeNames);

            bool IsUser(string UserName); // HRESULT IsUser([in] BSTR UserName, [out, retval] VARIANT_BOOL* pRetVal);

            int Bogus_GenerateSQL(); // HRESULT GenerateSQL([out, retval] BSTR* pRetVal);
            int Bogus_Shrink(); // HRESULT Shrink([in] long FreeSpaceInPercent, [in] SQLDMO_SHRINK_TYPE Truncate);
            int Bogus_CheckTextAllocsFast(); // HRESULT CheckTextAllocsFast([out, retval] BSTR* pRetVal);
            int Bogus_CheckTextAllocsFull(); // HRESULT CheckTextAllocsFull([out, retval] BSTR* pRetVal);
            int Bogus_EnumMatchingSPs(); // HRESULT EnumMatchingSPs([in] BSTR Text, [in, optional] VARIANT IncludeSystemSP, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_EnableFullTextCatalogs(); // HRESULT EnableFullTextCatalogs();
            int Bogus_RemoveFullTextCatalogs(); // HRESULT RemoveFullTextCatalogs();
            int Bogus_FullTextIndexScript(); // HRESULT FullTextIndexScript([out, retval] BSTR* pRetVal);
            int Bogus_IsFullTextEnabled(); // HRESULT IsFullTextEnabled([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_FullTextCatalogs(); // HRESULT FullTextCatalogs([out, retval] FullTextCatalogs** ppVBObjRet);
            int Bogus_DisableFullTextCatalogs(); // HRESULT DisableFullTextCatalogs();
            int Bogus_CompatibilityLevel1(); // HRESULT CompatibilityLevel([out, retval] SQLDMO_COMP_LEVEL_TYPE* pRetVal);
            int Bogus_CompatibilityLevel2(); // HRESULT CompatibilityLevel([in] SQLDMO_COMP_LEVEL_TYPE pRetVal);
            int Bogus_UseServerName1(); // HRESULT UseServerName([out, retval] BSTR* pRetVal);
            int Bogus_UseServerName2(); // HRESULT UseServerName([in] BSTR pRetVal);
        }

        [ComVisible(true), ComImport(), Guid("10020D03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IStoredProcedures {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

            IStoredProcedure Item(object Index, object Owner);

            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);

            int GetCount();

            int Bogus_7(); // HRESULT ItemByID([in] long ID, [out, retval] StoredProcedure** ppVBObjRet);

            int Add(IStoredProcedure Object);

            int Bogus_8(); // HRESULT Remove([in] VARIANT Index, [in, optional] VARIANT Owner);
            int Refresh(object ReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10020D00-E260-11CF-AE68-00AA004A34D5")]
        public class StoredProcedure {
        }

        [ComVisible(true), ComImport(), Guid("10020D06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IStoredProcedure {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

            string GetName();
            int SetName(string pRetVal);
            bool GetSystemObject(); // HRESULT SystemObject([out, retval] VARIANT_BOOL* pRetVal);

            int Bogus_7(); // HRESULT Type([out, retval] SQLDMO_PROCEDURE_TYPE* pRetVal);
            int Bogus_8(); // HRESULT Type([in] SQLDMO_PROCEDURE_TYPE pRetVal);
            int Bogus_9(); // HRESULT Startup([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_10(); // HRESULT Startup([in] VARIANT_BOOL pRetVal);

            string GetOwner();
            int SetOwner(string pRetVal);
            string GetCreateDate();

            int Bogus_11(); // HRESULT ID([out, retval] long* pRetVal);

            string GetText();
            int SetText(string pRetVal);

            int Bogus_12(); // HRESULT Grant([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR GranteeNames, [in, optional] VARIANT GrantGrant, [in, optional] VARIANT AsRole);
            int Bogus_13(); // HRESULT Revoke([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR RevokeeNames, [in, optional] VARIANT GrantGrant, [in, optional] VARIANT RevokeGrantOption, [in, optional] VARIANT AsRole);
            int Bogus_14(); // HRESULT ListPermissions([in, optional, defaultvalue(16)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes, [out, retval] SQLObjectList** ppVBObjRet);
            int Bogus_15(); // HRESULT ListUserPermissions([in] BSTR UserName, [out, retval] SQLObjectList** ppVBObjRet);
            int Bogus_16(); // HRESULT EnumParameters([out, retval] QueryResults** ppVBObjRet);

            int Remove();
            string Script(int ScriptType, object ScriptFilePath, int Script2Type);

            int Bogus_17(); // HRESULT EnumDependencies([in, optional, defaultvalue(0)] SQLDMO_DEPENDENCY_TYPE DependencyType, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_18(); // HRESULT Deny([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR DenyeeNames, [in, optional] VARIANT GrantGrant);

            int Alter(string NewText);

            int Bogus_19(); // HRESULT QuotedIdentifierStatus([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_20(); // HRESULT AnsiNullsStatus([out, retval] VARIANT_BOOL* pRetVal);
        }


        [ComVisible(true), ComImport(), Guid("10022C03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IFileGroups {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

            IFileGroup Item(object ItemInd); // HRESULT Item([in] VARIANT ItemIndex, [out, retval] FileGroup** ppVBObjRet);

            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
            int Bogus_7(); // HRESULT Count([out, retval] long* pRetVal);
            int Bogus_8(); // HRESULT ItemByID([in] long ID, [out, retval] FileGroup** ppVBObjRet);
            int Bogus_9(); // HRESULT Add([in] FileGroup* Object);
            int Bogus_10(); // HRESULT Remove([in] VARIANT Index);
            int Bogus_11(); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10022C00-E260-11CF-AE68-00AA004A34D5")]
        public class FileGroup {
        }

        [ComVisible(true), ComImport(), Guid("10022C06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IFileGroup {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);
            int Bogus_7(); // HRESULT Name([out, retval] BSTR* pRetVal);
            int Bogus_8(); // HRESULT Name([in] BSTR pRetVal);

            IDBFiles GetDBFiles();

            int Bogus_9(); // HRESULT Size([out, retval] long* pRetVal);
            int Bogus_10(); // HRESULT ID([out, retval] long* pRetVal);
            int Bogus_11(); // HRESULT ReadOnly([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_12(); // HRESULT ReadOnly([in] VARIANT_BOOL pRetVal);
            int Bogus_13(); // HRESULT Remove();
            int Bogus_14(); // HRESULT EnumObjects([out, retval] QueryResults** ppVBObjRet);
            int Bogus_15(); // HRESULT EnumFiles([out, retval] QueryResults** ppVBObjRet);
            int Bogus_16(); // HRESULT CheckFilegroup([out, retval] BSTR* pRetVal);
            int Bogus_17(); // HRESULT CheckFilegroupDataOnly([out, retval] BSTR* pRetVal);
            int Bogus_18(); // HRESULT Default([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_19(); // HRESULT Default([in] VARIANT_BOOL pRetVal);
        }

        [ComVisible(true), ComImport(), Guid("10022D03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IDBFiles {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

            IDBFile Item(object ItemIndex); // HRESULT Item([in] VARIANT ItemIndex, [out, retval] DBFile** ppVBObjRet);

            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
            int Bogus_7(); // HRESULT Count([out, retval] long* pRetVal);
            int Bogus_8(); // HRESULT ItemByID([in] long ID, [out, retval] DBFile** ppVBObjRet);
            int Bogus_9(); // HRESULT Add([in] DBFile* Object);
            int Bogus_10(); // HRESULT Remove([in] VARIANT Index);
            int Bogus_11(); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10022D00-E260-11CF-AE68-00AA004A34D5")]
        public class DBFile {
        }

        [ComVisible(true), ComImport(), Guid("10022D06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IDBFile {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);
            int Bogus_7(); // HRESULT Name([out, retval] BSTR* pRetVal);
            int Bogus_8(); // HRESULT Name([in] BSTR pRetVal);
            int Bogus_9(); // HRESULT PhysicalName([out, retval] BSTR* pRetVal);
            int Bogus_10(); // HRESULT PhysicalName([in] BSTR pRetVal);
            int Bogus_11(); // HRESULT PrimaryFile([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_12(); // HRESULT PrimaryFile([in] VARIANT_BOOL pRetVal);

            int GetFileGrowth();
            int SetFileGrowth(int pRetVal);

            int GetMaximumSize();
            int SetMaximumSize(int pRetVal);

            int Bogus_13(); // HRESULT SpaceAvailableInMB([out, retval] long* pRetVal);
            int Bogus_14(); // HRESULT Size([out, retval] long* pRetVal);
            int Bogus_15(); // HRESULT Size([in] long pRetVal);
            int Bogus_16(); // HRESULT ID([out, retval] long* pRetVal);

            int GetFileGrowthType();
            int SetFileGrowthType(int pRetVal);

            int Bogus_17(); // HRESULT FileGrowthInKB([out, retval] single* pRetVal);
            int Bogus_18(); // HRESULT Remove();
            int Bogus_19(); // HRESULT Shrink([in] long NewSizeInMB, [in] SQLDMO_SHRINK_TYPE Truncate);
            int Bogus_20(); // HRESULT SizeInKB([out, retval] single* pRetVal);
        }

        [ComVisible(true), ComImport(), Guid("10022606-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface ITransactionLog {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);
            int Bogus_7(); // HRESULT CreateDate([out, retval] BSTR* pRetVal);
            int Bogus_8(); // HRESULT LastBackup([out, retval] BSTR* pRetVal);
            int Bogus_9(); // HRESULT Size([out, retval] long* pRetVal);
            int Bogus_10(); // HRESULT SpaceAvailable([out, retval] long* pRetVal);
            int Bogus_11(); // HRESULT SpaceAvailableInMB([out, retval] single* pRetVal);
            int Bogus_12(); // HRESULT SpaceAllocatedOnFiles([in] BSTR DatabaseName, [out, retval] long* pRetVal);
            int Bogus_13(); // HRESULT Truncate();

            ILogFiles GetLogFiles();
        }

        [ComVisible(true), ComImport(), Guid("10022E03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface ILogFiles {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

            ILogFile Item(object ItemIndex);

            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
            int Bogus_7(); // HRESULT Count([out, retval] long* pRetVal);
            int Bogus_8(); // HRESULT ItemByID([in] long ID, [out, retval] LogFile** ppVBObjRet);
            int Bogus_9(); // HRESULT Add([in] LogFile* Object);
            int Bogus_10(); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10022E00-E260-11CF-AE68-00AA004A34D5")]
        public class LogFile {
        }

        [ComVisible(true), ComImport(), Guid("10022E06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface ILogFile {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);
            int Bogus_7(); // HRESULT Name([out, retval] BSTR* pRetVal);
            int Bogus_8(); // HRESULT Name([in] BSTR pRetVal);
            int Bogus_9(); // HRESULT PhysicalName([out, retval] BSTR* pRetVal);
            int Bogus_10(); // HRESULT PhysicalName([in] BSTR pRetVal);
            int Bogus_11(); // HRESULT Size([out, retval] long* pRetVal);
            int Bogus_12(); // HRESULT Size([in] long pRetVal);
            int Bogus_13(); // HRESULT ID([out, retval] long* pRetVal);

            int GetFileGrowth();
            int SetFileGrowth(int pRetVal);

            int GetFileGrowthType();
            int SetFileGrowthType(int pRetVal);

            int Bogus_14(); // HRESULT FileGrowthInKB([out, retval] single* pRetVal);

            int GetMaximumSize();
            int SetMaximumSize(int pRetVal);

            int Bogus_15(); // HRESULT Shrink([in] long NewSizeInMB, [in] SQLDMO_SHRINK_TYPE Truncate);
            int Bogus_16(); // HRESULT SizeInKB([out, retval] single* pRetVal);
        }
// Extended below. DM
//        [ComVisible(true), ComImport(), Guid("10020B03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
//        public interface IUsers {
//            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
//            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
//            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
//            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
//            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
//            int Bogus_6(); // HRESULT Item([in] VARIANT Index, [out, retval] User** ppVBObjRet);
//            int Bogus_7(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
//
//            int GetCount();
//
//            int Bogus_8(); // HRESULT ItemByID([in] long ID, [out, retval] User** ppVBObjRet);
//            int Bogus_9(); // HRESULT Add([in] User* Object);
//            int Bogus_10(); // HRESULT Remove([in] VARIANT Index);
//            int Bogus_11(); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
//        }

        [ComVisible(true), ComImport(), Guid("10020403-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface ITables {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            ITable Item(object Index, object Owner);
            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
            int GetCount();
            int Bogus_7(); // HRESULT ItemByID([in] long ID, [out, retval] Table** ppVBObjRet);
            int Add(ITable Object);
            int Bogus_8(); // HRESULT Remove([in] VARIANT Index, [in, optional] VARIANT Owner);
            int Refresh(object ReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10020400-E260-11CF-AE68-00AA004A34D5")]
        public class Table {
        }

        [ComVisible(true), ComImport(), Guid("10020406-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface ITable {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

            string GetName();
            int SetName(string pRetVal);
            IColumns GetColumns(); // HRESULT Columns([out, retval] Columns** ppVBObjRet);
        
            int Bogus_7(); // HRESULT DataSpaceUsed([out, retval] long* pRetVal);
            int Bogus_8(); // HRESULT IndexSpaceUsed([out, retval] long* pRetVal);
            int Bogus_9(); // HRESULT Attributes([out, retval] SQLDMO_TABLEATT_TYPE* pRetVal);

            IKeys GetKeys(); // HRESULT GetKeys([out, retval] Keys** ppVBObjRet);
            string GetOwner();
            int SetOwner(string pRetVal);
            int Bogus_10(); // HRESULT ID([out, retval] long* pRetVal);
            string GetCreateDate();
            int Bogus_11(); // HRESULT PrimaryKey([out, retval] Key** ppVBObjRet);

            int GetIndexes(); // HRESULT Indexes([out, retval] Indexes** ppVBObjRet);

            int Bogus_13(); // HRESULT Triggers([out, retval] Triggers** ppVBObjRet);
            int Bogus_14(); // HRESULT Checks([out, retval] Checks** ppVBObjRet);
            int Bogus_15(); // HRESULT ClusteredIndex([out, retval] Index** ppVBObjRet);

            bool GetSystemObject();
            int GetRows();
            int BeginAlter();
            int DoAlter();
            int CancelAlter();

            int Bogus_19(); // HRESULT ReCompileReferences();
            int Bogus_20(); // HRESULT Grant([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR GranteeNames, [in, optional] VARIANT ColumnNames, [in, optional] VARIANT GrantGrant, [in, optional] VARIANT AsRole);
            int Bogus_21(); // HRESULT Revoke([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR RevokeeNames, [in, optional] VARIANT ColumnNames, [in, optional] VARIANT GrantGrant, [in, optional] VARIANT RevokeGrantOption, [in, optional] VARIANT AsRole);
            int Bogus_22(); // HRESULT ListPermissions([in, optional, defaultvalue(63)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes, [out, retval] SQLObjectList** ppVBObjRet);
            int Bogus_23(); // HRESULT ListUserPermissions([in] BSTR UserName, [out, retval] SQLObjectList** ppVBObjRet);
            int Bogus_24(); // HRESULT CheckTable([out, retval] BSTR* pRetVal);
            int Bogus_25(); // HRESULT TruncateData();
            int Bogus_26(); // HRESULT UpdateStatistics();

            int Remove();

            int Bogus_27(); // HRESULT EnumReferencedKeys([in, optional] VARIANT ReferencedTableName, [in, optional] VARIANT IncludeAllCandidates, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_28(); // HRESULT EnumReferencedTables([in, optional] VARIANT IncludeAllCandidates, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_29(); // HRESULT EnumReferencingKeys([in, optional] VARIANT ReferencingTableName, [in, optional] VARIANT IncludeAllCandidates, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_30(); // HRESULT EnumReferencingTables([in, optional] VARIANT IncludeAllCandidates, [out, retval] QueryResults** ppVBObjRet);
            int Bogus_31(); // HRESULT EnumDependencies([in, optional, defaultvalue(0)] SQLDMO_DEPENDENCY_TYPE DependencyType, [out, retval] QueryResults** ppVBObjRet);

            int Bogus_32(); // HRESULT InsertColumn([in] Column* NewColumn, [in] BSTR BeforeColumnName);

            int Bogus_33(); // HRESULT RecalcSpaceUsage();
            int Bogus_34(); // HRESULT EnumLastStatisticsUpdates([in, optional] VARIANT IndexName, [out, retval] QueryResults** ppVBObjRet);

            string Script(int ScriptType, object ScriptFilePath, object NewName, int Script2Type);

            int Bogus_35(); // HRESULT DoAlterWithNoCheck();
            int Bogus_36(); // HRESULT Refresh();
            int Bogus_37(); // HRESULT ImportData([in] BulkCopy* Bcp, [out, retval] long* RowsImported);
            int Bogus_38(); // HRESULT ExportData([in] BulkCopy* Bcp, [out, retval] long* RowsExported);
            int Bogus_39(); // HRESULT RebuildIndexes([in, optional, defaultvalue(0)] SQLDMO_INDEX_TYPE SortedDataType, [in, optional] VARIANT FillFactor);
            int Bogus_40(); // HRESULT CheckIdentityValue();
            int Bogus_41(); // HRESULT CheckTableDataOnly([out, retval] BSTR* pRetVal);

            int Bogus_42(); // HRESULT InAlter([out, retval] VARIANT_BOOL* pRetVal);

            int Bogus_43(); // HRESULT FileGroup([out, retval] BSTR* pRetVal);
            int Bogus_44(); // HRESULT FileGroup([in] BSTR pRetVal);
            int Bogus_45(); // HRESULT TextFileGroup([out, retval] BSTR* pRetVal);
            int Bogus_46(); // HRESULT TextFileGroup([in] BSTR pRetVal);
            int Bogus_47(); // HRESULT Deny([in] SQLDMO_PRIVILEGE_TYPE Privileges, [in] BSTR DenyeeNames, [in, optional] VARIANT ColumnNames, [in, optional] VARIANT GrantGrant);
            int Bogus_48(); // HRESULT GenerateSQL([in] Database* pDB, [out, retval] BSTR* pRetVal);
            int Bogus_49(); // HRESULT CheckTextAllocsFast([out, retval] BSTR* pRetVal);
            int Bogus_50(); // HRESULT CheckTextAllocsFull([out, retval] BSTR* pRetVal);
            int Bogus_51(); // HRESULT UpdateStatisticsWith([in] SQLDMO_STAT_AFFECT_TYPE AffectType, [in] SQLDMO_STAT_SCAN_TYPE ScanType, [in, optional] VARIANT ScanNumber, [in, optional] VARIANT ReCompute);
            int Bogus_52(); // HRESULT FullTextIndex([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_53(); // HRESULT FullTextIndex([in] VARIANT_BOOL pRetVal);
            int Bogus_54(); // HRESULT UniqueIndexForFullText([out, retval] BSTR* pRetVal);
            int Bogus_55(); // HRESULT UniqueIndexForFullText([in] BSTR pRetVal);
            int Bogus_56(); // HRESULT FullTextCatalogName([out, retval] BSTR* pRetVal);
            int Bogus_57(); // HRESULT FullTextCatalogName([in] BSTR pRetVal);
            int Bogus_58(); // HRESULT FullTextIndexActive([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_59(); // HRESULT FullTextIndexActive([in] VARIANT_BOOL pRetVal);
            int Bogus_60(); // HRESULT FullTextKeyColumn([out, retval] long* pRetVal);
            int Bogus_61(); // HRESULT ListAvailableUniqueIndexesForFullText([out, retval] NameList** ppVBObjRet);
            int Bogus_62(); // HRESULT FullTextIndexScript([out, retval] BSTR* pRetVal);
            int Bogus_63(); // HRESULT HasClusteredIndex([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_64(); // HRESULT HasIndex([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_65(); // HRESULT FakeSystemTable([out, retval] VARIANT_BOOL* pRetVal);
        }

        [ComVisible(true), ComImport(), Guid("10020503-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IColumns {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            IColumn Item(object Index);
            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
            int GetCount();
            int Bogus_7(); // HRESULT ItemByID([in] long ID, [out, retval] Column** ppVBObjRet);
            int Add(IColumn Object);
            int Bogus_8(); // HRESULT Remove([in] VARIANT Index);
            int Refresh(object ReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10020500-E260-11CF-AE68-00AA004A34D5")]
        public class Column {
        }

        [ComVisible(true), ComImport(), Guid("10020506-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IColumn {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

            string GetName();
            int SetName(string pRetVal);
            int GetIdentityIncrement();
            int SetIdentityIncrement(int pRetVal);
            int GetIdentitySeed();
            int SetIdentitySeed(int pRetVal);

            IDRIDefault GetDRIDefault(); // HRESULT DRIDefault([out, retval] DRIDefault** ppVBObjRet);

            bool GetInPrimaryKey();
            string GetDatatype();
            int SetDatatype(string pRetVal);

            int Bogus_8(); // HRESULT PhysicalDatatype([out, retval] BSTR* pRetVal);

            int GetLength();
            int SetLength(int pRetVal);
            string GetDefault();
            int SetDefault(string pRetVal);

            int Bogus_9(); // HRESULT Rule([out, retval] BSTR* pRetVal);
            int Bogus_10(); // HRESULT Rule([in] BSTR pRetVal);

            bool GetAllowNulls();
            int SetAllowNulls(bool pRetVal);

            int Bogus_11(); // HRESULT ID([out, retval] long* pRetVal);

            bool GetIdentity();
            int SetIdentity(bool pRetVal);
            int GetNumericPrecision();
            int SetNumericPrecision(int pRetVal);
            int GetNumericScale();
            int SetNumericScale(int pRetVal);
            int Remove();

            int Bogus_12(); // HRESULT ListKeys([out, retval] SQLObjectList** ppVBObjRet);

            bool GetIsRowGuidCol();
            int SetIsRowGuidCol(bool pRetVal);

            int Bogus_13(); // HRESULT IsComputed([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_14(); // HRESULT IsComputed([in] VARIANT_BOOL pRetVal);
            int Bogus_15(); // HRESULT ComputedText([out, retval] BSTR* pRetVal);
            int Bogus_16(); // HRESULT ComputedText([in] BSTR pRetVal);
            int Bogus_17(); // HRESULT NotForRepl([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_18(); // HRESULT NotForRepl([in] VARIANT_BOOL pRetVal);
            int Bogus_19(); // HRESULT UpdateStatisticsWith([in] SQLDMO_STAT_SCAN_TYPE ScanType, [in, optional] VARIANT ScanNumber, [in, optional] VARIANT ReCompute);
            int Bogus_20(); // HRESULT FullTextIndex([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_21(); // HRESULT FullTextIndex([in] VARIANT_BOOL pRetVal);
            int Bogus_22(); // HRESULT AnsiPaddingStatus([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_23(); // HRESULT DefaultOwner([out, retval] BSTR* pRetVal);
            int Bogus_24(); // HRESULT RuleOwner([out, retval] BSTR* pRetVal);
            int Bogus_25(); // HRESULT BindDefault([in] BSTR DefaultOwner, [in] BSTR DefaultName, [in] VARIANT_BOOL Bind);
            int Bogus_26(); // HRESULT BindRule([in] BSTR RuleOwner, [in] BSTR RuleName, [in] VARIANT_BOOL Bind);
        }

        [ComVisible(true), ComImport(), Guid("10022B06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IDRIDefault {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

            string GetName(); // HRESULT Name([out, retval] BSTR* pRetVal);
            int SetName(string pRetVal); // HRESULT Name([in] BSTR pRetVal);

            string GetText(); // HRESULT Text([out, retval] BSTR* pRetVal);
            int SetText(string pRetVal); // HRESULT Text([in] BSTR pRetVal);

            int Remove(); // HRESULT Remove();

            int Bogus_7(); // HRESULT Script([in, optional, defaultvalue(4)] SQLDMO_SCRIPT_TYPE ScriptType, [in, optional] VARIANT ScriptFilePath, [in, optional, defaultvalue(0)] SQLDMO_SCRIPT2_TYPE Script2Type, [out, retval] BSTR* pRetVal);
        }

        [ComVisible(true), ComImport(), Guid("10020F03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IKeys {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

            IKey Item(object ItemIndex);

            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);

            int GetCount();
            int Add(IKey Object);
            int Remove(object Index);

            int Bogus_7(); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
        }

        [ComVisible(true), ComImport(), Guid("10020F00-E260-11CF-AE68-00AA004A34D5")]
        public class Key {
        }

        [ComVisible(true), ComImport(), Guid("10020F06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface IKey {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
            int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

            string GetName();
            int SetName(string pRetVal);

            int Bogus_7(); // HRESULT Clustered([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_8(); // HRESULT Clustered([in] VARIANT_BOOL pRetVal);
            int Bogus_9(); // HRESULT FillFactor([out, retval] long* pRetVal);
            int Bogus_10(); // HRESULT FillFactor([in] long pRetVal);

            INames GetKeyColumns();

            int Bogus_11(); // HRESULT ReferencedTable([out, retval] BSTR* pRetVal);
            int Bogus_12(); // HRESULT ReferencedTable([in] BSTR pRetVal);
            int Bogus_13(); // HRESULT ReferencedColumns([out, retval] Names** ppVBObjRet);

            int GetType();
            int SetType(int pRetVal);

            int Bogus_14(); // HRESULT ReferencedKey([out, retval] BSTR* pRetVal);

            int Remove();
            string Script(int ScriptType, object ScriptFilePath, int Script2Type);

            int Bogus_15(); // HRESULT RebuildIndex();
            int Bogus_16(); // HRESULT ExcludeReplication([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_17(); // HRESULT ExcludeReplication([in] VARIANT_BOOL pRetVal);
            int Bogus_18(); // HRESULT FileGroup([out, retval] BSTR* pRetVal);
            int Bogus_19(); // HRESULT FileGroup([in] BSTR pRetVal);
            int Bogus_20(); // HRESULT Checked([out, retval] VARIANT_BOOL* pRetVal);
            int Bogus_21(); // HRESULT Checked([in] VARIANT_BOOL pRetVal);
        }

        [ComVisible(true), ComImport(), Guid("10021D03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        public interface INames {
            int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
            int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
            int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
            int Bogus_4(); // HRESULT UserData([in] long pRetVal);
            int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

            string Item(object Index);

            int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);

            int GetCount();
            int Add(string NewName);
            int Remove(object ItemIndex);

            int Bogus_7(); // HRESULT Refresh();
            int Bogus_8(); // HRESULT Insert([in] BSTR NewName, [in] VARIANT InsertBeforeItem);
            int Bogus_9(); // HRESULT Replace([in] BSTR NewName, [in] VARIANT ReplaceItem);
            int Bogus_10(); // HRESULT FindName([in] BSTR Name, [out, retval] long* pRetVal);
        }


				[ComVisible(true), ComImport(), Guid("10021303-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface ILogins {

					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					
					ILogin Item(object ItemInd); // HRESULT Item([in] VARIANT ItemIndex, [out, retval] FileGroup** ppVBObjRet);

					int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
					
					int GetCount(); // HRESULT Count([out, retval] long* pRetVal);
					int Add(ILogin Object); // HRESULT Add(LPSQLDMOobject pObject);
					int Remove(object Index); // HRESULT Remove([in] VARIANT Index);
					int Refresh(object bReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);

				}
																						
				[ComVisible(true), ComImport(), Guid("10021300-E260-11CF-AE68-00AA004A34D5")]
					public class Login {
				}

				[ComVisible(true), ComImport(), Guid("10021306-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface ILogin {

					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

					string GetName(); // HRESULT GetName(SQLDMO_LPBSTR pRetVal);
					int SetName(string NewValue); // HRESULT SetName(SQLDMO_LPCSTR NewValue);

					bool GetSystemObject(); // HRESULT GetSystemObject(LPBOOL pRetVal);

					string GetLanguage(); // HRESULT GetLanguage(SQLDMO_LPBSTR pRetVal);
					int SetLanguage(string NewValue); //  HRESULT SetLanguage(SQLDMO_LPCSTR NewValue);

					string GetDatabase(); // HRESULT GetDatabase(SQLDMO_LPBSTR pRetVal);
					int SetDatabase(string NewValue); // HRESULT SetDatabase(SQLDMO_LPCSTR NewValue);

					int Remove(); // HRESULT Remove([in] VARIANT Index);

					string Script(int ScriptType, object ScriptFilePath, int Script2Type); // HRESULT Script([in, optional, defaultvalue(4)] SQLDMO_SCRIPT_TYPE ScriptType, [in, optional] VARIANT ScriptFilePath, [in, optional, defaultvalue(0)] SQLDMO_SCRIPT2_TYPE Script2Type, [out, retval] BSTR* pRetVal);

					int SetPassword(string OldValue, string NewValue); //HRESULT SetPassword(SQLDMO_LPCSTR OldValue,SQLDMO_LPCSTR NewValue);

					int GetEnumDatabaseMappings(); //IQueryResults  HRESULT EnumDatabaseMappings(LPSQLDMOQUERYRESULTS* ppResults);
					
					int GetType();	// HRESULT GetType(SQLDMO_LOGIN_TYPE* pRetVal)
					int SetType(int NewValue);	// HRESULT SetType(SQLDMO_LOGIN_TYPE NewValue)

					string GetDenyNTLogin(); // HRESULT GetDenyNTLogin(LPBOOL pRetVal);
					int SetDenyNTLogin(bool NewValue); // HRESULT SetDenyNTLogin(BOOL NewValue);
					
					INameList ListMembers(); // HRESULT ListMembers(LPSQLDMONAMELIST* ppList);

					bool IsMember(string szRole); // HRESULT IsMember(SQLDMO_LPCSTR szRole, LPBOOL pRetVal);

					string GetUserName(string DatabaseName); // HRESULT GetUserName(SQLDMO_LPCSTR DatabaseName, SQLDMO_LPBSTR pRetVal);

					string GetAliasName(string DatabaseName);

					string GetLanguageAlias();  // HRESULT GetLanguageAlias(SQLDMO_LPBSTR pbstrLanguageAlias);
					
					int GetNTLoginAccessType (); //HRESULT GetNTLoginAccessType (SQLDMO_NTACCESS_TYPE *pRetVal);
					
				}

				[ComVisible(true), ComImport(), Guid("10022F03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
				public interface IServerRoles  {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

					IServerRole Item(object ItemIndex);

					int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
					int GetCount(); //HRESULT Count([out, retval] long* pRetVal);
					int Refresh(object bReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);

				}

				[ComVisible(true), ComImport(), Guid("10022F00-E260-11CF-AE68-00AA004A34D5")]
					public class ServerRole {
				}

				[ComVisible(true), ComImport(), Guid("10022F06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface IServerRole  {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

					string GetName(); // HRESULT Name([out, retval] BSTR* pRetVal);
					string GetFullName(); //HRESULT FullName([out, retval] BSTR* pRetVal);
					string GetDescription(); //HRESULT Description([out, retval] BSTR* pRetVal);
					int Bogus_7(); //HRESULT EnumServerRolePermission([out, retval] QueryResults** ppVBObjRet);
					IQueryResults GetEnumServerRoleMember(); //HRESULT EnumServerRoleMember([out, retval] QueryResults** ppVBObjRet);
					int AddMember(string LoginName); //HRESULT AddMember([in] BSTR LoginName);
					int DropMember(string LoginName); //HRESULT DropMember([in] BSTR LoginName);
				}

				[ComVisible(true), ComImport(), Guid("10020B03-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface IUsers  {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

					IUser Item(object Index);

					int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
					int GetCount(); //HRESULT Count([out, retval] long* pRetVal);

					IUser ItemById(int ID); //HRESULT ItemByID([in] long ID,[out, retval] User** ppVBObjRet);

					int Add(IUser User); // HRESULT Add([in] User* Object);

					int Remove(object Index); //HRESULT Remove([in] VARIANT Index);

					int Refresh(object bReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
				}

				[ComVisible(true), ComImport(), Guid("10020B00-E260-11CF-AE68-00AA004A34D5")]
					public class User {
				}

				[ComVisible(true), ComImport(), Guid("10020B06-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface IUser {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

					string GetName(); // HRESULT Name([out, retval] BSTR* pRetVal);
					int SetName(string Name); // HRESULT Name([in] BSTR pRetVal);

					bool GetSystemObject(); // HRESULT SystemObject([out, retval] VARIANT_BOOL* pRetVal);

					string GetLogin(); //HRESULT Login([out, retval] BSTR* pRetVal);
					int SetLogin(string pRetVal); // HRESULT Login([in] BSTR pRetVal);

					string GetGroup(); // HRESULT Group([out, retval] BSTR* pRetVal);
					int SetGroup(string pRetVal); // HRESULT Group([in] BSTR pRetVal);

					int GetId(); // HRESULT ID([out, retval] long* pRetVal);

					int Bogus_7(); // HRESULT AddAlias([in] BSTR LoginNames);
					int Bogus_8(); // HRESULT RemoveAlias([in] BSTR LoginNames);
					int Bogus_9(); // HRESULT ListAliases([out, retval] SQLObjectList** ppVBObjRet);

					int Bogus_10(); //HRESULT ListOwnedObjects([in, optional, defaultvalue(4607)] SQLDMO_OBJECT_TYPE ObjectTypes, [in, optional, defaultvalue(0)] SQLDMO_OBJSORT_TYPE SortBy, [out, retval] SQLObjectList** ppVBObjRet);
					int Bogus_11(); // HRESULT ListDatabasePermissions([in, optional, defaultvalue(130944)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes, [out, retval] SQLObjectList** ppVBObjRet);
					int Bogus_12(); //HRESULT ListObjectPermissions([in, optional, defaultvalue(63)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes, [out, retval] SQLObjectList** ppVBObjRet);
					int Remove(); // HRESULT Remove();
					string Script(int ScriptType, object ScriptFilePath, int Script2Type); // HRESULT Script([in, optional, defaultvalue(4)] SQLDMO_SCRIPT_TYPE ScriptType, [in, optional] VARIANT ScriptFilePath, [in, optional, defaultvalue(0)] SQLDMO_SCRIPT2_TYPE Script2Type, [out, retval] BSTR* pRetVal);

					string GetRole(); // HRESULT Role([out, retval] BSTR* pRetVal);
					string SetRole(string pRetVal); // HRESULT Role([in] BSTR pRetVal);

					INameList ListMembers(); // HRESULT ListMembers([out, retval] NameList** ppVBObjRet);
					bool IsMember( string szRole ); // HRESULT IsMember([in] BSTR DatabaseRole,  [out, retval] VARIANT_BOOL* pRetVal);
				
					bool GetHasDBAccess(); // HRESULT HasDBAccess([out, retval] VARIANT_BOOL* pRetVal);
					int Bogus_14(); // HRESULT GrantNTUserDBAccess();
				}

				[ComVisible(true), ComImport(), Guid("10023103-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface IDatabaseRoles  {

					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

					IDatabaseRole Item(object Index);

					int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
					int GetCount(); //HRESULT Count([out, retval] long* pRetVal);

					int Add(IDatabaseRole DatabaseRole); // HRESULT Add([in] User* Object);

					int Remove(object Index); //HRESULT Remove([in] VARIANT Index);

					int Refresh(object ReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
				}

				[ComVisible(true), ComImport(), Guid("10023100-E260-11CF-AE68-00AA004A34D5")]
					public class DatabaseRole {
				}

				[ComVisible(true), ComImport(), Guid("10023106-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface IDatabaseRole {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

					string GetName(); // HRESULT Name([out, retval] BSTR* pRetVal);
					int SetName(string Name); // HRESULT Name([in] BSTR pRetVal);

					string GetPassword(); // HRESULT Password([out, retval] BSTR* pRetVal);
					int SetPassword(string pRetVal ); //HRESULT Password([in] BSTR pRetVal);

					bool GetAppRole(); // HRESULT AppRole([out, retval] VARIANT_BOOL* pRetVal);
					int SetAppRole( bool pRetVal );  //HRESULT AppRole([in] VARIANT_BOOL pRetVal);

					int Remove(); // HRESULT Remove();ARIANT_BOOL* pRetVal);
					IQueryResults GetEnumDatabaseRoleMember(); // HRESULT EnumDatabaseRoleMember([out, retval] QueryResults** ppVBObjRet);
					int AddMember( string userName ); // HRESULT AddMember([in] BSTR UserName);
					int DropMember( string userName ); // HRESULT DropMember([in] BSTR UserName);

					string Script(int ScriptType, object ScriptFilePath, int Script2Type); // HRESULT Script([in, optional, defaultvalue(4)] SQLDMO_SCRIPT_TYPE ScriptType, [in, optional] VARIANT ScriptFilePath, [in, optional, defaultvalue(0)] SQLDMO_SCRIPT2_TYPE Script2Type, [out, retval] BSTR* pRetVal);

					IQueryResults GetEnumFixedDatabaseRolePermission(); // HRESULT EnumFixedDatabaseRolePermission([out, retval] QueryResults** ppVBObjRet);
					bool GetIsFixedRole();// HRESULT IsFixedRole([out, retval] VARIANT_BOOL* pRetVal);

					ISQLObjectList GetListDatabasePermissions(int PrivilegeTypes); // HRESULT ListDatabasePermissions([in, optional, defaultvalue(130944)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes,  [out, retval] SQLObjectList** ppVBObjRet);
					ISQLObjectList GetListObjectPermissions(int PrivilegeTypes); // HRESULT ListObjectPermissions([in, optional, defaultvalue(63)] SQLDMO_PRIVILEGE_TYPE PrivilegeTypes, [out, retval] SQLObjectList** ppVBObjRet);
				}

				[ComVisible(true), ComImport(), Guid("10022406-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface INameList {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

					string Item(object Index);
					
					int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);

					int GetCount(); // HRESULT Count([out, retval] long* pRetVal);
					int Refresh(); // HRESULT Refresh();
					int FindName(string Name);// HRESULT FindName([in] BSTR Name, [out, retval] long* pRetVal);
				}

				[ComVisible(true), ComImport(), Guid("10022806-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface ISQLObjectList {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int TypeOf(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

					_IVSQLDMOStdObject Item(object Index); // HRESULT Item([in] VARIANT Index, [out, retval] _IVSQLDMOStdObject** ppVBObjRet);
					
					int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);

					int GetCount(); // HRESULT Count([out, retval] long* pRetVal);
					int Refresh(); // HRESULT Refresh();
				}

				[ComVisible(true), ComImport(), Guid("10022906-E260-11CF-AE68-00AA004A34D5")]
					public class Permission {
				}

				[ComVisible(true), ComImport(), Guid("10022906-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface IPermission {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

					string GetPrivilegeTypeName(); // HRESULT PrivilegeTypeName([out, retval] BSTR* pRetVal);
					int GetPrivilegeType(); // HRESULT PrivilegeType([out, retval] SQLDMO_PRIVILEGE_TYPE* pRetVal);	
					string GetObjectName(); // HRESULT ObjectName([out, retval] BSTR* pRetVal);
					string GetObjectOwner(); // HRESULT ObjectOwner([out, retval] BSTR* pRetVal);
					string GetObjectTypeName(); // HRESULT ObjectTypeName([out, retval] BSTR* pRetVal);
					int GetObjectType(); // HRESULT ObjectType([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int GetObjectID(); // HRESULT ObjectID([out, retval] long* pRetVal);
					string GetGrantee(); // HRESULT Grantee([out, retval] BSTR* pRetVal);
					bool Granted(); // HRESULT Granted([out, retval] VARIANT_BOOL* pRetVal);
					ISQLObjectList ListPrivilegeColumns(); // HRESULT ListPrivilegeColumns([out, retval] SQLObjectList** ppVBObjRet);
				}

				[ComVisible(true), ComImport(), Guid("10010007-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface _IVSQLDMOStdObject {}

				[ComVisible(true), ComImport(), Guid("10021403-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface ILanguages {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);

					ILanguage Item(object Index); // HRESULT Item([in] VARIANT Index, [out, retval] Language** ppVBObjRet);

					int Bogus_6(); // HRESULT _NewEnum([out, retval] IUnknown** ppEnum);
					int GetCount(); // HRESULT Count([out, retval] long* pRetVal);
					ILanguage GetItemByID(int ID); // HRESULT ItemByID([in] long ID, [out, retval] Language** ppVBObjRet);
					int Refresh(bool ReleaseMemberObjects); // HRESULT Refresh([in, optional] VARIANT ReleaseMemberObjects);
				}

				[ComVisible(true), ComImport(), Guid("10021400-E260-11CF-AE68-00AA004A34D5")]
					public class Language {	}

				[ComVisible(true), ComImport(), Guid("10021406-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface ILanguage {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);

					string GetName(); // HRESULT Name([out, retval] BSTR* pRetVal);
					int GetID(); // HRESULT ID([out, retval] long* pRetVal);
					int Bogus_7(); // HRESULT Upgrade([out, retval] long* pRetVal);
					string GetAlias(); // HRESULT Alias([out, retval] BSTR* pRetVal);
					int Bogus_9(); // HRESULT Alias([in] BSTR pRetVal);
					int Bogus_10(); // HRESULT Months([out, retval] BSTR* pRetVal);
					int Bogus_11(); // HRESULT ShortMonths([out, retval] BSTR* pRetVal);
					int Bogus_12(); // HRESULT Days([out, retval] BSTR* pRetVal);
					int Bogus_13(); // HRESULT Days([out, retval] BSTR* pRetVal);
					int Bogus_14(); // HRESULT LangDateFormat([out, retval] BSTR* pRetVal);
					int Bogus_15(); // HRESULT FirstDayOfWeek([out, retval] int* pRetVal);
					int Bogus_16(); // HRESULT Month([in] int Month, [out, retval] BSTR* pRetVal);
					int Bogus_17(); // HRESULT ShortMonth([in] int Month, [out, retval] BSTR* pRetVal);
					int Bogus_18(); // HRESULT Day([in] int Day, [out, retval] BSTR* pRetVal);
				}

				[ComVisible(true), ComImport(), Guid("10022506-E260-11CF-AE68-00AA004A34D5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
					public interface IQueryResults  {
					int Bogus_1(); // HRESULT Application([out, retval] Application** ppApp);
					int Bogus_2(); // HRESULT Parent([out, retval] _IVSQLDMOStdObject** ppParent);
					int Bogus_3(); // HRESULT UserData([out, retval] long* pRetVal);
					int Bogus_4(); // HRESULT UserData([in] long pRetVal);
					int Bogus_5(); // HRESULT TypeOf([out, retval] SQLDMO_OBJECT_TYPE* pRetVal);
					int Bogus_6(); // HRESULT Properties([out, retval] Properties** ppVBObjRet);
					int Bogus_7(); // HRESULT ResultSets([out, retval] long* pRetVal);
					int Bogus_8(); // HRESULT CurrentResultSet([out, retval] long* pRetVal);
					int Bogus_8a(); // HRESULT CurrentResultSet([in] long pRetVal);
					int GetRows(); // HRESULT Rows([out, retval] long* pRetVal);
					int GetColumns(); // HRESULT Columns([out, retval] long* pRetVal);
					string GetColumnName(int Column); // HRESULT ColumnName([in] long Column, [out, retval] BSTR* pRetVal);
					int Bogus_9(); // HRESULT ColumnType([in] long Column, [out, retval] SQLDMO_QUERY_DATATYPE* pRetVal);
					int Bogus_10(); // HRESULT ColumnMaxLength([in] long Column, [out, retval] long* pRetVal);
					int Bogus_11(); // HRESULT GetColumnLong([in] long Row, [in] long Column, [out, retval] long* pRetVal);
					int Bogus_12(); // HRESULT GetColumnBool([in] long Row, [in] long Column, [out, retval] VARIANT_BOOL* pRetVal);
					int Bogus_13(); // HRESULT GetColumnFloat([in] long Row, [in] long Column, [out, retval] single* pRetVal);
					int Bogus_14(); // HRESULT GetColumnDouble([in] long Row, [in] long Column, [out, retval] double* pRetVal);
					string GetColumnString(int Row, int Column); // HRESULT GetColumnString([in] long Row, [in] long Column, [out, retval] BSTR* pRetVal);
					string GetRangeString(int Top, int Left, int Bottom, int Right); // HRESULT GetRangeString([in, optional] VARIANT Top, [in, optional] VARIANT Left, [in, optional] VARIANT Bottom, [in, optional] VARIANT Right, [in, optional] VARIANT RowDelim, [in, optional] VARIANT ColDelim, [in, optional] VARIANT ColWidths, [out, retval] BSTR* pRetVal);
					int Bogus_15(); // HRESULT GetColumnDate([in] long Row, [in] long Column, [out, retval] DATE* pRetVal);
					int Bogus_16(); // HRESULT GetColumnBinary([in] long Row, [in] long Column, [out, retval] SAFEARRAY(unsigned char)* pRetVal);
					int Bogus_17(); // HRESULT GetColumnBinaryLength([in] long Row, [in] long Column, [out, retval] long* pRetLen);
					int Bogus_18(); // HRESULT GetColumnGUID([in] long Row, [in] long Column, [out, retval] SAFEARRAY(unsigned char)* pRetVal);

				}
		}
}
