using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacultyMarksDist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
       // Button2_Click(null, EventArgs.Empty);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT CourseName from Faculty_Courses where Faculty_ID = @Faculty_ID";

        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Faculty_ID", ID);

        // Execute the query
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string course_name = reader.GetString(0).ToString();

            DropDownList1.Items.Add(new ListItem(course_name, course_name));
        }

        // Close the SqlDataReader and the SqlConnection
        reader.Close();
        conn.Close();

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string q = QuizzesTextBox.Text;
        string a = AssignmentsTextBox.Text;
        string s1 = Sessional1TextBox.Text;
        string s2 = Sessional2TextBox.Text;
        string f = FinalTextBox.Text;
        string course = DropDownList1.SelectedValue;

        int quiz = int.Parse(q);
        int assignment = int.Parse(a);
        int mid1 = int.Parse(s1);
        int mid2 = int.Parse(s2);
        int final = int.Parse(f);

        int total = quiz + assignment + mid1 + mid2 + final;
        if( total != 100)
        {
            ErrorMessageLabel.Text = "Total Marks must be 100";
            pnlErrorMessage.Visible = true;
        }
        if (total == 100)
        {
            pnlErrorMessage.Visible = false;
            //string query = "INSERT into marks_dist(Faculty_ID,Course,Quizzes,Assignments,Sessional1,Sessional2,Final) VALUES ('" + ID + "', '" + course + "', '" + q + "','" + a + "','" + s1 + "','" + s2 + "','" + f + "')";
            //SqlCommand cmd = new SqlCommand(query, conn);

            //cmd.ExecuteNonQuery();
            //cmd.Dispose();

            string query = "IF EXISTS(SELECT 1 FROM marks_dist WHERE Course = @Course) " +
               "BEGIN " +
               "UPDATE marks_dist SET Quizzes = @Quizzes, Assignments = @Assignments, Sessional1 = @Sessional1, Sessional2 = @Sessional2, Final = @Final " +
               "WHERE Course = @Course " +
               "END " +
               "ELSE " +
               "BEGIN " +
               "INSERT INTO marks_dist(Faculty_ID,Course,Quizzes,Assignments,Sessional1,Sessional2,Final) " +
               "VALUES (@Faculty_ID, @Course, @Quizzes, @Assignments, @Sessional1, @Sessional2, @Final) " +
               "END";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Faculty_ID", ID);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.Parameters.AddWithValue("@Quizzes", quiz);
            cmd.Parameters.AddWithValue("@Assignments", assignment);
            cmd.Parameters.AddWithValue("@Sessional1", mid1);
            cmd.Parameters.AddWithValue("@Sessional2", mid2);
            cmd.Parameters.AddWithValue("@Final", final);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }

        DropDownList1.Items.Clear();
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
        conn.Close();
    }

 }