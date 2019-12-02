using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
using Trrp_Lab1_.MainForm;

namespace Trrp_Lab1_.Auth
{
    /// <summary>
    /// Логика взаимодействия для WebBrooser.xaml
    /// </summary>
    public partial class WebBrooser : Window
    {
        public WebBrooser(string uri)
        {
            InitializeComponent();
            web.Source = new Uri(uri);
        }

        private void web_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            
            var s = web.Source.Fragment.Split('=');
            if (s.Count() == 2)
            {
                WebRequest request = WebRequest.Create("https://oauth.vk.com/access_token?client_id=7230625&client_secret=hxHZWOQDwR3viGHDMq94&code=" + s[1]);
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                string res = "";
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        res = reader.ReadToEnd();
                    }
                }
                response.Close();
               
                var obj = JsonConvert.DeserializeObject<JObject>(res);
                var s23 = obj.Value<string>("access_token");
                if (s23 != null)
                {
                    var form = new MainWin(s23);
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("НЕ достаточно прав");
                    var formAuth = new MainWindow();
                    formAuth.Show();
                    this.Close();
                }
            }
           
        }
    }
}
