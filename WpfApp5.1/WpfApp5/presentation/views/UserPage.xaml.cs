using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp5.domain.models;

namespace WpfApp5.presentation.views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public ObservableCollection<UserModel> Users { get; set; }
        public UserPage()
        {
            InitializeComponent();
            Users = new ObservableCollection<UserModel>();
            dataGrid.ItemsSource = Users;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển đến trang AddNewUser
            this.NavigationService.Navigate(new AddNewUser(this)); // Truyền `this` vào để gọi lại `AddUser`

        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }
        public void AddUser(UserModel newUser)
        {
            Users.Add(newUser);
        }

    }
}
