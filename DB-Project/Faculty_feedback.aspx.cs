using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Faculty_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList1.Items.Clear(); // Clear DropDownList1 before adding items
        int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT DISTINCT CourseName from Faculty_Courses where Faculty_ID = @Faculty_ID";

        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Faculty_ID", ID);

        // Execute the query
        SqlDataReader reader = command.ExecuteReader();
        DropDownList1.Items.Add(new ListItem("Select Course", ""));
        while (reader.Read())
        {
            string course_name = reader.GetString(0).ToString();
            DropDownList1.Items.Add(new ListItem(course_name, course_name));
        }

        // Store the selected course in the ViewState
        //ViewState["SelectedCourse"] = DropDownList1.SelectedValue;

        // Close the SqlDataReader and the SqlConnection
        reader.Close();
        conn.Close();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True"))
        {
            // Open the connection
            conn.Open();
            string course = DropDownList1.SelectedValue;

            string q2 = "SELECT COUNT(*) from feed where Course_Name = @Course_Name";
            SqlCommand cmd2 = new SqlCommand(q2, conn);
            cmd2.Parameters.AddWithValue("@Course_Name", course);
            int count = (int)cmd2.ExecuteScalar();   //for counting students

            // Create a SqlCommand object to execute the query
            string query = "SELECT SUM(Val1) as s1, SUM(Val2) as s2, SUM(Val3) as s3, SUM(Val4) as s4, SUM(Val5) as s5 FROM feed where COurse_Name = @Course_Name";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Course_Name", course);

            float c1;
            float c2;
            float c3;
            float c4;
            float c5;

            // Execute the query and retrieve the results
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if there are any rows returned
                if (reader.HasRows && reader.Read())
                {
                    
                    float.TryParse(reader.GetValue(0).ToString(), out c1);
                    c1 = c1 / count * 100;
                    Label1.Text = c1.ToString();

                    float.TryParse(reader.GetValue(1).ToString(), out c2);
                    c2 = c2 / count * 100;
                    Label2.Text = c1.ToString();

                    float.TryParse(reader.GetValue(2).ToString(), out c3);
                    c3 = c3 / count * 100;
                    Label3.Text = c3.ToString();

                    float.TryParse(reader.GetValue(3).ToString(), out c4);
                    c4 = c4 / count * 100;
                    Label4.Text = c4.ToString();

                    float.TryParse(reader.GetValue(4).ToString(), out c5);
                    c5 = c5 / count * 100;
                    Label5.Text = c5.ToString();

                }
                else
                {
                    Label1.Text = "No data available";
                    Label2.Text = "No data available";
                    Label3.Text = "No data available";
                    Label4.Text = "No data available";
                    Label5.Text = "No data available";
                }
            }

            string q3 = "SELECT Comment from feed where Course_Name = @Course_Name AND Comment IS NOT NULL";

            SqlCommand cmd3 = new SqlCommand(q3, conn);
            cmd3.Parameters.AddWithValue("@Course_Name", course);
            SqlDataReader da = cmd3.ExecuteReader();

            int j = 0;

            for(int i = 0; i < count; i++)
            {
                TableRow row = new TableRow(); 
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();

                cell1.HorizontalAlign = HorizontalAlign.Center;
                cell2.HorizontalAlign = HorizontalAlign.Center;

                if (da.Read())
                {
                    cell1.Text = (j+1).ToString();
                    cell2.Text = da.GetValue(0).ToString();
                    if (da.GetValue(0).ToString() != " ")
                    {
                        j++;
                    }
                   
                }
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                Table2.Rows.Add(row);
            }
        }

        DropDownList1.Items.Clear();
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
    }

    private string DataTableToCsv2(DataTable data)
    {
        StringWriter writer = new StringWriter();

        // Write the column headers
        for (int i = 0; i < data.Columns.Count; i++)
        {
            writer.Write(data.Columns[i].ColumnName);
            if (i < data.Columns.Count - 1)
                writer.Write(",");
        }
        writer.WriteLine();

        // Write the data rows
        foreach (DataRow row in data.Rows)
        {
            for (int i = 0; i < data.Columns.Count; i++)
            {
                writer.Write(row[i].ToString());
                if (i < data.Columns.Count - 1)
                    writer.Write(",");
            }
            writer.WriteLine();
        }

        return writer.ToString();
    }

    private DataTable FetchDataFromSQLTable2()
    {


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        string q = "select Val1 as Poor, Val2 as BelowAverage, Val3 as Average, Val4 as Good, Val5 as Excellent, Comment from feed where Course_Name = 'Data Structures'";

        //  using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        using (SqlCommand command = new SqlCommand(q, con))
        {
            //conn.Open();

            DataTable dataTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }
            con.Close();
            return dataTable;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable data = FetchDataFromSQLTable2();

        // Generate CSV content from the data
        string csvContent = DataTableToCsv2(data);

        // Set response headers for file download
        Response.Clear();
        Response.ContentType = "application/pdf";

        //Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment; filename=Feedback.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
    }
}