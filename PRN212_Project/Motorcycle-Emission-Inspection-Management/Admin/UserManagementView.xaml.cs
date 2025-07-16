using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Motorcycle_Emission_Inspection_Management.Admin
{
    public partial class UserManagementView : Page
    {
        private readonly UserService _userService = new();
        private ObservableCollection<User> _userList;
        private readonly RoleService _roleService = new();

        public UserManagementView()
        {
            InitializeComponent();
            LoadUserData();
            this.Loaded += UserManagementView_Loaded;
            LoadRoles();
        }

        private void LoadRoles()
        {
            // Assuming you have a method to get roles from the database
            var roles = _roleService.GetAllRoles();

            // Bind the roles to the ComboBox
            RoleSearchComboBox.ItemsSource = roles;
            RoleSearchComboBox.DisplayMemberPath = "RoleName"; // Display the Role Name in the ComboBox
            RoleSearchComboBox.SelectedValuePath = "RoleId"; // Use RoleId as the selected value
        }

        private void LoadUserData()
        {
            var users = _userService.GetAllUser;
            _userList = new ObservableCollection<User>(users);
            UserDataGrid.ItemsSource = _userList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Mở trang UserEditPage (chế độ thêm)
            NavigationService?.Navigate(new UserEditPage());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem is not User selectedUser)
            {
                MessageBox.Show("Vui lòng chọn người dùng để sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mở UserEditPage với user được chọn
            NavigationService?.Navigate(new UserEditPage(selectedUser));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem is not User selectedUser)
            {
                MessageBox.Show("Vui lòng chọn người dùng để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa tài khoản: {selectedUser.FullName}?", "Xác nhận xóa",
                                          MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm == MessageBoxResult.Yes)
            {
                _userService.DeleteUser(selectedUser);
                _userList.Remove(selectedUser);
                MessageBox.Show("Đã xóa người dùng", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve search queries from the UI controls
            string nameQuery = NameSearchTextBox.Text.Trim();   // Name search
            string emailQuery = EmailSearchTextBox.Text.Trim(); // Email search
            string roleQuery = RoleSearchComboBox.SelectedValue?.ToString(); // Role search (using selected value)

            // Call the SearchUsers method from the UserService
            var filteredUsers = _userService.SearchUsers(nameQuery, emailQuery, roleQuery);

            // Bind the filtered users list to the DataGrid
            UserDataGrid.ItemsSource = filteredUsers;
        }

        private void UserManagementView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserData(); // làm mới dữ liệu
        }
    }
}
