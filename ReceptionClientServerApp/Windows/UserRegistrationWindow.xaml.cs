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
    /// Interaction logic for UserRegistrationWindow.xaml
    /// </summary>
    public partial class UserRegistrationWindow : Window
    {
        private DataBase.CorpusReceptionEntities1 db;
        public UserRegistrationWindow()
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
            {
                PasswordText.Focus();
            }
        }

        private void FocusOnRepeat(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RepeatPasswordText.Focus();
            }
        }

        private void TryToAdd(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (PasswordText.Password != "")
                {
                    if (PasswordText.Password == RepeatPasswordText.Password)
                    {
                        try
                        {
                            DataBase.UsersData User = new DataBase.UsersData();
                            User.login = LoginText.Text;
                            User.password = PasswordText.Password;
                            db.UsersData.Add(User);
                            db.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("Данный пользователь уже зарегистрирован!");
                        }
                        BackToAuthorization();
                    }
                    else
                    {
                        MessageBox.Show("Введённые пароли не совпадают!");
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль!");
                }
            }
        }

        private void BackToAuthorization()
        {
            UserAuthorizationWindow window = new UserAuthorizationWindow();
            window.Show();
            Close();
        }

        private void TryToAddButton(object sender, RoutedEventArgs e)
        {
            if (PasswordText.Password != "")
            {
                if (PasswordText.Password == RepeatPasswordText.Password)
                {
                    try
                    {
                        DataBase.UsersData User = new DataBase.UsersData();
                        User.login = LoginText.Text;
                        User.password = PasswordText.Password;
                        db.UsersData.Add(User);
                        db.SaveChanges();  
                    }
                    catch
                    {
                        MessageBox.Show("Данный пользователь уже зарегистрирован!");
                    }
                    BackToAuthorization();
                }
                else
                {
                    MessageBox.Show("Введённые пароли не совпадают!");
                }
            }
            else
            {
                MessageBox.Show("Введите пароль!");
            }
        }

        private void BackToAuthorizationButton(object sender, RoutedEventArgs e)
        {
            BackToAuthorization();
        }
    }
}
