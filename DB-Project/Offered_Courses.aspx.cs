using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Collections;

public partial class Offered_Courses : System.Web.UI.Page
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

        string query = "SELECT Count(Course_Code) from Courses";
        SqlCommand command = new SqlCommand(query, conn);

        int numValues = (int)command.ExecuteScalar();

        query = "SELECT Course_Name, Course_Code, Pre_Req from Courses";
        command = new SqlCommand(query, conn);
        SqlDataReader da = command.ExecuteReader();

        for (int i = 0; i < numValues; i++)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();

            cell1.HorizontalAlign = HorizontalAlign.Center;
            cell2.HorizontalAlign = HorizontalAlign.Left;
            cell4.HorizontalAlign = HorizontalAlign.Center;
            cell3.HorizontalAlign = HorizontalAlign.Left;

            if (da.Read())
            {
                cell1.Text = da.GetValue(1).ToString();
                cell2.Text = da.GetValue(0).ToString();
                if(da.GetValue(2).ToString() == "")
                {
                    cell3.Text = "NULL";
                }
                else
                cell3.Text = da.GetValue(2).ToString();
                cell4.Controls.Add(new CheckBox());
            }

            System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label();
            label.Text = cell2.Text;
            cell2.Controls.Add(label);


            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            Table1.Rows.Add(row);
        }

        da.Close();
        conn.Close();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //int ID = (int)Session["ID"];
        foreach (TableRow row in Table1.Rows)
        {
            TableCell cell = row.Cells[3];
            if (cell.Controls.Count > 0 && cell.Controls[0] is CheckBox checkBox && checkBox.Checked)
            {

                string courseCode = row.Cells[0].Text;
                string courseName = row.Cells[1].Text;

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Courses_Offered WHERE Course_Code = @CourseCode";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@CourseCode", courseCode);
                int existingCount = (int)checkCmd.ExecuteScalar();

                if (existingCount == 0)
                {
                    string insertQuery = "INSERT INTO Courses_Offered (Course_Name, Course_Code) VALUES (@CourseName, @CourseCode)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@CourseName", courseName);
                    insertCmd.Parameters.AddWithValue("@CourseCode", courseCode);
                    insertCmd.ExecuteNonQuery();
                }
            }
            else 
            {
                string courseCode = row.Cells[0].Text;

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
                con.Open();

                string q2 = "DELETE FROM Courses_Offered WHERE Course_Code = @Course_Code";
                SqlCommand cm = new SqlCommand(q2, con);
                cm.Parameters.AddWithValue("@Course_Code", courseCode);
                cm.ExecuteNonQuery();

                cm.Dispose();
                con.Close();
            }
        }
    }

    private string DataTableToCsv(DataTable data)
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

    private DataTable FetchDataFromSQLTable()
    {


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        string q = "Select o.Course_Name, o.Course_Code, c.Credit_Hours from Courses_Offered o INNER JOIN Courses c  on o.Course_Code = c.Course_Code where c.Course_Name = o.Course_Name";

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

        // Fetch data from SQL table
        DataTable data = FetchDataFromSQLTable();

        // Generate CSV content from the data
        string csvContent = DataTableToCsv(data);

        // Set response headers for file download
        Response.Clear();
        Response.ContentType = "application/pdf";

        //Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment; filename=Offered_Courses.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
    }
}