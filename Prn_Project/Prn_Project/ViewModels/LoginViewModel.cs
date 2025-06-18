using BCrypt.Net;
using Prn_Project.Models;
using Prn_Project.Views.Inspector;
using Prn_Project.Views.Owner;
using Prn_Project.Views.Police;
using Prn_Project.Views.Station;
using System.Windows;
using System.Windows.Input;

namespace Prn_Project.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        public void ExecuteLogin()
        {
            // Kiểm tra nếu Email và Password trống
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Email và mật khẩu không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Dừng lại nếu thiếu thông tin
            }

            using (var context = new EmissionInspectionContext())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.Email == Email); // Tìm người dùng dựa trên Email

                // Kiểm tra nếu người dùng tồn tại và mật khẩu nhập vào khớp với mật khẩu đã mã hóa trong CSDL
                if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Password))  // Kiểm tra mật khẩu sau khi mã hóa
                {
                    MessageBox.Show("Đăng nhập thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Application.Current.MainWindow.Hide();

                    // Mở MainWindow theo vai trò
                    switch (user.Role)
                    {
                        case "Owner":
                            new OwnerMainWindow(user).Show();
                            break;
                        case "Inspector":
                            new InspectorMainWindow(user).Show();
                            break;
                        case "Police":
                            new PoliceMainWindow(user).Show();
                            break;
                        case "Station":
                            new StationMainWindow(user).Show();
                            break;
                        default:
                            MessageBox.Show("Vai trò không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
