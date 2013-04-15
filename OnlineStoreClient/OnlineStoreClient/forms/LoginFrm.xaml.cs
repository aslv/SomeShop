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

namespace Login
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginFrm : UserControl
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private void lbReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

=======
        private void LoginBtn_Click_1(object sender, RoutedEventArgs e)
        {
            OnlineStoreClient.ServiceReference1.Service1Client _provider = new OnlineStoreClient.ServiceReference1.Service1Client();
            var loged=_provider.login(tbUsername.Text, pwPass.Password);
            if (loged)
            {
                MessageBox.Show("Brao");
            }
            else
            {
                MessageBox.Show("Ne brao");
            }
>>>>>>> Работеща връзка към Базата от данни
        }
    }
}
