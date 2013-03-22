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

namespace OnlineStoreClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ServiceReference1.Service1Client _provider = new ServiceReference1.Service1Client();
        Login.LoginFrm log = new Login.LoginFrm();

        public MainWindow()
        {
            InitializeComponent();
            workArea.Children.Add(log);
        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
           /* bool logged = _provider.login(nickName.Text, password.Text);
            if (logged == true)
            {
                loginFrm.Visibility = Visibility.Collapsed;
            }*/
        }
        
    }
}
