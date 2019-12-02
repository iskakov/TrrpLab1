using System;
using System.Collections.Generic;
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

            var s = "https://oauth.vk.com/authorize?client_id=7230625&display=page&scope=friends&response_type=code&v=5.103";
            var forem = new WebBrooser(s);
            forem.Show();
            this.Close();
                var s1=" https://oauth.vk.com/access_token?client_id=7230625&client_secret=hxHZWOQDwR3viGHDMq94&code=cd4f424793dd601fcb";
        }
    }
}
