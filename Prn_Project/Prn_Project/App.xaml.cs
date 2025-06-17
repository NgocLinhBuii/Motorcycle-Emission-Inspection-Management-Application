using System.Windows;
using Prn_Project.Models;
using Prn_Project.Views.Owner;

namespace Prn_Project.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Login()
        {
            using var context = new EmissionInspectionContext();
            var user = context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if (user != null)
            {
                MessageBox.Show("Đăng nhập thành công!");
                Application.Current.MainWindow?.Close();
                new OwnerMainWindow(user).Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
