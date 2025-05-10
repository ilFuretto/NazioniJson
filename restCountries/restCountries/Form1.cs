using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace restCountries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://restcountries.com/v3.1/name/"+(sender as Button).Text);
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string risultato = await response.Content.ReadAsStringAsync();

            List<Nazioni.Root> Paese = JsonConvert.DeserializeObject<List<Nazioni.Root>>(risultato);
            
            listBox1.Items.Clear();
            foreach (string confine in Paese[0].borders)
            { 
                listBox1.Items.Add(confine);
            }
        }
    }
}
