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

public partial class FacultyEvaluation : System.Web.UI.Page
{
    string course_sel;  //course selected
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
        DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);
        //course_sel = DropDownList1.SelectedValue;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
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
        ViewState["SelectedCourse"] = DropDownList1.SelectedValue;

        // Close the SqlDataReader and the SqlConnection
        reader.Close();
        conn.Close();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
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
        ViewState["SelectedSection"] = DropDownList2.SelectedValue;

        // Close the SqlDataReader and the SqlConnection
        reader.Close();
        conn.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Get the selected course and section from the ViewState
        string course = DropDownList1.SelectedValue;
        string section = DropDownList2.SelectedValue;

        // Check if a course and section have been selected
        while (string.IsNullOrEmpty(course) || string.IsNullOrEmpty(section))
        {
            ErrorMessageLabel.Text = "Please select section and course";
            pnlErrorMessage.Visible = true;
            return;
        }

        pnlErrorMessage.Visible = false;

        DataTable dt = new DataTable();
        dt.Columns.Add("Student ID");
        dt.Columns.Add("Student Name");
        dt.Columns.Add("Quizzes");
        dt.Columns.Add("Assignments");
        dt.Columns.Add("Sessional1");
        dt.Columns.Add("Sessional2");
        dt.Columns.Add("Final");

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        List<int> studentIDs = new List<int>();  // for storing every student
        List<string> studentnames = new List<string>(); // for names
        string fn = "";
        string ln = "";
        int id = 0;

        string q1 = "SELECT Student_ID from Student_Courses where Course_Name = @Course_Name and Section = @Section";
        SqlCommand c1 = new SqlCommand(q1, conn);
        c1.Parameters.AddWithValue("@Course_Name", course);
        c1.Parameters.AddWithValue("@Section", section);
        SqlDataReader da1 = c1.ExecuteReader();

        while (da1.Read())
        {
            id = da1.GetInt32(0);
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
        command.ExecuteNonQuery();


        for (int i = 0; i < numValues; i++)
        {
            DataRow dr = dt.NewRow();
            dr["Student ID"] = studentIDs[i];
            dr["Student Name"] = studentnames[i];
            dr["Quizzes"] = 0;
            dr["Assignments"] = 0;
            dr["Sessional1"] = 0;
            dr["Sessional2"] = 0;
            dr["Final"] = 0;
            dt.Rows.Add(dr);

        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        conn.Close();
        course_sel = DropDownList1.SelectedValue;

        //DropDownList1.Items.Clear();
        //DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);

        //DropDownList2.Items.Clear();
        //DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn2.Open();

        string course = DropDownList1.SelectedValue;
        //string course = ViewState["SelectedCourse"] as string;
        //string section = ViewState["SelectedSection"] as string;
        //Debug.Write("SEC 1: ");
        //Debug.WriteLine(section);
        //string course = DropDownList1.SelectedValue;
        Debug.Write("COURSE: ");
        Debug.WriteLine(course);
        string section2 = DropDownList2.SelectedValue;

        Debug.Write("SEC 2: ");
        Debug.WriteLine(section2);

        foreach (GridViewRow row in GridView1.Rows)
        {
            int Student_ID = int.Parse(row.Cells[0].Text.ToString());
            string Student_Name = row.Cells[1].Text;


            string q5 = "Select * from marks_dist where Course = @Course_Name";
            SqlCommand command3 = new SqlCommand(q5, conn2);
            command3.Parameters.AddWithValue("@Course_Name", course);
            SqlDataReader reader = command3.ExecuteReader();

            float q = 0;
            float a = 0;
            float s1 = 0;
            float s2 = 0;
            float f = 0;
            while (reader.Read())
            {
                q = float.Parse(reader.GetValue(2).ToString());
                Debug.Write("QUIZZES: ");
                Debug.WriteLine(q);
                a = float.Parse(reader.GetValue(3).ToString());
                Debug.Write("ASSIGNMENTS: ");
                Debug.WriteLine(a);
                s1 = float.Parse(reader.GetValue(4).ToString());
                Debug.Write("SESSIONAL 1: ");
                Debug.WriteLine(s1);
                s2 = float.Parse(reader.GetValue(5).ToString());
                Debug.Write("SESSIONAL 2: ");
                Debug.WriteLine(s2);
                f = float.Parse(reader.GetValue(6).ToString());
                Debug.Write("FINAL: ");
                Debug.WriteLine(f);
            }
            reader.Close();
            command3.ExecuteNonQuery();

            float quizzes;
            float assignments;
            float sessional1;
            float sessional2;
            float final;

            quizzes = float.Parse(((TextBox)row.FindControl("QuizTextBox")).Text);
            assignments = float.Parse(((TextBox)row.FindControl("AssignmentsTextBox")).Text);
            sessional1 = float.Parse(((TextBox)row.FindControl("Sessional1TextBox")).Text);
            sessional2 = float.Parse(((TextBox)row.FindControl("Sessional2TextBox")).Text);
            final = float.Parse(((TextBox)row.FindControl("FinalTextBox")).Text);
            Debug.WriteLine("Insertion values: ");
            Debug.Write("QUIZZES: ");
            Debug.WriteLine(quizzes);
            Debug.Write("ASSIGNMENTS: ");
            Debug.WriteLine(assignments);
            Debug.Write("SESSIONAL 1: ");
            Debug.WriteLine(sessional1);
            Debug.Write("SESSIONAL 2: ");
            Debug.WriteLine(sessional2);
            Debug.Write("FINAL: ");
            Debug.WriteLine(final);

            //bool b = true;
            //while(b)
            //{
            //    if (quizzes > q)
            //    {
            //        ErrorMessageLabel.Text = "Must be less than total quizzes marks";
            //        pnlErrorMessage.Visible = true;
            //    }

            //    else if (assignments > a)
            //    {
            //        ErrorMessageLabel.Text = "Must be less than total assignments marks";
            //        pnlErrorMessage.Visible = true;
            //    }

            //    else if (sessional1 > s1)
            //    {
            //        ErrorMessageLabel.Text = "Must be less than total sessional 1 marks";
            //        pnlErrorMessage.Visible = true;
            //    }

            //    else if (sessional2 > s2)
            //    {
            //        ErrorMessageLabel.Text = "Must be less than total sessional 2 marks";
            //        pnlErrorMessage.Visible = true;
            //    }

            //    else if (final > f)
            //    {
            //        ErrorMessageLabel.Text = "Must be less than total final marks";
            //        pnlErrorMessage.Visible = true;
            //    }
            // else
            //{
            //pnlErrorMessage.Visible = false;
            Debug.Write("COURSE AT END: ");
            Debug.WriteLine(course);
            string q4 = "IF EXISTS (SELECT * FROM Evaluation WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name) " +
             "UPDATE Evaluation SET quiz = @quiz, assignments = @assignments, sessional1 = @sessional1, " +
             "sessional2 = @sessional2, final = @final WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name " +
             "ELSE INSERT INTO Evaluation(Student_ID,Course_Name,quiz,assignments,sessional1,sessional2,final) " +
             "VALUES (@Student_ID,@Course_Name,@quiz,@assignments,@sessional1,@sessional2,@final)";
            SqlCommand command2 = new SqlCommand(q4, conn2);
            command2.Parameters.AddWithValue("@Student_ID", Student_ID);
            command2.Parameters.AddWithValue("@Course_Name", course);
            command2.Parameters.AddWithValue("@quiz", quizzes);
            command2.Parameters.AddWithValue("@assignments", assignments);
            command2.Parameters.AddWithValue("@sessional1", sessional1);
            command2.Parameters.AddWithValue("@sessional2", sessional2);
            command2.Parameters.AddWithValue("@final", final);
            command2.ExecuteNonQuery();
            Debug.WriteLine("INSERTION COMPLETED");
            //b = false;
            //}
            //}

            DropDownList1.Items.Clear();
            DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);

            DropDownList2.Items.Clear();
            DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);

        }


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
        string q = "Select *, (quiz + assignments + sessional1 + sessional2 + final) as total from Evaluation";

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
        Response.AddHeader("Content-Disposition", "attachment; filename=Evaluation.csv");

        // Write the CSV content to the response stream
        Response.Write(csvContent);
        Response.End();
    }
}