using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MyWeatherApp
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        string citi = "Yenakiyeve";
        public void info()
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={citi}&appid=b84317f5648a45ffd98987aa8452d409&units=metric";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string response = reader.ReadToEnd();
            weatherResponse wr = JsonConvert.DeserializeObject<weatherResponse>(response);
            lTemp.Text = wr.main.Temp.ToString();
            lHumidity.Text = wr.main.humidity.ToString() + " %";
            double temp = Convert.ToDouble(lTemp.Text);

            if (temp > 10 && temp < 20)
            {
                lTemp.Text += ". Достаточно тепло!";
            }
            else if (temp < 10 && temp > 0)
            {
                lTemp.Text += ". Прохладно!";
            }
            else if (temp < 0 && temp > -10)
            {
                lTemp.Text += ". На улице дубак!";
            }
            else if ( temp < -10)
            {
                lTemp.Text += ". Сиди лучше дома...";
            }
            else if (temp > 20)
            {
                lTemp.Text += ". Адская жара";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            info();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            switch (comboBox1.SelectedIndex) {
                case 0:
                    citi = "Yenakiyeve";
                    break;
                case 1:
                    citi = "Donetsk";
                    break;
                case 2:
                    citi = "Snizhne";
                    break;
                case 3:
                    citi = "Horlivka";
                    break;
            }
            info();

        }

        

    }
}
