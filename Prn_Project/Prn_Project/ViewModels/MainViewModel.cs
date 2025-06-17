using System.Windows;
using System.Windows.Input;

namespace Prn_Project.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // Các thuộc tính hiển thị thông tin người dùng
        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }

        // Các lệnh cho chức năng trong MainWindow
        public ICommand LogoutCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand NavigateToSettingsCommand { get; set; }

        public MainViewModel()
        {
            // Khởi tạo các lệnh
            LogoutCommand = new RelayCommand(ExecuteLogout);
            ChangePasswordCommand = new RelayCommand(ExecuteChangePassword);
            NavigateToSettingsCommand = new RelayCommand(ExecuteNavigateToSettings);
        }

        // Hàm xử lý đăng xuất
        public void ExecuteLogout()
        {
            // Bạn có thể thêm logic để đăng xuất người dùng và chuyển về màn hình đăng nhập
            MessageBox.Show("Đăng xuất thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            // Chuyển hướng về LoginView hoặc ẩn MainWindow
            Application.Current.MainWindow.Hide();
            new LoginView().Show();
        }

        // Hàm xử lý thay đổi mật khẩu
        public void ExecuteChangePassword()
        {
            // Bạn có thể mở cửa sổ để thay đổi mật khẩu
            MessageBox.Show("Mở cửa sổ thay đổi mật khẩu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            // Ví dụ: mở cửa sổ ResetPasswordView
            var changePasswordView = new ChangePasswordViewModel();
            changePasswordView.ShowDialog();
        }

        // Hàm điều hướng đến trang cài đặt
        public void ExecuteNavigateToSettings()
        {
            // Mở cửa sổ Settings (Cài đặt)
            MessageBox.Show("Mở cửa sổ cài đặt", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            var settingsView = new SettingsView();
            settingsView.ShowDialog();
        }
    }
}
