using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;
using static System.Net.WebRequestMethods;

namespace WebForms
{
    public partial class TeamDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDown();
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

                        TeamDropDownList.DataSource = teamObjList;
                        TeamDropDownList.DataTextField = "Name";
                        TeamDropDownList.DataValueField = "Id";
                        TeamDropDownList.DataBind();
                        //Adding default value
                        TeamDropDownList.Items.Insert(0, new ListItem("Select", "NA"));
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

        protected async void TeamDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamDropDownList.SelectedIndex != 0)
            {
                var result = Convert.ToInt32(TeamDropDownList.Text);
                string url = "https://localhost:5000/api/players/" + result;

                //Retrieving players by team ID
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Send a GET request to the API endpoint
                        HttpResponseMessage response = await client.GetAsync(url);

                        // Check if the response is successful
                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as a string before converting
                            string responseData = await response.Content.ReadAsStringAsync();

                            List<Player> teamObjList = JsonConvert.DeserializeObject<List<Player>>(responseData);

                            PlayerGridView.DataSource = teamObjList;
                            PlayerGridView.DataBind();
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
}