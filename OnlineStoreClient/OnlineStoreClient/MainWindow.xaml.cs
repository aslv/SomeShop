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
using OnlineStoreClient.forms;
using System.Collections.ObjectModel;
using System.Windows.Media.Effects;
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
        public OnlineStoreClient.ServiceReference1.Product[] productList;
        public OnlineStoreClient.ServiceReference1.Product[] productPromoList;
        private Canvas canvas;
        private bool horizontalBig = false;
        private bool verticalBig = false;
        public double totalPrice = 0;
        private bool fullscreen = false;
        Image[] gameCovers;
        public MainWindow()
        {
            InitializeComponent();
            productList = _provider.GetProductList();
            productPromoList = _provider.GetPromoProductsList();
            canvas = new Canvas();
            loginForm = new Login.LoginFrm(this);
            messageGrid.Children.Add(loginForm);


            
        }



        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void SbTop10_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TabPromos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                productPromoList = _provider.GetPromoProductsList();
                updatePromoPage();
            }
        }

        private void nextBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (iterator < productPromoList.Length-1)
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
            Uri uri = new Uri(productPromoList[iterator].Cover);
            ImageSource imgSource = new BitmapImage(uri);
            Uri uriBg = new Uri(productPromoList[iterator].Producer);
            ImageSource imgSourceBg = new BitmapImage(uriBg);
            ImageBrush textureBrush = new ImageBrush(imgSourceBg);
            this.SbPromos.Background = textureBrush;
            this.gameCover.Source = imgSource;
            this.gameTitle.Content = productPromoList[iterator].ID;
            this.gameDescription.Text = productPromoList[iterator].Description;
            this.gameGenre.Content = "Genre: " + productPromoList[iterator].Genre;
            this.gamePrice.Content = "Price: " + productPromoList[iterator].Price;
        }
        private void updatePoductPage()
        {
            gameCovers = new Image[productList.Length];
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
                gameCovers[i].MouseDown += product_click;
 
                Canvas.SetTop(gameCovers[i], currentY);
                Canvas.SetLeft(gameCovers[i], currentX);
               
                canvas.Children.Add(gameCovers[i]);
                

                gameNames[i] = new Label();
                gameNames[i].Content = productList[i+productIterator].ID;
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(100, 255, 255, 255);
                gameNames[i].Foreground = brush;
                Canvas.SetTop(gameNames[i], currentYName);
                Canvas.SetLeft(gameNames[i], currentXName);
                canvas.Children.Add(gameNames[i]);
                currentX += 231;
                currentXName += 231;
                if (((i==2||i==5||i==8) && horizontalBig == false) || (horizontalBig && (i==4||i==9||i==14)))
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
                if (verticalBig && horizontalBig)
                {
                    nextBtn.IsEnabled = false;
                    prevButton.IsEnabled = false;
                    if (i == 14)
                    {
                        break;
                    }
                }
                else if (horizontalBig )
                {
                   if (i == 11)
                    {
                        break;
                    }
                }
                else if (verticalBig)
                {
                    if (i == 8)
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
        public void product_click(object sender, MouseButtonEventArgs e)
        {
            int iterator = 0;
            if (e.ChangedButton == MouseButton.Left)
            {
                foreach (Image gameImage in gameCovers)
                {

                    if (sender == gameImage)
                    {
                        GameInfo gameInfoWindow = new GameInfo(productList[iterator + productIterator]);
                        this.messageGrid.Children.Add(gameInfoWindow);
                        DoubleAnimation da = new DoubleAnimation();
                        da.From = 0;
                        da.To = 1;
                        da.Duration = new Duration(TimeSpan.FromMilliseconds(400));



                        gameInfoWindow.BeginAnimation(OpacityProperty, da);
                    }
                    iterator++;
                }
            }
        }
        private void workArea_Loaded(object sender, RoutedEventArgs e)
        {
           
            updatePromoPage();
        }

        private void TabProducts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                productList = _provider.GetProductList();
                updatePoductPage();
            }
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
            if (this.Width > 1100)
            {
                horizontalBig = true;
                updatePoductPage();
            }

            if (this.Height >600)
            {
                verticalBig = true;
                updatePoductPage();
            }
            if (this.Height < 600)
            {
                verticalBig = false;
                updatePoductPage();
            }
            if (this.Width < 1000)
            {
                horizontalBig = false;
                updatePoductPage();
            }
        }

   
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            cartNames.Text = "";
            cartPrices.Text = "";
            cartPrice.Content = "Total: ";
        }

        private void cartTab_MouseUp(object sender, MouseButtonEventArgs e)
        {
            cartAlert.Opacity = 0;
        }




        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
  
                this.DragMove();
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.Close();
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (!fullscreen)
                {
                    //this.border.Opacity = 0;
                    this.WindowState = WindowState.Maximized;
                    fullscreen = true;
                }
                else
                {
                 //   this.border.Opacity = 100;
                    this.WindowState = WindowState.Normal;
                    fullscreen = false;
                }
            }
        }

        private void Image_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseEnter_1(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.BlurRadius = 5;
            effect.ShadowDepth = 0;
            effect.Color = Color.FromArgb(100, 255, 255, 255);
            effect.Opacity = 1;
            closeWindowButton.Effect = effect;
        }

        private void closeWindowButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeWindowButton.Effect = null;
        }

        private void maximizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.BlurRadius = 5;
            effect.ShadowDepth = 0;
            effect.Color = Color.FromArgb(100, 255, 255, 255);
            effect.Opacity = 1;
            maximizeButton.Effect = effect;
        }

        private void maximizeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            maximizeButton.Effect = null;
        }

        private void Image_MouseEnter_2(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.BlurRadius = 5;
            effect.ShadowDepth = 0;
            effect.Color = Color.FromArgb(100, 255, 255, 255);
            effect.Opacity = 1;
           collapseButton.Effect = effect;
        }

        private void collapseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            collapseButton.Effect = null;
        }




    }
}
