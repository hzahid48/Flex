using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Course_registration : System.Web.UI.Page
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

        string query = "SELECT Count(Course_Code) from Courses_Offered";
        SqlCommand command = new SqlCommand(query, conn);
   
        int numValues = (int)command.ExecuteScalar();

        query = "SELECT Course_Name, Course_Code from Courses_Offered";
        command = new SqlCommand(query, conn);
        SqlDataReader da = command.ExecuteReader();

        for (int i = 0; i < numValues; i++)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();

            cell2.HorizontalAlign = HorizontalAlign.Center;
            cell3.HorizontalAlign = HorizontalAlign.Center;

            if (da.Read())
            {
                cell1.Text = da.GetValue(1).ToString();
                cell2.Text = da.GetValue(0).ToString();
                cell3.Controls.Add(new CheckBox());
            }

            System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label();
            label.Text = cell2.Text;
            cell2.Controls.Add(label);

          
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            Table1.Rows.Add(row);
        }

        da.Close();
        conn.Close();

       
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        int ID = (int)Session["ID"];
        char section = ' ';
        int numCourses = 0;

        SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        con2.Open();
       
        string q5= "Select Section from Students where Student_ID = @Student_ID";
        SqlCommand cm5 = new SqlCommand(q5, con2);
        cm5.Parameters.AddWithValue("@Student_ID", ID);
        SqlDataReader reader5 = cm5.ExecuteReader();


        if (reader5.Read())
        {
            string sec = reader5.GetValue(0).ToString();
            section = Convert.ToChar(sec);
        }
        
        Debug.Write("Section: ");
        Debug.WriteLine(section);

        reader5.Close();
        cm5.ExecuteNonQuery();
        con2.Close();

        foreach (TableRow row in Table1.Rows)
        {
            TableCell cell = row.Cells[2];
            pnlErrorMessage.Visible = false;

            if (cell.Controls.Count > 0 && cell.Controls[0] is CheckBox checkBox && checkBox.Checked)
            {
                string courseCode = row.Cells[0].Text;
                string courseName = row.Cells[1].Text;

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
                con.Open();



                string q7 = "SELECT COUNT(*) FROM Student_Courses WHERE Student_ID = @Student_ID";
                SqlCommand cm7 = new SqlCommand(q7, con);
                cm7.Parameters.AddWithValue("@Student_ID", ID);
                numCourses = (int)cm7.ExecuteScalar();

                if(numCourses < 6)
                {
                    string pre_req = "";
                    string q1 = "Select Pre_Req from Courses where Course_Name = @Course_Name";
                    SqlCommand cm2 = new SqlCommand(q1, con);
                    cm2.Parameters.AddWithValue("@Course_Name", courseName);

                    SqlDataReader reader = cm2.ExecuteReader();
                    if (reader.Read())
                    {
                        pre_req = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                    cm2.ExecuteNonQuery();

                    if (pre_req == "")
                    {
                        string q4 = "SELECT CASE WHEN EXISTS (SELECT Course_Name FROM Student_Courses WHERE Course_Name = @Course_Name AND Student_ID = @Student_ID) THEN 1 ELSE 0 END";
                        SqlCommand cm4 = new SqlCommand(q4, con);
                        cm4.Parameters.AddWithValue("@Course_Name", courseName);
                        cm4.Parameters.AddWithValue("@Student_ID", ID);
                        int res = (int)cm4.ExecuteScalar();
                        if (res == 0)
                        {
                            string q2 = "Insert into Student_Courses(Student_ID,Course_Name,CourseCode,Section) values (@Student_ID,@Course_Name,@CourseCode,@Section)";
                            SqlCommand cm = new SqlCommand(q2, con);
                            cm.Parameters.AddWithValue("@Student_ID", ID);
                            cm.Parameters.AddWithValue("@Course_Name", courseName);
                            cm.Parameters.AddWithValue("@CourseCode", courseCode);
                            cm.Parameters.AddWithValue("@Section", section);
                            cm.ExecuteNonQuery();
                            cm.Dispose();
                        }
                        else
                        {
                            ErrorMessageLabel.Text = "Already registered for the course";
                            pnlErrorMessage.Visible = true;
                        }
                    }
                    else
                    {
                        string q3 = "SELECT CASE WHEN EXISTS (SELECT Course_Name FROM Transcript WHERE Course_Name = @Pre_req AND Student_ID = @Student_ID) THEN 1 ELSE 0 END";
                        SqlCommand cm3 = new SqlCommand(q3, con);
                        cm3.Parameters.AddWithValue("@Pre_req", pre_req);
                        cm3.Parameters.AddWithValue("@Student_ID", ID);
                        int result = (int)cm3.ExecuteScalar();

                        if (result == 0)
                        {
                            ErrorMessageLabel.Text = "Pre_Requisite not cleared";
                            pnlErrorMessage.Visible = true;
                        }
                        else
                        {
                            string q4 = "SELECT CASE WHEN EXISTS (SELECT Course_Name FROM Student_Courses WHERE Course_Name = @Course_Name AND Student_ID = @Student_ID) THEN 1 ELSE 0 END";
                            SqlCommand cm4 = new SqlCommand(q4, con);
                            cm4.Parameters.AddWithValue("@Course_Name", courseName);
                            cm4.Parameters.AddWithValue("@Student_ID", ID);
                            int res = (int)cm4.ExecuteScalar();

                            if (res == 0)
                            {
                                Debug.Write("Near END Section: ");
                                Debug.WriteLine(section);
                                string q2 = "Insert into Student_Courses(Student_ID,Course_Name,CourseCode,Section) values (@Student_ID,@Course_Name,@CourseCode,@Section)";
                                SqlCommand cm = new SqlCommand(q2, con);
                                cm.Parameters.AddWithValue("@Student_ID", ID);
                                cm.Parameters.AddWithValue("@Course_Name", courseName);
                                cm.Parameters.AddWithValue("@CourseCode", courseCode);
                                cm.Parameters.AddWithValue("@Section", section);
                                cm.ExecuteNonQuery();
                                cm.Dispose();
                            }
                            else
                            {
                                ErrorMessageLabel.Text = "Already registered for the course";
                                pnlErrorMessage.Visible = true;
                            }


                        }
                    }

                }
                else
                {
                    ErrorMessageLabel.Text = "You cannot register for more than 6 courses";
                    pnlErrorMessage.Visible = true;
                }
                 
               
              
                con.Close();
            }
        }
    }
}