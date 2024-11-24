using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class S_marks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ID = (int)Session["ID"];
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT DISTINCT Course_Name from Student_Courses where Student_ID = @Student_ID";

        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Student_ID", ID);

        // Execute the query
        SqlDataReader reader = command.ExecuteReader();
        DropDownList1.Items.Add(new ListItem("Select Course", ""));
        while (reader.Read())
        {
            string course_name = reader.GetString(0).ToString();
            DropDownList1.Items.Add(new ListItem(course_name, course_name));
        }

        // Close the SqlDataReader and the SqlConnection
        reader.Close();
        conn.Close();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        int ID = (int)Session["ID"];
        float q, a, s1, s2, f, o = 0;
        string total = "100";

        using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True"))
        {
            // Open the connection
            conn.Open();
            string course = DropDownList1.SelectedValue;

            string query = "SELECT * from Evaluation where Course_Name = @Course_Name AND Student_ID = Student_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Course_Name", course);
            cmd.Parameters.AddWithValue("@Student_ID", ID);

            

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if there are any rows returned
                if (reader.HasRows && reader.Read())
                {
                    QuizzesLabel.Text = reader.GetValue(2).ToString();
                    q = float.Parse(reader.GetValue(2).ToString());
                    QuizzesLabel.Style["text-align"] = "center";

                    AssignmentsLabel.Text = reader.GetValue(3).ToString();
                    a = float.Parse(reader.GetValue(3).ToString());
                    AssignmentsLabel.Style["text-align"] = "center";

                    Sessional1Label.Text = reader.GetValue(4).ToString();
                    s1 = float.Parse(reader.GetValue(4).ToString());
                    Sessional1Label.Style["text-align"] = "center";

                    Sessional2Label.Text = reader.GetValue(5).ToString();
                    s2 = float.Parse(reader.GetValue(5).ToString());
                    Sessional2Label.Style["text-align"] = "center";

                    FinalLabel.Text = reader.GetValue(6).ToString();
                    f = float.Parse(reader.GetValue(6).ToString());
                    FinalLabel.Style["text-align"] = "center";

                    o = q + a + s1 + s2 + f;
                    ObtainedLabel.Text = o.ToString();
                    ObtainedLabel.Style["text-align"] = "center";

                    TotalLabel.Text = total;
                    TotalLabel.Style["text-align"] = "center";

                }
            }

            char grade = ' ';
            float gpa = 0;
            string q4 = "Select Grade, GPA from Grade where Min_Marks <= @per AND Max_Marks >= @per";
            SqlCommand cmd2 = new SqlCommand(q4, conn);
            cmd2.Parameters.AddWithValue("@per", o);
            SqlDataReader da = cmd2.ExecuteReader();
            if(da.Read())
            {
                string gr = da.GetValue(0).ToString();
                grade = gr[0];
                gpa = float.Parse(da.GetValue(1).ToString());

            }

            da.Close();
            cmd2.Dispose();


            string checkQuery = "IF EXISTS(SELECT * FROM Transcript WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name) " +
                     "BEGIN " +
                     "UPDATE Transcript SET Grade = @Grade, GPA = @GPA WHERE Student_ID = @Student_ID AND Course_Name = @Course_Name " +
                     "END " +
                     "ELSE " +
                     "BEGIN " +
                     "INSERT INTO Transcript(Student_ID, Course_Name, Grade, GPA) VALUES (@Student_ID, @Course_Name, @Grade, @GPA) " +
                     "END";
            SqlCommand cmd3 = new SqlCommand(checkQuery, conn);
            cmd3.Parameters.AddWithValue("@Student_ID", ID);
            cmd3.Parameters.AddWithValue("@Course_Name", course);
            cmd3.Parameters.AddWithValue("@Grade", grade);
            cmd3.Parameters.AddWithValue("@GPA", gpa);
            cmd3.ExecuteNonQuery();
        }

        DropDownList1.Items.Clear();
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
    }
}