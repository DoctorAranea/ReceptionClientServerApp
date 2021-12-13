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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReceptionClientServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            RemoveTableButtons();
        }

        public void AddTableButtons()
        {
            CloseTableButton.Visibility = Visibility.Visible;
            ClearFrame.Visibility = Visibility.Hidden;
            LogoFrame.Visibility = Visibility.Hidden;
        }

        public void RemoveTableButtons()
        {
            CloseTableButton.Visibility = Visibility.Hidden;
            ClearFrame.Visibility = Visibility.Visible;
            LogoFrame.Visibility = Visibility.Visible;
        }

        private void ShowHotelroomStatesPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.HotelroomStatesPage());
            AddTableButtons();
        }

        private void ShowHotelroomsPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.HotelroomsPage());
            AddTableButtons();
        }

        private void ShowStaffPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.StaffPage());
            AddTableButtons();
        }

        private void ShowClientsPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.ClientsPage());
            AddTableButtons();
        }

        private void ShowRoomCategoriesPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.RoomCategoriesPage());
            AddTableButtons();
        }

        private void ShowReservationsPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.ReservationsPage());
            AddTableButtons();
        }

        private void GoToTables(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
            Tables.Visibility = Visibility.Visible;
        }

        private void GoToMenu(object sender, RoutedEventArgs e)
        {
            Tables.Visibility = Visibility.Hidden;
            AdditionalTables.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Visible;
        }

        private void CloseTable(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Content = null;
            RemoveTableButtons();
        }

        private void ShowExistencePage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.ExistencePage());
            AddTableButtons();
        }

        private void GoToAdditionalTables(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
            AdditionalTables.Visibility = Visibility.Visible;
        }
        private void AdminModeOn()
        {
            UsersDataButton.Visibility = Visibility.Visible;
            AdminModeONButton.Visibility = Visibility.Hidden;
            AdminModeOFFButton.Visibility = Visibility.Visible;
        }

        private void AuthorizationAdminClickButton(object sender, RoutedEventArgs e)
        {
            var win = new Windows.AdminAuthorizationWindow();
            if (win.ShowDialog() == true)
            {
                AdminModeOn();
            }
        }

        private void AdminModeOFF(object sender, RoutedEventArgs e)
        {
            UsersDataButton.Visibility = Visibility.Hidden;
            AdminModeONButton.Visibility = Visibility.Visible;
            AdminModeOFFButton.Visibility = Visibility.Hidden;
            ReceptionFrame.Content = null;
            RemoveTableButtons();
        }

        private void ShowUsersDataPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.UsersDataPage());
            AddTableButtons();
        }
    }
}
