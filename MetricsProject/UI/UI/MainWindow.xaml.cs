using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Globalization;
using System.Net.Http.Headers;
using System.Web;

namespace MetricsManagerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CpuChart.ColumnSeriesValues[0].Values.Clear();

            string id = "1";
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44334/api/Agents/AgentsCpuMetrics/GetCpuMetricsByTime_ValuesOnly");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
            request.Headers.Add("id", id.ToString());

            var response = client.SendAsync(request).Result.Content.ReadAsStringAsync();
            char[] sep = { ',', '[', ']' };
            var result = response.Result.Split(sep,StringSplitOptions.RemoveEmptyEntries);
            

            foreach(var i in result) { CpuChart.ColumnSeriesValues[0].Values.Add(double.Parse(i)); }
           // CpuChart.ColumnSeriesValues[0].Values.Add(48d);
        }

    }
}

