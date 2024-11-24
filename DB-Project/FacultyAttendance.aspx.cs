using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices.CompensatingResourceManager;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

public partial class FacultyAttendance : System.Web.UI.Page
{

    string course2;
    //string section;
    int s_id = 0;
    int student_id;
    string prev;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();

            DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
            DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);
        }

    }

    protected void Button2_Click(object sneder, EventArgs e)
    {
        string course = DropDownList1.SelectedValue;
        string section = DropDownList2.SelectedValue;
        prev = course;

        DataTable dt = new DataTable();
        dt.Columns.Add("Student ID");
        dt.Columns.Add("Student Name");
        dt.Columns.Add("Attendance");

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        List<int> studentIDs = new List<int>();  // for storing every student
        List<string> studentnames = new List<string>(); // for names
        //List<Student> students = new List<Student>();
        string fn = "";
        string ln = "";
        int id = 0;
        course2 = course;

        string q1 = "SELECT Student_ID from Student_Courses where Course_Name = @Course_Name and Section = @Section";
        SqlCommand c1 = new SqlCommand(q1, conn);
        c1.Parameters.AddWithValue("@Course_Name", course);
        c1.Parameters.AddWithValue("@Section", section);
        SqlDataReader da1 = c1.ExecuteReader();

        while (da1.Read())
        {
            id = da1.GetInt32(0);
            student_id = id;
            s_id = id;
            studentIDs.Add(id);
            SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
            conn2.Open();
            string q2 = "SELECT FirstName,LastName from Users where User_ID = @User_ID";
            SqlCommand c2 = new SqlCommand(q2, conn2);
            c2.Parameters.AddWithValue("@User_ID", id);
            SqlDataReader da2 = c2.ExecuteReader();

            while (da2.Read())
            {
                fn = da2.GetValue(0).ToString();
                ln = da2.GetValue(1).ToString();
                string fullname = fn + " " + ln;
                studentnames.Add(fullname);
                //students.Add(new Student { ID = id, Name = fullname});
            }

            da2.Close();
            conn2.Close();
        }

        da1.Close();

        string query = "SELECT COUNT(*) from Student_Courses where Course_Name = @Course_Name and Section = @Section";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Course_Name", course);
        command.Parameters.AddWithValue("@Section", section);
        int numValues = (int)command.ExecuteScalar();

        for (int i = 0; i < numValues; i++)
        {
            DataRow dr = dt.NewRow();
            dr["Student ID"] = studentIDs[i];
            dr["Student Name"] = studentnames[i];
            dr["Attendance"] = false;
            dt.Rows.Add(dr);
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();

        //DropDownList1.Items.Clear();
        //DropDownList2.Items.Clear();
        //DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
        //DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string course = DropDownList1.SelectedValue;
        string section = DropDownList2.SelectedValue;
        prev = course;

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        DateTime lecture_date = DateTime.Now;

        foreach (GridViewRow row in GridView1.Rows)
        {
            int Student_ID = int.Parse(row.Cells[0].Text.ToString());
            string name = row.Cells[1].Text;
            bool att = ((CheckBox)row.FindControl("AttendanceCheckBox")).Checked;
            char attendance;


            if (att == true)
            {
                attendance = 'P';
            }
            else
            {
                attendance = 'A';
            }

            //string checkQuery = "SELECT COUNT(*) FROM S_Att WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name AND Lecture_Date = @Lecture_Date";
            //SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            //checkCmd.Parameters.AddWithValue("@Student_ID", Student_ID);
            //checkCmd.Parameters.AddWithValue("@Course_Name", course);
            //checkCmd.Parameters.AddWithValue("@Lecture_Date", DateTime.Now.Date);
            //int existingCount = (int)checkCmd.ExecuteScalar();

            //System.Diagnostics.Debug.WriteLine("Student_ID: " + Student_ID + ", attendance: " + attendance);

            //if (existingCount > 0)
            //{
            //    string updateQuery = "UPDATE S_Att SET Attendance = @check WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name";
            //    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
            //    updateCmd.Parameters.AddWithValue("@Student_ID", Student_ID);
            //    updateCmd.Parameters.AddWithValue("@check", attendance);
            //    updateCmd.Parameters.AddWithValue("@Course_Name", course);
            //    updateCmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    string insertQuery = "INSERT INTO S_Att(Student_ID, Course_Name, Attendance, Lecture_Date) VALUES (@Student_ID, @Course_Name, @Attendance, @Lecture_Date) ";
            //    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
            //    insertCmd.Parameters.AddWithValue("@Student_ID", Student_ID);
            //    insertCmd.Parameters.AddWithValue("@Course_Name", course);
            //    insertCmd.Parameters.AddWithValue("@Attendance", attendance);
            //    insertCmd.Parameters.AddWithValue("@Lecture_Date", lecture_date);
            //    insertCmd.ExecuteNonQuery();
            //}

            string query = "IF EXISTS (SELECT * FROM S_Att WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name) " +
               "BEGIN " +
               "UPDATE S_Att SET Attendance = @check WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name " +
               "END " +
               "ELSE " +
               "BEGIN " +
               "INSERT INTO S_Att(Student_ID, Course_Name, Attendance, Lecture_Date) VALUES (@Student_ID, @Course_Name, @Attendance, @Lecture_Date) " +
               "END ";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Student_ID", Student_ID);
            command.Parameters.AddWithValue("@Course_Name", prev);
            command.Parameters.AddWithValue("@Attendance", attendance);
            command.Parameters.AddWithValue("@Lecture_Date", lecture_date);
            command.Parameters.AddWithValue("@check", attendance);
            command.ExecuteNonQuery();

          
        }

        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
        DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);


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

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList2.Items.Clear(); // Clear DropDownList2 before adding items
        int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT DISTINCT Section from Faculty_Courses where Faculty_ID = @Faculty_ID";

        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Faculty_ID", ID);

        // Execute the query
        DropDownList2.Items.Add(new ListItem("Select Section", ""));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string section = reader.GetString(0).ToString();
            DropDownList2.Items.Add(new ListItem(section, section));
        }

        // Store the selected section in the ViewState
        //ViewState["SelectedSection"] = DropDownList2.SelectedValue;

        // Close the SqlDataReader and the SqlConnection
        reader.Close();
        conn.Close();
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
        string q = "SELECT CONCAT(u.FirstName, ' ', u.LastName) AS Student_Name, u.User_ID as Student_ID, c.Course_Name, COUNT(CASE WHEN a.Course_Name = 'PF' THEN 1 ELSE NULL END) AS Total_Attendance, COUNT(CASE WHEN a.Attendance = 'P' THEN 1 ELSE NULL END) /  COUNT(CASE WHEN a.Course_Name = 'PF' THEN 1 ELSE NULL END) * 100 AS Attendance_Percentage FROM Users u INNER JOIN S_Att a ON a.Student_ID = u.User_ID INNER JOIN Courses c ON c.Course_Name = a.Course_Name where a.Course_Name = 'PF' GROUP BY u.User_ID, c.Course_Name, u.FirstName, u.LastName;";

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
    protected void Button4_Click(object sender, EventArgs e)
    {
        // Fetch data from SQL table
        DataTable data = FetchDataFromSQLTable();

        // Generate CSV content from the data
        string csvContent = DataTableToCsv(data);

        // Set response headers for file download
        Response.Clear();
        Response.ContentType = "application/pdf";

        //Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment; filename=F_Attendance.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
    }
}


