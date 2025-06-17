using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prn_Project.Models;
using System.Linq;
using System.Windows;

namespace Prn_Project.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            using (var context = new EmissionInspectionContext())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.Email == Email && u.Password == Password); // Nên mã hóa pass thực tế

                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Mở MainWindow theo vai trò
                    Application.Current.MainWindow.Hide();
                    switch (user.Role)
                    {
                        case "Owner":
                            new Views.Owner.OwnerMainWindow(user).Show();
                            break;
                        case "Inspector":
                            new Views.Inspector.InspectorMainWindow(user).Show();
                            break;
                        case "Police":
                            new Views.Police.PoliceMainWindow(user).Show();
                            break;
                        case "Station":
                            new Views.Station.StationMainWindow(user).Show();
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
