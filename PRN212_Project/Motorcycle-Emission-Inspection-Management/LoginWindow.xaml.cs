using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;
using Motorcycle_Emission_Inspection_Management.Dashboards;
using Motorcycle_Emission_Inspection_Management.InspectionFacility;
using Motorcycle_Emission_Inspection_Management.InspectionWorkers;
using Motorcycle_Emission_Inspection_Management.Police;
using Motorcycle_Emission_Inspection_Management.VehicleOwner;
using Motorcycle_Emission_Inspection_Management.Common;
using System;
using System.Linq;
using System.Windows;

namespace Motorcycle_Emission_Inspection_Management
{
    public partial class LoginWindow : Window
    {
        private readonly UserService _userService = new();
        private readonly RoleService _roleService = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailAddressTextBox.Text.Trim();
            string password = PasswordTextBox.Password.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Email và Mật khẩu.",
                                "Thiếu thông tin",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            /* ===== 1. XÁC THỰC USER ===== */
            // 1a.  Nếu UserService có hàm Authenticate:
         

            // 1b.  Hoặc sửa tên hàm:
            var user = _userService.GetAllUser      // <- thêm chữ s
                       .FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                         && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Email hoặc mật khẩu không chính xác.",
                                "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            /* ===== 2. LẤY ROLE ===== */
            string role = _roleService.GetAllRoles()
                                       .FirstOrDefault(r => r.RoleId == user.RoleId)
                                      ?.RoleName;

            if (role == null)
            {
                MessageBox.Show("Vai trò người dùng không hợp lệ.",
                                "Lỗi hệ thống",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            /* ===== 3. LƯU SESSION ===== */
            UserSession.UserId = user.UserId;
            UserSession.Username = user.FullName;
            UserSession.RoleName = role;
            UserSession.StationId = user.StationId;  // có thể null


            /* ===== 4. ĐIỀU HƯỚNG THEO ROLE ===== */
            Window next;   // dùng cho Owner / Inspector / Police

            switch (role)
            {
                case "Owner":
                    next = new OwnerDashboard();
                    break;

                case "Inspector":
                    next = new InspectorDashboard();   // Dashboard sẽ tự đọc UserSession
                    break;

                case "Station":
                    if (user.StationId == null)
                    {
                        MessageBox.Show("Tài khoản Station chưa gán trạm!",
                                        "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // InspectionFacilityDashboardPage có constructor (int stationManagerUserId)
                    var facilityDash = new InspectionFacilityDashboardPage(user.UserId);
                    facilityDash.Show();   // mở luôn
                    Hide();
                    return;                // thoát phương thức, không dùng biến next

                case "Police":
                    next = new PoliceWindow();
                    break;

                default:
                    MessageBox.Show("Vai trò chưa hỗ trợ.",
                                    "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
            }

            /* các role dùng biến next */
            next.Show();
            Hide();
        }
        }
    }
