using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;



public partial class Allocate_Courses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
            //DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);
        }
    }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT Course_Name from Courses_Offered";

        SqlCommand command = new SqlCommand(query, conn);
        // Execute the query
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string course_name = reader.GetString(0).ToString();
            DropDownList1.Items.Add(new ListItem(course_name, course_name));
        }

        // Close the SqlDataReader and the SqlConnection
        reader.Close();

        string q2 = "SELECT Faculty_Id from Faculty";
        SqlCommand comm = new SqlCommand(q2, conn);
        // Execute the query
        SqlDataReader reader2 = comm.ExecuteReader();
        while (reader2.Read())
        { 
            int faculty_id = reader2.GetInt32(0);
            DropDownList2.Items.Add(faculty_id.ToString());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //int ID = (int)Session["ID"];

        if (DropDownList3.SelectedValue == "Allocate")
        {
            int faculty = int.Parse(DropDownList2.SelectedValue);
            string course = DropDownList1.SelectedValue;
            string section = DropDownList4.SelectedValue;
            string code = "";

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
            conn.Open();

            string q1 = "SELECT Course_Code from Courses_Offered where Course_Name = @Course_Name";
            SqlCommand command = new SqlCommand(q1, conn);
            command.Parameters.AddWithValue("@Course_Name", course);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               code = reader.GetString(0).ToString();
            }
            reader.Close();
            command.Dispose();

            int num;
            int? NumCourses = null; // initialize to null
            
            string q3 = "Select NumCourses from Faculty where Faculty_ID = @Faculty_ID";
            SqlCommand c3 = new SqlCommand(q3, conn);
            c3.Parameters.AddWithValue("@Faculty_ID", faculty);
            SqlDataReader da = c3.ExecuteReader();

            if (da.Read())
            {
                string value = da.GetValue(0).ToString();

                if (int.TryParse(value, out num))
                {
                    NumCourses = num;
                    Debug.Write("Read: ");
                    Debug.WriteLine(NumCourses);
                }
            }

            da.Close();

            if (NumCourses.HasValue && NumCourses >= 3)
            {
                ErrorMessageLabel.Text = "Number of Courses allocated to Faculty is 3";
                pnlErrorMessage.Visible = true;
            }

            else 
            {
                NumCourses = NumCourses + 1;
                Debug.Write("Incremented : ");
                Debug.WriteLine(NumCourses);

                string q2 = "UPDATE Faculty SET NumCourses = @NumCourses WHERE Faculty_ID = @Faculty_ID";
                SqlCommand c2 = new SqlCommand(q2, conn);
                c2.Parameters.AddWithValue("@NumCourses", NumCourses);
                c2.Parameters.AddWithValue("@Faculty_ID", faculty);
                c2.ExecuteNonQuery();

                string query = "Insert into Faculty_Courses(Faculty_ID,CourseName,CourseCode,Section) values (@Faculty_ID, @CourseName, @CourseCode, @Section)";
                SqlCommand comm = new SqlCommand(query, conn);

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Faculty_ID", faculty);
                cmd.Parameters.AddWithValue("@CourseName", course);
                cmd.Parameters.AddWithValue("@CourseCode", code);
                cmd.Parameters.AddWithValue("@Section", section);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);

            conn.Close();
        }
    }


    //private void GenerateReport()
    //{
    //    // Fetch data from SQL table
    //    DataTable data = FetchDataFromSQLTable();

    //    // Set response headers for file download
    //    Response.Clear();
    //    Response.ContentType = "text/csv";
    //    Response.AddHeader("Content-Disposition", "attachment; filename=report.csv");

    //    // Write the CSV content to the response
    //    StringBuilder csvBuilder = new StringBuilder();
    //    foreach (DataRow row in data.Rows)
    //    {
    //        csvBuilder.AppendLine(string.Format("{0},{1},{2},{3},{4},{5}", row["CourseCode"], row["CourseName"], row["CHs"], row["Section"], row["Instructor"], row["Coordinator"]));
    //    }
    //    Response.Write(csvBuilder.ToString());
    //    Response.End();
    //}

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
        string q = "Select fc.CourseCode, fc.CourseName,c.Credit_Hours, fc.Section, concat(u.FirstName, ' ', u.LastName) as Instructor From Faculty_Courses fc INNER JOIN Courses c on c.Course_Code = fc.CourseCode INNER JOIN Users u on u.User_ID = fc.Faculty_ID";

        using (SqlCommand command = new SqlCommand(q, con))
        {
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
        Response.AddHeader("Content-Disposition", "attachment; filename=AllocatedCourses.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
        Response.End();

    }
}