using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static Motorcycle_Emission_Inspection_Management.BLL.Services.StatisticsService;
using System.Text.RegularExpressions;
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
            RoleComboBox.SelectedValuePath = "RoleId";
        }

        private void LoadStations()
        {
            var stations = _stationService.GetAllStations();
            StationComboBox.ItemsSource = stations;
            StationComboBox.DisplayMemberPath = "Name";
            StationComboBox.SelectedValuePath = "StationId";
        }

        private void LoadUserInfo(User user)
        {
            FullNameBox.Text = user.FullName;
            PhoneBox.Text = user.Phone;
            EmailBox.Text = user.Email;
            AddressBox.Text = user.Address;
            PasswordBox.Password = user.Password;
            RoleComboBox.SelectedValue = user.RoleId;
            StationComboBox.SelectedValue = user.StationId;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(FullNameBox.Text) ||
            string.IsNullOrWhiteSpace(PasswordBox.Password) ||
            RoleComboBox.SelectedItem == null ||
            string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidEmail(EmailBox.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đúng số Email!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidPhoneNumber(PhoneBox.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đúng số điện thoại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _editingUser.FullName = FullNameBox.Text.Trim();
            _editingUser.Email = EmailBox.Text.Trim();
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


        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^0\d{9,10}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }



        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
