using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System.Windows;
using System.Windows.Controls;
using static Motorcycle_Emission_Inspection_Management.BLL.Services.StatisticsService;

namespace Motorcycle_Emission_Inspection_Management.Admin
{
    public partial class UserEditPage : Page
    {
        private readonly UserService _userService = new();
        private readonly RoleService _roleService = new();
        private readonly StationService _stationService = new();

        private User _editingUser;
        private bool _isEditMode;

        public UserEditPage(User? user = null)
        {
            InitializeComponent();

            LoadRoles();
            LoadStations();

            if (user != null)
            {
                _editingUser = user;
                _isEditMode = true;
                LoadUserInfo(user);
            }
            else
            {
                _editingUser = new User();
                _isEditMode = false;
            }
        }

        private void LoadRoles()
        {
            var roles = _roleService.GetAllRoles();
            RoleComboBox.ItemsSource = roles;
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "RoleID";
        }

        private void LoadStations()
        {
            var stations = _stationService.GetAllStations();
            StationComboBox.ItemsSource = stations;
            StationComboBox.DisplayMemberPath = "StationName";
            StationComboBox.SelectedValuePath = "StationID";
        }

        private void LoadUserInfo(User user)
        {
            UsernameBox.Text = user.Email;
            FullNameBox.Text = user.FullName;
            PhoneBox.Text = user.Phone;
            AddressBox.Text = user.Address;
            PasswordBox.Password = user.Password;
            RoleComboBox.SelectedValue = user.RoleId;
            StationComboBox.SelectedValue = user.StationId;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(FullNameBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                RoleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _editingUser.FullName = FullNameBox.Text.Trim();
            _editingUser.Email = UsernameBox.Text.Trim();
            _editingUser.Password = PasswordBox.Password.Trim();
            _editingUser.Phone = PhoneBox.Text.Trim();
            _editingUser.Address = AddressBox.Text.Trim();
            _editingUser.RoleId = (int)RoleComboBox.SelectedValue;
            _editingUser.StationId = StationComboBox.SelectedValue as int?;

            if (_isEditMode)
                _userService.UpdateUser(_editingUser);
            else
                _userService.CreateUser(_editingUser);

            MessageBox.Show("Đã lưu thông tin người dùng", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService?.GoBack();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
