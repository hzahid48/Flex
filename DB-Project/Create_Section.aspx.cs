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

public partial class Create_Section : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //char sec = 'A';
    protected void Button1_Click(object sender, EventArgs e)
    {

        //int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        int min_st = 2;
        int max_st = 4;
        char sec = 'A';
        int st_count = 0;

        string query = "SELECT COUNT(Student_ID) from Students";
        SqlCommand command = new SqlCommand(query, conn);
        int numStudents = (int)command.ExecuteScalar();

        Debug.Write("Num students: ");
        Debug.WriteLine(numStudents);

        int num_sec = (int)Math.Ceiling((double)numStudents / max_st);
        Debug.Write("Num sections: ");
        Debug.WriteLine(num_sec);
        int rem = numStudents;

        string q1 = "UPDATE Students SET Section = NULL";
        SqlCommand commandUpdate2 = new SqlCommand(q1, conn);
        commandUpdate2.ExecuteNonQuery();

        for (int i = 0; i < num_sec; i++)
        {
            Debug.Write("Section: ");
            Debug.WriteLine(sec);

            int student_count = Math.Min(max_st, numStudents - st_count);
            Debug.Write("Student count: ");
            Debug.WriteLine(student_count);

            if (student_count < min_st) // check if remaining students are less than the minimum required for a section
            {
                break;
            }

           

            string queryUpdate = "UPDATE Students SET Section = @Section WHERE Student_ID IN (SELECT TOP " + student_count + " Student_ID FROM Students WHERE Section IS NULL ORDER BY Student_ID)";
            SqlCommand commandUpdate = new SqlCommand(queryUpdate, conn);
            commandUpdate.Parameters.AddWithValue("@Section", sec);
            commandUpdate.ExecuteNonQuery();

            if ((numStudents - st_count) > 6)
            {
                sec++; // go to the next section
                st_count += student_count; // update the number of students assigned to sections
            }
            rem -= st_count;
            Debug.Write("Rem: ");
            Debug.WriteLine(rem);
        }

        Debug.Write("Section after loop: ");
        Debug.WriteLine(sec);

        // Update any remaining students to a new section
        if(rem >= min_st)
        {
            string queryUpdateRemaining = "UPDATE Students SET Section = @Section WHERE Section IS NULL";
            SqlCommand commandUpdateRemaining = new SqlCommand(queryUpdateRemaining, conn);
            commandUpdateRemaining.Parameters.AddWithValue("@Section", sec.ToString());
            commandUpdateRemaining.ExecuteNonQuery();

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
        string q = "Select concat(u.FirstName, ' ', u.LastName) as Student_Name, s.Student_ID, s.Section from Users u INNER JOIN Students s  on s.Student_ID = u.User_ID where s.Section = 'A'";

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

    protected void Button2_Click1(object sender, EventArgs e)
    {
        // Fetch data from SQL table
        DataTable data = FetchDataFromSQLTable();

        // Generate CSV content from the data
        string csvContent = DataTableToCsv(data);

        // Set response headers for file download
        Response.Clear();
        Response.ContentType = "application/pdf";

        //Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment; filename=Sections.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
    }
}