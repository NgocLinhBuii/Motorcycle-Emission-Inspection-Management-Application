using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.VehicleOwner;
using Motorcycle_Emission_Inspection_Management.Dashboards;
using Motorcycle_Emission_Inspection_Management.InspectionFacility;
using Motorcycle_Emission_Inspection_Management.InspectionWorkers;
using Motorcycle_Emission_Inspection_Management.Police;
using System;
using System.Linq;
using System.Windows;

namespace Motorcycle_Emission_Inspection_Management
{
    public partial class LoginWindow : Window
    {
        private readonly UserService _userService = new();
        private readonly RoleService _roleService = new(); // giả sử bạn có RoleService

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailAddressTextBox.Text.Trim();
            string password = PasswordTextBox.Password.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Email và Mật khẩu.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Lấy toàn bộ user và role từ service
            var user = _userService.GetAllUser
                .FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                  && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Email hoặc mật khẩu không chính xác.", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var role = _roleService.GetAllRoles().FirstOrDefault(r => r.RoleId == user.RoleId)?.RoleName;

            if (role == null)
            {
                MessageBox.Show("Vai trò người dùng không hợp lệ.", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Điều hướng theo RoleName
            switch (role)
            {
                case "Owner":
                    new VehicleOwnerWindow(user.UserId).Show();
                    break;
                case "Inspector":
                    new Motorcycle_Emission_Inspection_Management.Dashboards.InspectorDashboard().Show();
                    break;
                case "Station":
                    new Motorcycle_Emission_Inspection_Management.Dashboards.InspectionFacilityDashboardPage().Show();
                    break;
                case "Police":
                    new PoliceWindow().Show();
                    break;
                default:
                    MessageBox.Show("Vai trò chưa hỗ trợ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            this.Hide();
        }
    }
}
