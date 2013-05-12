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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineStoreClient.forms
{
    /// <summary>
    /// Interaction logic for GameInfo.xaml
    /// </summary>
    public partial class GameInfo : UserControl
    {
        OnlineStoreClient.ServiceReference1.Product product;
        public GameInfo(OnlineStoreClient.ServiceReference1.Product product)
        {
            this.product = product;
            InitializeComponent();
            Uri uri = new Uri(product.Cover);
            ImageSource imgSource = new BitmapImage(uri);
            Uri uriBg = new Uri(product.Producer);
            ImageSource imgSourceBg = new BitmapImage(uriBg);
            ImageBrush textureBrush = new ImageBrush(imgSourceBg);
            this.workArea.Background = textureBrush;
            this.gameCover.Source = imgSource;
            this.gameTitle.Content = product.ID;
            this.gameDescription.Text = product.Description;

            this.gamePrice.Content = "Price: " + product.Price;
          

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            MainWindow parent = (MainWindow)parentWindow;
            BlurEffect effect = new BlurEffect();
            effect.Radius = 10;
            
            parent.contentGrid.Effect = effect;
        }

        private void UserControl_IsVisibleChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            MainWindow parent = (MainWindow)parentWindow;


            parent.contentGrid.Effect = null;
           // parent.messageGrid.getc
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            MainWindow parent = (MainWindow)parentWindow;
            if (parent.cartNames.Text.Contains(product.ID)) 
            { 
            }
            else
            {
                parent.cartNames.Text += product.ID + "\n";
                parent.cartPrices.Text += product.Price + "\n";
                parent.cartAlert.Opacity = 100;
                parent.totalPrice += Convert.ToDouble(product.Price);
                parent.cartPrice.Content = "Total: " + parent.totalPrice;
            }
           
        }

  

 
    }
}
