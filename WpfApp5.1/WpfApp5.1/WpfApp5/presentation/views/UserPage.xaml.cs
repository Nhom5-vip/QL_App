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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
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
            if (dataGrid.SelectedItem is UserModel selectedUser)
            {
                // Hiển thị hộp thoại nhập vai trò mới
                string newRole = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Nhập vai trò mới cho {selectedUser.Name}:",
                    "Change Role",
                    selectedUser.Role
                );

                // Kiểm tra Role có hợp lệ không
                if (!System.Text.RegularExpressions.Regex.IsMatch(newRole, @"^[\p{L} ]+$"))
                {
                    MessageBox.Show("Vai trò chỉ được chứa chữ cái!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Cập nhật vai trò
                selectedUser.Role = newRole;
                dataGrid.Items.Refresh(); // Làm mới hiển thị DataGrid

                MessageBox.Show("Cập nhật vai trò thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng để chỉnh sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void AddUser(UserModel newUser)
        {
            Users.Add(newUser);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is UserModel selectedUser)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa người dùng {selectedUser.Name}?",
                    "Xác nhận xóa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result == MessageBoxResult.Yes)
                {
                    Users.Remove(selectedUser);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
