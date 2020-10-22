using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.ComponentModel.Design;
using System.Reflection;


namespace Msdn
{
	#region ContextMenuItem Class
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ContextMenuItem
	{
		#region Constructor(s)
		public ContextMenuItem()
		{
		}
		public ContextMenuItem(string text, string commandName)
		{
			_text = text;
			_commandName = commandName;
		}

		#endregion

		#region Private members
		private string _text;
		private string _commandName;
		private string _tooltip;
		#endregion

		#region Properties
		[Category("Behavior"), DefaultValue(""), Description("Text of the menu item"), NotifyParentProperty(true)]
		public string Text
		{
			get {return _text;}
			set {_text = value;}
		}


		[Category("Behavior"), DefaultValue(""), Description("Command name associated with the menu item"), NotifyParentProperty(true)]
		public string CommandName
		{
			get {return _commandName;}
			set {_commandName = value;}
		}


		[Category("Behavior"), DefaultValue(""), Description("The tooltip for the menu item"), NotifyParentProperty(true)]
		public string Tooltip
		{
			get {return _tooltip;}
			set {_tooltip = value;}
		}

		#endregion
	}
	#endregion 

	#region ContextMenuItemCollection
	public class ContextMenuItemCollection : CollectionBase
	{
		// ***********************************************************************************
		// Ctor		
		public ContextMenuItemCollection()
		{
		}
		
	
		// ***********************************************************************************
		// Gets and sets the element at the specified position
		public ContextMenuItem this[int index]
		{
			get { return (ContextMenuItem) InnerList[index]; }
			set { InnerList[index] = value; }
		}

		
		// ***********************************************************************************
		// Adds an object to the end of the collection
		public void Add(ContextMenuItem item)
		{
			InnerList.Add(item);
		}


		// ***********************************************************************************
		// Adds an object at the specified position in the collection
		public void AddAt(int index, ContextMenuItem item)
		{
			InnerList.Insert(index, item);
		}
	}
	#endregion

	#region ContextMenuItemCollectionEditor Class
	public class ContextMenuItemCollectionEditor : CollectionEditor
	{
		public ContextMenuItemCollectionEditor(Type type) : base(type)
		{
		}

		protected override bool CanSelectMultipleInstances()
		{
			return false;
		}

		protected override Type CreateCollectionItemType()
		{
			return typeof(ContextMenuItem);
		}
	}
	#endregion
}
