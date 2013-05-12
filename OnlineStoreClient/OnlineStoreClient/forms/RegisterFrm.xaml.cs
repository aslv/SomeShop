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
using Login;
namespace OnlineStoreClient.forms
{
    /// <summary>
    /// Interaction logic for Register_form.xaml
    /// </summary>
    public partial class Register_form : UserControl
    {
        LoginFrm parent;
        public Register_form(LoginFrm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }
    }
}
