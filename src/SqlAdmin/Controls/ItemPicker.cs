using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqlAdmin.Controls
{
	public enum ItemAction 
	{
		Add,
		Remove
	}

	public delegate void ItemPickerEventHandler(object sender, ItemPickerEventArgs e);

	public class ItemPickerEventArgs : EventArgs 
	{
		public ItemPickerEventArgs(ListItem item, ItemAction action) : base() 
		{
			this.Item=item;
			this.Action=action;
		}
		public ListItem Item;
		public ItemAction Action;
	}

	/// <summary>
	/// Abstract control for creating a 1 to 1 "picker" for any collection object
	/// that implements ICollection.
	/// </summary>
	public abstract class ItemPicker : UserControl 
	{
		#region Public properties
		public string DataTextField 
		{
			set 
			{
				ItemsBox.DataTextField=value;
				SelectedItemsBox.DataTextField=value;
			}
		}
		public string DataValueField 
		{
			set 
			{
				ItemsBox.DataValueField=value;
				SelectedItemsBox.DataValueField=value;
			}
		}

		public ICollection Items 
		{
			get 
			{
				return ViewState["Items"] as ICollection;
			}
			set 
			{
				if (value!=null && value.Count>0) 
				{
					ItemsBox.Items.Clear();
					ItemsBox.Enabled=true;
					ViewState["Items"]=value;
					BindItems();
				} 
				else 
				{
					resetItemsBox();
				}
			}
		}

		public ICollection SelectedItems 
		{
			get 
			{
				return ViewState["SelectedItems"] as ICollection;
			}
			set 
			{
				if (value!=null && value.Count>0) 
				{
					SelectedItemsBox.Items.Clear();
					SelectedItemsBox.Enabled=true;
					ViewState["SelectedItems"]=value;
					BindSelectedItems();
				} 
				else 
				{
					resetSelectedItemsBox();
				}
			}
		}
		#endregion

		public event ItemPickerEventHandler ItemChanged;

		public void OnItemChanged(ItemPickerEventArgs e) 
		{
			ItemChanged(this,e);
		}

		protected ListBox ItemsBox;
		protected ListBox SelectedItemsBox;
		
		protected override void OnPreRender(EventArgs e) 
		{
			if (!Page.IsPostBack) 
			{
				if (Items==null || Items.Count==0)
					resetItemsBox();
				else
					BindItems();

				if (SelectedItems==null || SelectedItems.Count==0)
					resetSelectedItemsBox();
				else
					BindSelectedItems();
			}
		}

		protected void BindItems() 
		{
			ItemsBox.DataSource=Items;
			ItemsBox.DataBind();
		}

		protected void BindSelectedItems() 
		{
			SelectedItemsBox.DataSource=SelectedItems;
			SelectedItemsBox.DataBind();
			foreach (ListItem item in SelectedItemsBox.Items) 
			{
				ListItem itemToRemove = ItemsBox.Items.FindByValue(item.Value);
				if (itemToRemove!=null)
					ItemsBox.Items.Remove(itemToRemove);
			}
			if (ItemsBox.Items.Count==0)
				resetItemsBox();
		}

		protected void AddItem_Click(object sender, EventArgs e) 
		{
			if (ItemsBox.SelectedItem!=null) 
			{
				if (!SelectedItemsBox.Enabled) 
				{
					SelectedItemsBox.Items.Clear();
					SelectedItemsBox.Enabled=true;
				}
				OnItemChanged(new ItemPickerEventArgs(ItemsBox.SelectedItem,ItemAction.Add));
				SelectedItemsBox.SelectedIndex=-1;
				SelectedItemsBox.Items.Add(ItemsBox.SelectedItem);
				ItemsBox.Items.Remove(ItemsBox.SelectedItem);
				if (ItemsBox.Items.Count==0)
					resetItemsBox();
			}
		}

		protected void RemoveItem_Click(object sender, EventArgs e) 
		{
			if (SelectedItemsBox.SelectedItem!=null) 
			{
				if (!ItemsBox.Enabled) 
				{
					ItemsBox.Items.Clear();
					ItemsBox.Enabled=true;
				}
				OnItemChanged(new ItemPickerEventArgs(SelectedItemsBox.SelectedItem,ItemAction.Remove));
				ItemsBox.SelectedIndex=-1;
				ItemsBox.Items.Add(SelectedItemsBox.SelectedItem);
				SelectedItemsBox.Items.Remove(SelectedItemsBox.SelectedItem);
				if (SelectedItemsBox.Items.Count==0)
					resetSelectedItemsBox();
			}
		}

		private void resetItemsBox() 
		{
			ItemsBox.Items.Clear();
			ItemsBox.Items.Add(new ListItem(defaultText,String.Empty));
			ItemsBox.Enabled=false;
		}

		private void resetSelectedItemsBox() 
		{
			SelectedItemsBox.Items.Clear();
			SelectedItemsBox.Items.Add(new ListItem(defaultText,String.Empty));
			SelectedItemsBox.Enabled=false;
		}

		private readonly string defaultText="(No Items)";
	}
}
