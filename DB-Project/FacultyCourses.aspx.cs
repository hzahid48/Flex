using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacultyCourses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateRows();
    }
    protected void GenerateRows()
    {
        int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string fn = "";
        string ln = "";

        string q1 = "SELECT FirstName, LastName from USERS where User_ID = @fac_ID";
        SqlCommand c1 = new SqlCommand(q1, conn);
        c1.Parameters.AddWithValue("@fac_ID", ID);
        SqlDataReader da1 = c1.ExecuteReader();

        while(da1.Read())
        {
            fn = da1.GetValue(0).ToString();
            ln = da1.GetValue(1).ToString();
        }
        string name = fn + " "+ ln;
        da1.Close();

        string query = "SELECT COUNT(*) from Faculty_Courses where Faculty_ID = @Faculty_ID";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Faculty_ID", ID);
        int numValues = (int)command.ExecuteScalar();

        query = "SELECT CourseName, Section from Faculty_Courses where Faculty_ID = @Faculty_ID";
        command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Faculty_ID", ID);
        SqlDataReader da = command.ExecuteReader();

        for (int i = 0; i < numValues; i++)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();

            cell2.HorizontalAlign = HorizontalAlign.Center;
            cell3.HorizontalAlign = HorizontalAlign.Center;

            if (da.Read())
            {
                cell1.Text = da.GetValue(0).ToString();
                cell2.Text = da.GetValue(1).ToString();
            }

            System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label();
            label.Text = cell2.Text;
            cell2.Controls.Add(label);

            cell3.Text = name;

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            Table1.Rows.Add(row);
        }

        da.Close();
        conn.Close();
    }


}