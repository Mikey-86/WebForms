using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDropDown();
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            Team TeamObj = new Team();
            TeamObj.Name = txtName.Text;
            TeamObj.DateCreated = txtCreatedDate.Text;
            TeamObj.IsActive = chkActive.Checked;

            HttpClient client = new HttpClient();

            var jsonVariable = JsonConvert.SerializeObject(TeamObj);
            var content = new StringContent(jsonVariable, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://localhost:5000/api/teams", content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Display success message
                    lblWorking.Text = "Data submitted successfully.";
                    lblWorking.BackColor = System.Drawing.Color.YellowGreen;
                    lblWorking.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    // Display error message
                    lblWorking.Text = "Error: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                lblWorking.Text = "Error: " + ex.Message;
            }
        }

        public async void LoadDropDown()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the API endpoint
                    HttpResponseMessage response = await client.GetAsync("https://localhost:5000/api/teams");

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseData = await response.Content.ReadAsStringAsync();

                        List<Team> teamObj = JsonConvert.DeserializeObject<List<Team>>(responseData);
                        
                        foreach (Team team in teamObj)
                        {

                        }
                    }
                    else
                    {
                        // Handle unsuccessful response
                        //lblResult.Text = $"Error: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    //lblResult.Text = $"Error: {ex.Message}";
                }
            }
        }
    }
}