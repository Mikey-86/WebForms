using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDown();
            }
        }

        //Submit button
        protected async void Button1_Click(object sender, EventArgs e)
        {
            var PlayerObj = new Player();
            PlayerObj.FirstName = firstNametxt.Text;
            PlayerObj.LastName = lastNametxt.Text;
            PlayerObj.Age = Convert.ToInt32(agetxt.Text);
            PlayerObj.IDNumber = IDNumtxt.Text;
            PlayerObj.Address = addresstxt.Text;
            PlayerObj.DesiredTeam = teamDropDown.Text;

            HttpClient client = new HttpClient();

            var jsonVariable = JsonConvert.SerializeObject(PlayerObj);
            var content = new StringContent(jsonVariable, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://localhost:5000/api/players", content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Display success message
                    LabelWorking.Text = "Data submitted successfully.";
                    LabelWorking.BackColor = System.Drawing.Color.YellowGreen;
                    LabelWorking.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    // Display error message
                    LabelWorking.Text = "Error: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                LabelWorking.Text = "Error: " + ex.Message;
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
                        // Read the response content as a string before converting
                        string responseData = await response.Content.ReadAsStringAsync();

                        List<Team> teamObjList = JsonConvert.DeserializeObject<List<Team>>(responseData);

                        teamDropDown.DataSource = teamObjList;
                        teamDropDown.DataTextField = "Name";
                        teamDropDown.DataValueField = "Id";
                        teamDropDown.DataBind();
                        //Adding default value
                        teamDropDown.Items.Insert(0, new ListItem("Select", "NA"));
                    }
                    else
                    {
                        
                        LabelWorking.Text = $"Error: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    
                    LabelWorking.Text = $"Error: {ex.Message}";
                }
            }
        }
    }
}