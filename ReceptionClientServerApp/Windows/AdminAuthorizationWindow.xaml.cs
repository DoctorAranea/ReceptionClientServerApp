using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReceptionClientServerApp.Windows
{
    /// <summary>
    /// Interaction logic for AdminAuthorizationWindow.xaml
    /// </summary>
    public partial class AdminAuthorizationWindow : Window
    {
        string adminLogin;
        string adminPassword;
        public AdminAuthorizationWindow()
        {
            InitializeComponent();
            adminLogin = "Admin";
            adminPassword = "WhiteCrow";
            LoginText.Focus();
        }

        

        private void AuthorizationCommit(object sender, RoutedEventArgs e)
        {
            if (LoginText.Text == adminLogin && PasswordText.Password == adminPassword)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void FocusOnPass(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                PasswordText.Focus();
        }

        private void TryToLogin(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (LoginText.Text == adminLogin && PasswordText.Password == adminPassword)
                {
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
        }
    }
}
