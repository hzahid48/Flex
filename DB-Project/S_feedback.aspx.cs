using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class S_feedback : System.Web.UI.Page
{
    string cn;
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
        TextBox1_TextChanged(null, EventArgs.Empty);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        int ID = (int)Session["ID"];
        string query = "SELECT Course_Name from Student_Courses where Student_ID = @ID";
       
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@ID", ID);
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



    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        //string name = "AB";
        // int ID = int.Parse(Request.QueryString["ID"]);
        int ID = (int)Session["ID"];
        SqlCommand cmd = new SqlCommand("Select FirstName,LastName from Users where User_ID = @ID", conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        SqlDataReader da = cmd.ExecuteReader();
        while (da.Read())
        {
            TextBox1.Text = da.GetValue(0).ToString();
            TextBox2.Text = da.GetValue(1).ToString();
        }
        conn.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;

        int ID = (int)Session["ID"];
        string n = "RadioButton";
        int j = 1;
         
        for (int i = 1; i < Table1.Rows.Count; i++)
        {
            // Skip the first row, which contains the header
            TableRow row = Table1.Rows[i];
                // Get the radio button in each column
                RadioButton rb1 = (RadioButton)row.Cells[1].FindControl("RadioButton" +j.ToString());
                j++;
                RadioButton rb2 = (RadioButton)row.Cells[2].FindControl("RadioButton" + j.ToString());
                j++;
                RadioButton rb3 = (RadioButton)row.Cells[3].FindControl("RadioButton" + j.ToString());
                j++;
                RadioButton rb4 = (RadioButton)row.Cells[4].FindControl("RadioButton" + j.ToString());
                j++;
                RadioButton rb5 = (RadioButton)row.Cells[5].FindControl("RadioButton" + j.ToString());
                j++;

                // Check which radio button is selected in each column
                if (rb1.Checked)
                    count1++;
                else if (rb2.Checked)
                    count2++;
                else if (rb3.Checked)
                    count3++;
                else if (rb4.Checked)
                    count4++;
                else if (rb5.Checked)
                    count5++;
            
        }

        for (int i = 1; i < Table2.Rows.Count; i++)
        {
            // Skip the first row, which contains the header
            TableRow row = Table2.Rows[i];
            // Get the radio button in each column
            RadioButton rb1 = (RadioButton)row.Cells[1].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb2 = (RadioButton)row.Cells[2].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb3 = (RadioButton)row.Cells[3].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb4 = (RadioButton)row.Cells[4].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb5 = (RadioButton)row.Cells[5].FindControl("RadioButton" + j.ToString());
            j++;

            // Check which radio button is selected in each column
            if (rb1.Checked)
                count1++;
            else if (rb2.Checked)
                count2++;
            else if (rb3.Checked)
                count3++;
            else if (rb4.Checked)
                count4++;
            else if (rb5.Checked)
                count5++;

        }

        for (int i = 1; i < Table3.Rows.Count; i++)
        {
            // Skip the first row, which contains the header
            TableRow row = Table3.Rows[i];
            // Get the radio button in each column
            RadioButton rb1 = (RadioButton)row.Cells[1].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb2 = (RadioButton)row.Cells[2].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb3 = (RadioButton)row.Cells[3].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb4 = (RadioButton)row.Cells[4].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb5 = (RadioButton)row.Cells[5].FindControl("RadioButton" + j.ToString());
            j++;

            // Check which radio button is selected in each column
            if (rb1.Checked)
                count1++;
            else if (rb2.Checked)
                count2++;
            else if (rb3.Checked)
                count3++;
            else if (rb4.Checked)
                count4++;
            else if (rb5.Checked)
                count5++;

        }

        for (int i = 1; i < Table4.Rows.Count; i++)
        {
            // Skip the first row, which contains the header
            TableRow row = Table4.Rows[i];
            // Get the radio button in each column
            RadioButton rb1 = (RadioButton)row.Cells[1].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb2 = (RadioButton)row.Cells[2].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb3 = (RadioButton)row.Cells[3].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb4 = (RadioButton)row.Cells[4].FindControl("RadioButton" + j.ToString());
            j++;
            RadioButton rb5 = (RadioButton)row.Cells[5].FindControl("RadioButton" + j.ToString());
            j++;

            // Check which radio button is selected in each column
            if (rb1.Checked)
                count1++;
            else if (rb2.Checked)
                count2++;
            else if (rb3.Checked)
                count3++;
            else if (rb4.Checked)
                count4++;
            else if (rb5.Checked)
                count5++;

        }



        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string comment = TextBox3.Text;
        string course = DropDownList1.SelectedValue;
        string query = "Insert into feed(Student_ID,Course_Name, Val1, Val2,Val3, Val4,Val5,Comment) values (@Student_ID,@Course_Name, @Val1,@Val2, @Val3, @Val4, @Val5,@Comment)";
        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Student_ID", ID);
        cmd.Parameters.AddWithValue("@Course_Name",course);
        cmd.Parameters.AddWithValue("@Val1", count1);
        Debug.WriteLine(count1);
        cmd.Parameters.AddWithValue("@Val2", count2);
        Debug.WriteLine(count2);
        cmd.Parameters.AddWithValue("@Val3", count3);
        Debug.WriteLine(count3);
        cmd.Parameters.AddWithValue("@Val4", count4);
        Debug.WriteLine(count4);
        cmd.Parameters.AddWithValue("@Val5", count5);
        Debug.WriteLine(count5);
        cmd.Parameters.AddWithValue("@Comment", comment);

        cmd.ExecuteNonQuery();


        DropDownList1.Items.Clear();
        DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);
        conn.Close();

    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
    }
}