using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacultyGrades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateRows();
    }

    protected void GenerateRows()
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT Count(*) from Grade";
        SqlCommand command = new SqlCommand(query, conn);

        int numValues = (int)command.ExecuteScalar();

        query = "SELECT * from Grade";
        command = new SqlCommand(query, conn);
        SqlDataReader da = command.ExecuteReader();

        for (int i = 0; i < numValues; i++)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();

            //cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell2.HorizontalAlign = HorizontalAlign.Center;
            cell3.HorizontalAlign = HorizontalAlign.Center;
            cell4.HorizontalAlign = HorizontalAlign.Center;


            if (da.Read())
            {
                cell1.Text = da.GetValue(0).ToString();
                cell2.Text = da.GetValue(1).ToString();
                cell3.Text = da.GetValue(2).ToString();
                cell4.Text = da.GetValue(3).ToString();
            }


            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            Table1.Rows.Add(row);
        }

        da.Close();
        conn.Close();


        SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn2.Open();

        string query1 = "SELECT Count(Student_ID) from S_Att where Student_ID = @Student_ID AND Course_Name = @Course_Name ";

        SqlCommand command2 = new SqlCommand(query1, conn2);
        command2.Parameters.AddWithValue("@Student_ID", 4);
        command2.Parameters.AddWithValue("@Course_Name", "OOP");

        int numValues2 = (int)command2.ExecuteScalar();
        Debug.Write("num Values: ");
        Debug.WriteLine(numValues2);

        conn2.Close();

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
        string q = "Select u.User_ID, concat(u.FirstName,' ',u.LastName) as Student_Name , s.Section,(e.quiz + e.assignments + e.sessional1 + e.sessional2 + e.final) as Marks, t.Grade\r\nfrom Users u INNER JOIN Transcript t on t.Student_ID = u.User_ID  INNER JOIN Evaluation e on e.Course_Name = t.Course_Name INNER JOIN Students s on S.Student_ID = u.User_ID where t.Course_Name = 'Data Structures'";

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Fetch data from SQL table
        DataTable data = FetchDataFromSQLTable();

        // Generate CSV content from the data
        string csvContent = DataTableToCsv(data);

        // Set response headers for file download
        Response.Clear();
        Response.ContentType = "application/pdf";

        //Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment; filename=Grade.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
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
        string q = "select Grade, COUNT(*) as GradeCount from Transcript Group by Grade";

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
        DataTable data = FetchDataFromSQLTable2();

        // Generate CSV content from the data
        string csvContent = DataTableToCsv2(data);

        // Set response headers for file download
        Response.Clear();
        Response.ContentType = "application/pdf";

        //Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment; filename=CountGrade.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
    }
}