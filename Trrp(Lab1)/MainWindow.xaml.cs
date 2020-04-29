using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trrp_Lab1_.Auth;

namespace Trrp_Lab1_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            var s = "https://" + ConfigurationManager.AppSettings.Get("url") + "/authorize?client_id=" + ConfigurationManager.AppSettings.Get("idClient") + "&display=page&scope="+ ConfigurationManager.AppSettings.Get("scope") + "&response_type=code&v=5.2";
            var forem = new WebBrooser(s);
            forem.Show();
            this.Close();
                
        }
    }
}
