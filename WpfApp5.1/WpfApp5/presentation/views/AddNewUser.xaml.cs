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
using WpfApp5.domain.models;

namespace WpfApp5.presentation.views
{
    /// <summary>
    /// Interaction logic for AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Page
    {
        private UserPage _userPage;
        public AddNewUser(UserPage userPage)
        {
            InitializeComponent();
            _userPage = userPage;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn giới tính chưa
            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }
            // Lấy dữ liệu từ TextBox
            UserModel newUser = new UserModel()
            {
                ID = int.Parse(txtID.Text),
                Name = txtName.Text,
                Gender = (cmbGender.SelectedItem as ComboBoxItem).Content.ToString(),
                Telephone = txtTelephone.Text,
                Role =  txtRole.Text
            };

            // Gửi dữ liệu về UserPage
            _userPage.AddUser(newUser);

            // Quay lại UserPage
            this.NavigationService.Navigate(_userPage);
        }
    }
}
