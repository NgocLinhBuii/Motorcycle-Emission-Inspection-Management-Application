using BCrypt.Net;
using Prn_Project.Models;
using System.Windows;

public class RegisterViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }

    public void Register()
    {
        // Mã hóa mật khẩu
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);

        using (var context = new EmissionInspectionContext())
        {
            var user = new User
            {
                Email = Email,
                Password = hashedPassword // Lưu mật khẩu đã mã hóa
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
