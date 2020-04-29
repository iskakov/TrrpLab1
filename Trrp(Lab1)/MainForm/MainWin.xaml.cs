using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trrp_Lab1_.MainForm
{
    /// <summary>
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        private string token;
        string vers = "v=5.62";
        public MainWin(string token)
        {
            InitializeComponent();
            this.token = token;
        }

        private void loadButt_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://api.vk.com/method/account.getProfileInfo?";

            // Создаём объект WebClient
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = UnicodeEncoding.UTF8;
                // Выполняем запрос по адресу и получаем ответ в виде строки
                string responsik = webClient.DownloadString(url + "&access_token=" + token + "&" + vers);
                responsik = responsik.Substring(12, responsik.Length - 13);
                var obj = JsonConvert.DeserializeObject<JObject>(responsik);
                status.Text = obj.Value<string>("status");
            }
        }

        private void saveButt_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://api.vk.com/method/account.saveProfileInfo?";
            using (WebClient webClient = new WebClient())
            {
                url += "status=" + status.Text;
                webClient.Encoding = UnicodeEncoding.UTF8;
                string responsik = webClient.DownloadString(url + "&access_token=" + token + "&" + vers);
                responsik = responsik.Substring(12, responsik.Length - 13);
                MessageBox.Show(responsik);
            }
        }

        private void loadButtPost_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://api.vk.com/method/wall.get?";
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = UnicodeEncoding.UTF8;
                string responsik = webClient.DownloadString(url + "count=1" + "&access_token=" + token + "&" + "filter=owner" + "&" + vers);
               
                responsik = responsik.Substring(34, responsik.Length - 37);

                var obj = JsonConvert.DeserializeObject<JObject>(responsik);
                MessageBox.Show(obj.Value<string>("text"));
            }
        }

        private void saveButtPost_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://api.vk.com/method/wall.post?";
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = UnicodeEncoding.UTF8;
                string query = url + "friends_only=0" + "&" + "message=" + post.Text + "&access_token=" + token + "&" + vers;
               
                string responsik = webClient.DownloadString(query);
                responsik = responsik.Substring(12, responsik.Length - 13);
                var obj = JsonConvert.DeserializeObject<JObject>(responsik);
                MessageBox.Show(obj.Value<string>("post_id"));          
            }
        }

        private void delButtPost_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://api.vk.com/method/wall.get?";
            string url2 = "https://api.vk.com/method/wall.delete?";
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = UnicodeEncoding.UTF8;
                string responsik = webClient.DownloadString(url + "count=1" + "&access_token=" + token + "&" + "filter=owner" + "&" + vers);
                responsik = responsik.Substring(34, responsik.Length - 38);

                var obj = JsonConvert.DeserializeObject<JObject>(responsik);
                var id = obj.Value<string>("id");
                responsik = webClient.DownloadString(url2 + "post_id="+ id + "&access_token=" + token + "&" + vers);

            }
        }
    }
}
