using Prn_Project.ViewModels;
using System.Windows;
using System.Windows.Controls;

public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
        this.DataContext = new LoginViewModel(); // Đảm bảo DataContext đã được thiết lập
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    // Event handler cho PasswordChanged của PasswordBox
    private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        if (passwordBox != null)
        {
            var viewModel = this.DataContext as LoginViewModel;
            if (viewModel != null)
            {
                viewModel.Password = passwordBox.Password; // Cập nhật Password trong ViewModel
            }
        }
    }
}
