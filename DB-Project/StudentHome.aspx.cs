using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox2_TextChanged(null, EventArgs.Empty);

        if (!IsPostBack)
        {
            // Retrieve the last bar data from the SQL table
            int ID = (int)Session["ID"];
            SqlConnection connectionString = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");

            connectionString.Open();
        
            string query = "SELECT Count(*) from Transcript where Student_ID = @Student_ID";
            SqlCommand command = new SqlCommand(query, connectionString);
            command.Parameters.AddWithValue("@Student_ID", ID);
            float barData = 0;
            int numValues = (int)command.ExecuteScalar();
            float sum = 0;

            query = "SELECT SUM(GPA) from Transcript where Student_ID = @Student_ID";
            command = new SqlCommand(query, connectionString);
            command.Parameters.AddWithValue("@Student_ID", ID);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                sum = (float)reader.GetDouble(0);
            }
            
            barData = sum / numValues;

            Debug.WriteLine(barData);

            // Use the retrieved bar data to update the chart
            string script = $@"
            var sgpaData = [3.2, 3.4, 3.0, {barData}];
            var ctx = document.getElementById('sgpaChart').getContext('2d');
            var chart = new Chart(ctx, {{
                type: 'bar',
                data: {{
                    labels: ['Fall 2021', 'Spring 2022', 'Fall 2022', 'Spring 2023'],
                    datasets: [{{
                        label: 'SGPA',
                        data: sgpaData,
                        backgroundColor: ['rgba(54, 162, 235, 0.5)', 'rgba(255, 99, 132, 0.5)', 'rgba(75, 192, 192, 0.5)', 'rgba(153, 102, 255, 0.5)'],
                        borderColor: 'rgba(54, 162, 235, 1)',
                        borderWidth: 1
                    }}]
                }},
                options: {{
                    scales: {{
                        y: {{
                            beginAtZero: true,
                            suggestedMax: 4
                        }}
                    }}
                }}
            }});
        ";

            ScriptManager.RegisterStartupScript(this, GetType(), "ChartScript", script, true);
        }
    }


    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

       //Label2.Font.Bold = true;
       //Label3.Font.Bold = true;
       //Label10.Font.Bold = true;
       //Label5.Font.Bold = true;
       //Label6.Font.Bold = true;
       //Label8.Font.Bold = true;
       //Label9.Font.Bold = true;
        //string name = "AB";
        // int ID = int.Parse(Request.QueryString["ID"]);
        int ID = (int)Session["ID"];
        SqlCommand cmd = new SqlCommand("Select * from Users where User_ID = @ID", conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        SqlDataReader da = cmd.ExecuteReader();
        while (da.Read())
        {
            Label11.Text = ID.ToString();
            Label12.Text = da.GetValue(5).ToString();
            //Label13.Text = da.GetValue(1).ToString();
            Label14.Text = da.GetValue(3).ToString();
            Label15.Text = da.GetValue(4).ToString();
            Label16.Text = da.GetValue(1).ToString();
            Label17.Text = da.GetValue(6).ToString();

        }
        da.Close();
        SqlCommand cmd2 = new SqlCommand("Select Section from Students where Student_ID = @ID", conn);
        cmd2.Parameters.AddWithValue("@ID", ID);
        SqlDataReader da2 = cmd2.ExecuteReader();

        if (da2.Read())
        {
            Label13.Text = da2.GetValue(0).ToString();
            //TextBox6.Text = da.GetValue(3).ToString();
            da2.Close(); // close the second data reader
        }
        conn.Close();
    }
}