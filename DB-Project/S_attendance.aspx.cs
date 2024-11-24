using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class S_attendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DropDownList1.Items.Clear();
            DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
        }
    }

    string course2;

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
        //DropDownList1.Items.Clear();
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

    protected void Button2_Click(object sneder, EventArgs e)
    {
        string course = DropDownList1.SelectedValue;
        // string course = (string)ViewState["SelectedCourse"];
        course2 = course;
         int ID = (int)Session["ID"];


        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string query = "SELECT Count(Student_ID) from S_Att where Student_ID = @Student_ID AND Course_Name = @Course_Name ";

        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Student_ID", ID);
        Debug.Write("ID: ");
        Debug.WriteLine(ID);
        command.Parameters.AddWithValue("@Course_Name", course);
        Debug.Write("Course : ");
        Debug.WriteLine(course);
        Debug.Write("Course 2 : ");
        Debug.WriteLine(course2);

        int numValues = (int)command.ExecuteScalar();
        Debug.Write("num Values: ");
        Debug.WriteLine(numValues);

        query = "SELECT Lecture_Date, Attendance from S_Att where Student_ID = @Student_ID AND Course_Name = @Course_Name  ORDER BY Lecture_Date ASC";
        command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Student_ID", ID);
        command.Parameters.AddWithValue("@Course_Name", course);
        SqlDataReader da = command.ExecuteReader();

        for (int i = 0; i < numValues; i++)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();

            cell1.HorizontalAlign = HorizontalAlign.Center;
            cell2.HorizontalAlign = HorizontalAlign.Center;


            if (da.Read())
            {
                cell1.Text = DateTime.Parse(da.GetValue(0).ToString()).ToString("yyyy-MM-dd");
                cell2.Text = da.GetValue(1).ToString();
            }


            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            Table1.Rows.Add(row);
        }

        da.Close();
        conn.Close();

        DropDownList1.Items.Clear();
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);


    }


}