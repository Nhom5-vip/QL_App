using System.Text;
using System.Windows;
using WpfApp5.presentation.views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5.presentation.views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;
            string pageTag = clickedButton.Tag.ToString();
            switch (pageTag)
            {
                case "UserPage":
                    MainFrame.Navigate(new UserPage()); // Đảm bảo UserPage.xaml tồn tại
                    break;

                case "ProductPage":
                    MessageBox.Show("Trang quan ly ung dung");
                    break;
            }
                

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}