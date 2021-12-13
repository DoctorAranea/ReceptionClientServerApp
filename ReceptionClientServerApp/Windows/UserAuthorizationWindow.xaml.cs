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
    /// Interaction logic for UserAuthorizationWindow.xaml
    /// </summary>
    public partial class UserAuthorizationWindow : Window
    {
        private DataBase.CorpusReceptionEntities1 db;
        public UserAuthorizationWindow()
        {
            InitializeComponent();
            try
            {
                db = new DataBase.CorpusReceptionEntities1();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
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
            {
                DataBase.UsersData User = db.UsersData.SingleOrDefault(U => U.login == LoginText.Text &&
           U.password == PasswordText.Password);
                if (User != null)
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            } 
        }

        private void AuthorizationCommit(object sender, RoutedEventArgs e)
        {
            DataBase.UsersData User = db.UsersData.SingleOrDefault(U => U.login == LoginText.Text &&
           U.password == PasswordText.Password);
            if (User != null)
            {
                MainWindow window = new MainWindow();
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
