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
            ChangeTableButtons.Visibility = Visibility.Visible;
            ClearFrame.Visibility = Visibility.Hidden;
            LogoFrame.Visibility = Visibility.Hidden;
        }

        public void RemoveTableButtons()
        {
            CloseTableButton.Visibility = Visibility.Hidden;
            ChangeTableButtons.Visibility = Visibility.Hidden;
            ClearFrame.Visibility = Visibility.Visible;
            LogoFrame.Visibility = Visibility.Visible;
        }

        private void ShowHotelroomStatesPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.HotelroomStatesPage());
            TableName.Content = "Состояния комнат";
            AddTableButtons();
        }

        private void ShowHotelroomsPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.HotelroomsPage());
            TableName.Content = "Номера";
            AddTableButtons();
        }

        private void ShowStaffPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.StaffPage());
            TableName.Content = "Персонал";
            AddTableButtons();
        }

        private void ShowClientsPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.ClientsPage());
            TableName.Content = "Люди";
            AddTableButtons();
        }

        private void ShowRoomCategoriesPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.RoomCategoriesPage());
            TableName.Content = "Категории";
            AddTableButtons();
        }

        private void ShowReservationsPage(object sender, RoutedEventArgs e)
        {
            ReceptionFrame.Navigate(new Pages.ReservationsPage());
            TableName.Content = "Виды состояний";
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
            Menu.Visibility = Visibility.Visible;
        }

        private void CloseTable(object sender, RoutedEventArgs e)
        {
            TableName.Content = "";
            ReceptionFrame.Content = null;
            RemoveTableButtons();
        }
    }
}
