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

namespace ReceptionClientServerApp.Pages
{
    /// <summary>
    /// Interaction logic for HotelroomsPage.xaml
    /// </summary>
    public partial class HotelroomsPage : Page
    {
        private DataBase.CorpusReceptionEntities1 db;
        public HotelroomsPage()
        {
            InitializeComponent();
            DataContext = this;
            Hotelrooms.ItemsSource = SourceCore.corpusReception.Hotelrooms.ToList();
            DataChangeColumn.Width = new GridLength(0);
            db = new DataBase.CorpusReceptionEntities1();
            DataBase.RoomCategories RoomCategory = new DataBase.RoomCategories();
            int index = 0;
            //foreach (var item in List<>())
            //{

            //}
        }

        private void AddData(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateData(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteData(object sender, RoutedEventArgs e)
        {

        }

        private void ShowDataChanger(object sender, RoutedEventArgs e)
        {

        }

        private void EnableButtons()
        {
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            Hotelrooms.IsEnabled = true;
        }

        private void DisableButtons()
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            Hotelrooms.IsEnabled = false;
        }

        private void ShowDataChanger()
        {
            DisableButtons();
            if (DataChangeColumn.Width == new GridLength(0))
                DataChangeColumn.Width = new GridLength(300);
            else
                DataChangeColumn.Width = new GridLength(0);
        }

        private void ShowDataCopier(object sender, RoutedEventArgs e)
        {

        }


        private void ShowDataAdder(object sender, RoutedEventArgs e)
        {
            ShowDataChanger();
            ClearDataChanger();
            if (DataChangeColumn.Width == new GridLength(300))
                AddButton.Visibility = Visibility.Visible;
            else
                AddButton.Visibility = Visibility.Hidden;
        }

        private void ClearDataChanger()
        {

        }

        private void ActivateStaffAdd(object sender, RoutedEventArgs e)
        {

        }

        private void CloseDataChanger(object sender, RoutedEventArgs e)
        {
            DataChangeColumn.Width = new GridLength(0);
            EnableButtons();
        }
    }
}
