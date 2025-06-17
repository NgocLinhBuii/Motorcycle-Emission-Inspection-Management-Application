using BCrypt.Net;
using Prn_Project.Models;
using System.Windows;

namespace Prn_Project.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        private string _currentPassword;
        public string CurrentPassword
        {
            get => _currentPassword;
            set
            {
                if (_currentPassword != value)
                {
                    _currentPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set
            {
                if (_newPassword != value)
                {
                    _newPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        // Thay đổi mật khẩu
        public void ChangePassword(int userId)
        {
            // Kiểm tra mật khẩu hiện tại
            using (var context = new EmissionInspectionContext())
            {
                var user = context.Users.Find(userId);
                if (user != null && BCrypt.Net.BCrypt.Verify(CurrentPassword, user.Password))
                {
                    // Mã hóa mật khẩu mới
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(NewPassword);

                    // Cập nhật mật khẩu mới
                    user.Password = hashedPassword;
                    context.SaveChanges();

                    MessageBox.Show("Mật khẩu đã được thay đổi thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}
