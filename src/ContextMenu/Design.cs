using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;


namespace Msdn
{
	namespace Design
	{
		#region ContextMenuDesign Class
		public class ContextMenuDesign : ControlDesigner
		{
			#region Constants
			// *******************************************************************************************
			// Constants 
			#endregion


			#region Private members
			// *******************************************************************************************
			// Private members
			private ContextMenu _contextMenuInstance;
			#endregion
			

			#region Ctor(s)
			// *******************************************************************************************
			// Ctor 
			public ContextMenuDesign() : base()  
			{
			}
			#endregion


			#region Overridden methods
			// *******************************************************************************************
			// METHOD: Initialize
			// Initialize the control to render at design-time
			public override void Initialize(System.ComponentModel.IComponent component)
			{
				_contextMenuInstance = (ContextMenu) component;
				base.Initialize(component);
			}


			// *******************************************************************************************
			// METHOD: GetDesignTimeHtml
			// Returns the HTML to display in the VS IDE
			public override string GetDesignTimeHtml() 
			{
				int numOfItems = _contextMenuInstance.ContextMenuItems.Count;
				if (numOfItems == 0)
				{
					_contextMenuInstance.ContextMenuItems.Clear();
					for(int i=0; i<5; i++)
					{
						ContextMenuItem item = new ContextMenuItem("Item", "");
						_contextMenuInstance.ContextMenuItems.Add(item);
					}
				}

				// Add the selected item
				int selectedItemPos = 1; 
				ContextMenuItem selectedItem = new ContextMenuItem("Selected Item", "");
				_contextMenuInstance.ContextMenuItems.AddAt(selectedItemPos, selectedItem);

				// Pseudo-rendering
				StringWriter swTemp = new StringWriter();
				HtmlTextWriter writer = new HtmlTextWriter(swTemp);
				_contextMenuInstance.RenderControl(writer);
				writer.Close();
				swTemp.Close();

				// Modify the background color of the selected item
				Table menu = (Table) (_contextMenuInstance.Controls[0]).Controls[0];
				TableRow row = menu.Rows[selectedItemPos];
				row.BackColor = _contextMenuInstance.RolloverColor;
				
				StringWriter sw = new StringWriter();
				writer.InnerWriter = sw;
				menu.RenderControl(writer);

				if (numOfItems == 0)
					_contextMenuInstance.ContextMenuItems.Clear();
				else
					_contextMenuInstance.ContextMenuItems.RemoveAt(selectedItemPos);

				return sw.ToString();
			}
			#endregion
		}
		#endregion
	}
}
