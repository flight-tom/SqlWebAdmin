using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SqlAdmin;

public partial class viewTableData : System.Web.UI.Page
{
    private const string controlPrefix1 = "Haiyan_Du_True_";//Dynamically add database field, if it is primary key, set id =controlPrefix1
    private const string controlPrefix2 = "Haiyan_Du_False_";//else use controlPrefix2
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    //this.SqlDataSource1.Update();
        //    //this.SqlDataSource1.DataBind();
        //}
    }
   /// <summary>
   /// Page Initial Event
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void Page_PreInit(object sender, EventArgs e)
    {       
        ShowTableData();
    }

    /// <summary>
    /// Bind table data to DataGridView
    /// </summary>
    public void ShowTableData()
    {
        try
        {
            this.curTable.Text = "";
            SqlServer server = SqlServer.CurrentServer;
            server.Connect();

            SqlDatabase database = SqlDatabase.CurrentDatabase(server);

            SqlTable table = database.Tables[HttpContext.Current.Server.HtmlDecode(HttpContext.Current.Request["table"])];
            if (table.PrimaryKeys == null || table.PrimaryKeys.Length < 1)
            {
                table.AddIDColumn();
            }
            if (table == null)
            {
                server.Disconnect();

                // Table doesn't exist - break out and go to error page
                Response.Redirect(String.Format("error.aspx?error={0}", 1002));
                return;
            }
           
            this.GridView_ViewTableData.DataSource =table.GetTableData();
            this.GridView_ViewTableData.DataBind();          
       

            this.curTable.Text = "Table - " + table.Name;
          
            server.Disconnect();
            
          

        }
        catch (Exception ex)
        {
            this.MessageLabel.Text = ex.ToString();
        }
    }
    /// <summary>
    /// Edit data record button clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_ViewTableData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int selectedIndex=-1;
        Int32.TryParse(e.CommandArgument.ToString(), out selectedIndex);
        GridViewRow gr = this.GridView_ViewTableData.Rows[selectedIndex];
        SqlTable curTable = SqlTable.CurrentTable;
        LiteralControl tblHeader = new LiteralControl("<table>");
        this.dbFields.Controls.Add(tblHeader);
        for (int i = 0; i < curTable.Columns.Count; i++)
        {
            TableCell c = gr.Cells[i + 1];//the first cell is edit column
            SqlColumn sc = curTable.Columns[i];
            Label lblTitle = new Label();
            lblTitle.Text = sc.ColumnInformation.Name;
           // lblTitle.EnableViewState = true;
            TextBox txtContent = new TextBox();
            txtContent.Text = c.Text;
            txtContent.EnableViewState = true;
            if(sc.ColumnInformation.Key)
                txtContent.ID = controlPrefix1+sc.ColumnInformation.Name;//make the control to be unique.
            else
                txtContent.ID = controlPrefix2+sc.ColumnInformation.Name;//make the control to be unique.
            

            if (sc.ColumnInformation.Key || sc.ColumnInformation.Identity 
                || sc.ColumnInformation.ColumnDbType==DbType.Object
                || sc.ColumnInformation.ColumnDbType==DbType.Binary)
                txtContent.Enabled = false;
            LiteralControl rowPart1=new LiteralControl("<tr><td>");

            this.dbFields.Controls.Add(rowPart1);
            this.dbFields.Controls.Add(lblTitle);
            LiteralControl rowPart2 = new LiteralControl("</td><td>");
            this.dbFields.Controls.Add(rowPart2);
            this.dbFields.Controls.Add(txtContent);
            LiteralControl rowPart3 = new LiteralControl("</td></tr>");
            this.dbFields.Controls.Add(rowPart3);           

            
        }
        
        LiteralControl tblFooter = new LiteralControl("</table>");    
        this.dbFields.EnableViewState = true;
        this.dbFields.Controls.Add(tblFooter);
        this.dbFields.DataBind();
        if (selectedIndex > -1)
        {
            programmaticModalPopup.Show();
        }

       
    }
    /// <summary>
    /// Update Data Record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SqlTable curTable = SqlTable.CurrentTable;

            string updateFields = "set ";
            string whereClause = "";

            foreach (Control c in this.dbFields.Controls)
            {
                if (c.ID.StartsWith(controlPrefix1) || c.ID.StartsWith(controlPrefix2)) //Text Box Field
                {
                    TextBox curBox = (TextBox)c;
                    string colName = curBox.ID;
                    if (curBox.Enabled) //not key field, and not object/binary data type
                    {
                        colName = colName.Replace(controlPrefix2, "");
                        string updatedValue = curBox.Text.Trim();
                        updateFields += colName + "='" + updatedValue + "',";
                    }
                    else if (curBox.ID.StartsWith(controlPrefix1)) //key field
                    {                       
                        colName = colName.Replace(controlPrefix1 , "");
                        whereClause += colName + "='" + curBox.Text.Trim() + "',";
                    }

                }
            }
            updateFields = updateFields.Substring(0, updateFields.Length - 1);
            whereClause = whereClause.Substring(0, whereClause.Length - 1);
            string sqlCommand = string.Format("Update {0} set {1} where {2}"
                , curTable.Name
                , updateFields
                , whereClause);
            SqlServer server = SqlServer.CurrentServer;
            server.Connect();
            SqlDatabase database = SqlDatabase.CurrentDatabase(server);
            server.Query(sqlCommand, database.Name);
            server.Disconnect();
        }
        catch (Exception ex)
        {
            Application["Error"] = ex;
            Response.Redirect("Error.aspx");

        }

    }
    
    /// <summary>
    /// Cancel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
}
