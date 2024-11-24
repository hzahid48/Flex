using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class S_transcript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = (int)Session["ID"];

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT Count(*) from Transcript where Student_ID = @Student_ID";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Student_ID", ID);

        int numValues = (int)command.ExecuteScalar();

        query = "SELECT * from Transcript where Student_ID = @Student_ID";
        command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Student_ID", ID);
        SqlDataReader da = command.ExecuteReader();

        for (int i = 0; i < numValues; i++)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();

            //cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell2.HorizontalAlign = HorizontalAlign.Center;
            cell3.HorizontalAlign = HorizontalAlign.Center;

            if (da.Read())
            {
                cell1.Text = da.GetValue(1).ToString();
                cell2.Text = da.GetValue(2).ToString();
                cell3.Text = da.GetValue(3).ToString();
            }

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);

            Table4.Rows.Add(row);
        }

     

        da.Close();

        string q1 = "Select Count(Student_ID) from Transcript where Student_ID = @Student_ID";
        SqlCommand command3 = new SqlCommand(q1, conn);
        command3.Parameters.AddWithValue("@Student_ID", ID);
        int numcourses = (int)command3.ExecuteScalar(); 

        double sgpa = 0;
        string q = "Select GPA from Transcript where Student_ID = @Student_ID";
        SqlCommand command2 = new SqlCommand(q, conn);
        command2.Parameters.AddWithValue("@Student_ID", ID);
        SqlDataReader da2 = command2.ExecuteReader();
        float s = 0;
        while (da2.Read())
        {
            s = float.Parse(da2.GetValue(0).ToString());
            sgpa += s;
        }

        double sgpa2 = sgpa / numcourses;
        double g = 3.2 + 3.4 + 3.0;
        double cgpa = (g + sgpa2) / 4;
        Label1.Text = cgpa.ToString("N1");

        Label2.Text = sgpa2.ToString("N1");
        da2.Close();
        conn.Close();
    }


}