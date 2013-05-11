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
using System.Windows.Media.Animation;
namespace OnlineStoreClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ServiceReference1.Service1Client _provider = new ServiceReference1.Service1Client();
        Login.LoginFrm loginForm;
        private int iterator = 0;
        private int productIterator = 0;
        private OnlineStoreClient.ServiceReference1.Product[] productList;
        private Canvas canvas;
        private bool horizontalBig = false;
        private bool verticalBig = false;
        private double originalWidth = 0;
        public MainWindow()
        {
            InitializeComponent();
            productList = _provider.GetPromoProductsList();
            canvas = new Canvas();
            loginForm = new Login.LoginFrm(this);
            workArea.Children.Add(loginForm);
            
        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
           /* bool logged = _provider.login(nickName.Text, password.Text);
            if (logged == true)
            {
                loginFrm.Visibility = Visibility.Collapsed;
            }*/
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void SbTop10_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TabPromos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void nextBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (iterator < productList.Length-1)
            {
                iterator++;
                nextPromoPage();
                updatePromoPage();
            }
            

        }

        private void prevButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (iterator >0)
            {
                iterator--;
                prevPromoPage();
                updatePromoPage();
            }
            
        }

        private void nextPromoPage()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = SbPromos.ActualWidth; 
            animation.To = 0;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            TranslateTransform tr = new TranslateTransform();
            SbPromos.RenderTransform = tr;

            tr.BeginAnimation(TranslateTransform.XProperty, animation);


        }
        private void prevPromoPage()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = -SbPromos.ActualWidth;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            TranslateTransform tr = new TranslateTransform();
            SbPromos.RenderTransform = tr;
            tr.BeginAnimation(TranslateTransform.XProperty, da);
        }
        private void updatePromoPage()
        {
            Uri uri = new Uri(productList[iterator].Cover);
            ImageSource imgSource = new BitmapImage(uri);
            Uri uriBg = new Uri(productList[iterator].Producer);
            ImageSource imgSourceBg = new BitmapImage(uriBg);
            ImageBrush textureBrush = new ImageBrush(imgSourceBg);
            this.SbPromos.Background = textureBrush;
            this.gameCover.Source = imgSource;
            this.gameTitle.Content = productList[iterator].ID;
            this.gameDescription.Text = productList[iterator].Description;
        }
        private void updatePoductPage()
        {
            Image[] gameCovers = new Image[productList.Length];
            Label[] gameNames = new Label[productList.Length];
            int currentX = 130;
            int currentY = 14;
            int currentXName = 130;
            int currentYName = 124;
            if (SbProducts.Children.Contains(canvas))
            {
                SbProducts.Children.Remove(canvas);
            }
            canvas = new Canvas();
            for (int i=0;i<productList.Length-productIterator;i++){

                Uri uri = new Uri(productList[i+productIterator].Cover);
                ImageSource imgSource = new BitmapImage(uri);

                gameCovers[i] = new Image();
                gameCovers[i].Source = imgSource;
                gameCovers[i].Width = 211;
                gameCovers[i].Height = 113;

 
                Canvas.SetTop(gameCovers[i], currentY);
                Canvas.SetLeft(gameCovers[i], currentX);
               
                canvas.Children.Add(gameCovers[i]);
                

                gameNames[i] = new Label();
                gameNames[i].Content = productList[i+productIterator].ID;
 
                Canvas.SetTop(gameNames[i], currentYName);
                Canvas.SetLeft(gameNames[i], currentXName);
                canvas.Children.Add(gameNames[i]);
                currentX += 231;
                currentXName += 231;
                if (((i==2||i==5||i==8) && horizontalBig == false) || (horizontalBig && (i==5||i==11||i==17)))
                {
                    currentY += 150;
                    currentYName += 150;
                    currentX = 130;
                    currentXName = 130;
                }
              
                
                if (!verticalBig && !horizontalBig)
                {
                    nextBtn.IsEnabled = true;
                    prevButton.IsEnabled = true;
                }
                if (horizontalBig || verticalBig)
                {
                    nextBtn.IsEnabled = false;
                    prevButton.IsEnabled = false;
                    if (i == 11)
                    {

                        break;
                    }
                }
                else
                {
                    if (i == 5)
                    {

                        break;
                    }
                }
                
            }

            SbProducts.Children.Add(canvas);
        }

        private void workArea_Loaded(object sender, RoutedEventArgs e)
        {
           
            updatePromoPage();
           // updatePoductPage();
        }

        private void TabProducts_MouseDown(object sender, MouseButtonEventArgs e)
        {
   
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (productIterator+6 < productList.Length)
            {
                productIterator += 6;
                updatePoductPage();
            }
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (productIterator > 0)
            {
                productIterator -= 6;
                updatePoductPage();
            }
        }

        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            if (this.Width > 1600)
            {
                horizontalBig = true;
                updatePoductPage();
            }

            if (this.Height > 800)
            {
                verticalBig = true;
                updatePoductPage();
            }
            if (this.Height < 800)
            {
                verticalBig = false;
                updatePoductPage();
            }
            if (this.Width < 1200)
            {
                horizontalBig = false;
                updatePoductPage();
            }
        }

        private void TabPromos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            productList = _provider.GetPromoProductsList();
            updatePromoPage();
        }

        private void TabProducts_MouseUp(object sender, MouseButtonEventArgs e)
        {

            productList = _provider.GetProductList();
            updatePoductPage();
        }


    }
}
