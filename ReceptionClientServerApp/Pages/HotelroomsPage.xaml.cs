using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string connectionString = "Server=server03; Database=CorpusReception; Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connectionString);
            List<string> roomCategories = new List<string>();
            using (connect)
            {
                connect.Open();
                try
                {
                    string sql = $"select * from RoomCategories";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            roomCategories.Add(reader.GetValue(1).ToString());
                        }
                        reader.Close();
                    }
                    RoomCategory.ItemsSource = roomCategories;
                    RoomCategory.SelectedIndex = 0;
                }
                catch
                {
                    MessageBox.Show("Неудалось получить категории!");
                }

                List<string> reservations = new List<string>();
                try
                {
                    string sql = $"select * from Reservations";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            reservations.Add(reader.GetValue(1).ToString());
                        }
                        reader.Close();
                    }
                    Reservations.ItemsSource = reservations;
                    Reservations.SelectedIndex = 3;
                }
                catch
                {
                    MessageBox.Show("Неудалось получить категории!");
                }
                connect.Close();
            }
            db = new DataBase.CorpusReceptionEntities1();
            
        }

        private void AddData(object sender, RoutedEventArgs e)
        {
            DataBase.Hotelrooms bufRoom = db.Hotelrooms.SingleOrDefault(H => H.num.ToString() == HotelroomNumber.Text);
            if (bufRoom != null)
            {
                MessageBox.Show("Данный номер уже записан в базе!");
                return;
            }
            try
            {
                DataBase.Hotelrooms Hotelroom = new DataBase.Hotelrooms();
                DataBase.RoomCategories NeedCategory = db.RoomCategories.SingleOrDefault(C => C.name == RoomCategory.Text);
                DataBase.Reservations NeedReservation = db.Reservations.SingleOrDefault(R => R.name == Reservations.Text);
                Hotelroom.num = int.Parse(HotelroomNumber.Text);
                Hotelroom.categoryid = NeedCategory.id;
                Hotelroom.reservationid = NeedReservation.id;
                db.Hotelrooms.Add(Hotelroom);
                db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена!");
                Hotelrooms.ItemsSource = SourceCore.corpusReception.Hotelrooms.ToList();
                CloseDataChanger(sender, e);
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки записи!");
            }
        }

        private void UpdateData(object sender, RoutedEventArgs e)
        {
            try
            {
                var Hotelroom = (DataBase.Hotelrooms)Hotelrooms.SelectedItem;
                DataBase.RoomCategories NeedCategory = db.RoomCategories.SingleOrDefault(C => C.name == RoomCategory.Text);
                DataBase.Reservations NeedReservation = db.Reservations.SingleOrDefault(R => R.name == Reservations.Text);
                string connectionString = "Server=server03; Database=CorpusReception; Trusted_Connection=True;";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = $"update Hotelrooms set num = {int.Parse(HotelroomNumber.Text)}, categoryid = {NeedCategory.id}, reservationid = {NeedReservation.id} where id = {Hotelroom.id}";
                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.ExecuteNonQuery();
                }
                connect.Close();
                db.SaveChanges();
                MessageBox.Show("Запись успешно изменена!");
                SourceCore.corpusReception = new DataBase.CorpusReceptionEntities1();
                Hotelrooms.ItemsSource = SourceCore.corpusReception.Hotelrooms.ToList();
                CloseDataChanger(sender, e);
            }
            catch
            {
                MessageBox.Show("Ошибка изменения записи!");
            }
        }

        private void DeleteData(object sender, RoutedEventArgs e)
        {
            string message = "";

            if (Hotelrooms.SelectedItems.Count > 1)
                message = "Вы действительно хотите удалить выбранные записи?";
            else
                message = "Вы действительно хотите удалить выбранную запись?";

            if (MessageBox.Show(message, "Удаление записей", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var item in Hotelrooms.SelectedItems)
                    {
                        SourceCore.corpusReception.Hotelrooms.Remove((DataBase.Hotelrooms)item);
                    }

                    SourceCore.corpusReception.SaveChanges();
                    Hotelrooms.ItemsSource = SourceCore.corpusReception.Hotelrooms.ToList();
                    MessageBox.Show("Выбранные записи успешно удалены!");
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления записи!");
                    SourceCore.corpusReception = new DataBase.CorpusReceptionEntities1();
                }
            }
        }

        private void ShowDataChanger(object sender, RoutedEventArgs e)
        {
            ClearDataChanger();
            if (Hotelrooms.SelectedItems.Count == 1)
            {
                ShowDataCopier(sender, e);
                UpdateButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Выберите одну запись!");
            }
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
            ClearDataChanger();
            if (Hotelrooms.SelectedItems.Count == 1)
            {
                DataBase.Hotelrooms bufHotelroom = (DataBase.Hotelrooms)Hotelrooms.SelectedItem;
                DataBase.RoomCategories bufCategory = db.RoomCategories.SingleOrDefault(C => C.id == bufHotelroom.categoryid);
                DataBase.Reservations bufReservation = db.Reservations.SingleOrDefault(R => R.id == bufHotelroom.reservationid);
                ShowDataAdder(sender, e);
                HotelroomNumber.Text = bufHotelroom.num.ToString();
                RoomCategory.Text = bufCategory.name;
                Reservations.Text = bufReservation.name;
            }
            else
            {
                MessageBox.Show("Выберите одну запись!");
            }
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
            HotelroomNumber.Text = "";
            RoomCategory.SelectedIndex = 0;
            Reservations.SelectedIndex = 2;
        }

        private void CloseDataChanger(object sender, RoutedEventArgs e)
        {
            DataChangeColumn.Width = new GridLength(0);
            EnableButtons();
        }
    }
}
