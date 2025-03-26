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
        //    private void SaveButton_Click(object sender, RoutedEventArgs e)
        //    {
        //        // Kiểm tra xem người dùng đã chọn giới tính chưa
        //        if (cmbGender.SelectedItem == null)
        //        {
        //            MessageBox.Show("Vui lòng chọn giới tính!");
        //            return;
        //        }
        //        // Lấy dữ liệu từ TextBox
        //        UserModel newUser = new UserModel()
        //        {
        //            ID = int.Parse(txtID.Text),
        //            Name = txtName.Text,
        //            Gender = (cmbGender.SelectedItem as ComboBoxItem).Content.ToString(),
        //            Telephone = txtTelephone.Text,
        //            Role =  txtRole.Text
        //        };

        //        // Gửi dữ liệu về UserPage
        //        _userPage.AddUser(newUser);

        //        // Quay lại UserPage
        //        this.NavigationService.Navigate(_userPage);
        //    }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra nếu TextBox bị null (tránh lỗi NullReferenceException)
            if (txtID == null || txtName == null || cmbGender == null || txtTelephone == null || txtRole == null)
            {
                MessageBox.Show("Lỗi: Một hoặc nhiều trường nhập liệu không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra ID có phải số không
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("ID phải là số!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra Name chỉ chứa chữ cái (không số, không ký tự đặc biệt)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, @"^[\p{L} ]+$"))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra giới tính đã chọn chưa
            string gender = (cmbGender.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra số điện thoại có đúng định dạng không (chỉ chứa số, tối đa 10 chữ số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelephone.Text, @"^\d{8,10}$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa 8-10 chữ số!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtRole.Text, @"^[\p{L} ]+$"))
            {
                MessageBox.Show("Vai trò chỉ được chứa chữ cái!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Tạo đối tượng người dùng mới
            UserModel newUser = new UserModel()
            {
                ID = id,  
                Name = txtName.Text.Trim(),
                Gender = gender,
                Telephone = txtTelephone.Text.Trim(),
                Role = txtRole.Text.Trim()
            };

            // Gửi dữ liệu về UserPage
            _userPage.AddUser(newUser);

            MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Quay lại UserPage
            this.NavigationService.Navigate(_userPage);
        }
    }
}
