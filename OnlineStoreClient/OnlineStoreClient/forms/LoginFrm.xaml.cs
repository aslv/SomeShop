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
using OnlineStoreClient;
using System.IO;
using OnlineStoreClient.forms;
namespace Login
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginFrm : UserControl
    {
        private MainWindow parent;
        public LoginFrm(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void lbReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
            
        }
        private void LoginBtn_Click_1(object sender, RoutedEventArgs e)
        {
            OnlineStoreClient.ServiceReference1.Service1Client _provider = new OnlineStoreClient.ServiceReference1.Service1Client();
            var loged=_provider.Login(tbUsername.Text, pwPass.Password);
            if (loged)
            {
                if (rememberInfo.IsChecked.Value)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter("info.txt");
                    file.WriteLine(tbUsername.Text + " " + pwPass.Password + "\n");
                    file.Close();
                }
                parent.blocktangle.Opacity = 100;
                parent.blocktangle.Width = 0;
                parent.blocktangle.Height = 0;
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.errorBlock.Content = "Incorret Username/Password";
            }
        }

        private void LoginBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void Grid_Initialized_1(object sender, EventArgs e)
        {
            if(File.Exists("info.txt"))
            {
                string line;
                using (StreamReader reader = new StreamReader("info.txt"))
                {
                    line = reader.ReadLine();
                }

                    string[] info = line.Split(' ');
                    tbUsername.Text = info[0];
                    pwPass.Password = info[1];
            }
        }

        private void txtRegister_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Register_form registerFrm = new Register_form(this);
            parent.workArea.Children.Add(registerFrm);
        }

    

      
    }

}
