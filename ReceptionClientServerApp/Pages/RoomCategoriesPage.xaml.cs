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
    /// Interaction logic for RoomCategoriesPage.xaml
    /// </summary>
    public partial class RoomCategoriesPage : Page
    {
        private DataBase.CorpusReceptionEntities1 db;
        public RoomCategoriesPage()
        {
            InitializeComponent();
            DataContext = this;
            RoomCategories.ItemsSource = SourceCore.corpusReception.RoomCategories.ToList();
            DataChangeColumn.Width = new GridLength(0);
            db = new DataBase.CorpusReceptionEntities1();
        }
        private void ClearDataChanger()
        {
            Name.Text = "";
            PriceForNight.Text = "";
            CountOfRooms.Text = "";
            CountSingleBed.Text = "";
            CountDoubleBed.Text = "";
            CountExtraBed.Text = "";
            CountWC.Text = "";
            WithBathroom.IsChecked = false;
            WithShower.IsChecked = false;
            WithFridge.IsChecked = false;
            WithSofa.IsChecked = false;
            WithTV.IsChecked = false;
            WithTelephone.IsChecked = false;
            WithMinibar.IsChecked = false;
        }

        private void EnableButtons()
        {
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            RoomCategories.IsEnabled = true;
        }

        private void DisableButtons()
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            RoomCategories.IsEnabled = false;
        }

        private void ShowDataChanger()
        {
            DisableButtons();
            if (DataChangeColumn.Width == new GridLength(0))
                DataChangeColumn.Width = new GridLength(300);
            else
                DataChangeColumn.Width = new GridLength(0);
        }

        private void CloseDataChanger(object sender, RoutedEventArgs e)
        {
            DataChangeColumn.Width = new GridLength(0);
            EnableButtons();
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

        private void AddData(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.RoomCategories RoomCategory = new DataBase.RoomCategories();
                RoomCategory.name = Name.Text;
                RoomCategory.pricefornight = decimal.Parse(PriceForNight.Text);
                RoomCategory.countofrooms = int.Parse(CountOfRooms.Text);
                RoomCategory.countsinglebed = short.Parse(CountSingleBed.Text);
                RoomCategory.countdoublebed = short.Parse(CountDoubleBed.Text);
                RoomCategory.countextrabed = short.Parse(CountExtraBed.Text);
                RoomCategory.countwc = short.Parse(CountWC.Text);

                int bufwithbathroom;
                int bufwithshower;
                int bufwithfridge;
                int bufwithsofa;
                int bufwithtv;
                int bufwithtelephone;
                int bufwithminibar;

                if ((bool)WithBathroom.IsChecked)
                    bufwithbathroom = 2;
                else
                    bufwithbathroom = 3;

                if ((bool)WithShower.IsChecked)
                    bufwithshower = 2;
                else
                    bufwithshower = 3;

                if ((bool)WithFridge.IsChecked)
                    bufwithfridge = 2;
                else
                    bufwithfridge = 3;

                if ((bool)WithSofa.IsChecked)
                    bufwithsofa = 2;
                else
                    bufwithsofa = 3;

                if ((bool)WithTV.IsChecked)
                    bufwithtv = 2;
                else
                    bufwithtv = 3;

                if ((bool)WithTelephone.IsChecked)
                    bufwithtelephone = 2;
                else
                    bufwithtelephone = 3;

                if ((bool)WithMinibar.IsChecked)
                    bufwithminibar = 2;
                else
                    bufwithminibar = 3;

                RoomCategory.withbathroom = bufwithbathroom;
                RoomCategory.withshower = bufwithshower;
                RoomCategory.withfridge = bufwithfridge;
                RoomCategory.withsofa = bufwithsofa;
                RoomCategory.withtv = bufwithtv;
                RoomCategory.withtelephone = bufwithtelephone;
                RoomCategory.withminibar = bufwithminibar;


                db.RoomCategories.Add(RoomCategory);
                db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена!");
                RoomCategories.ItemsSource = SourceCore.corpusReception.RoomCategories.ToList();
                CloseDataChanger(sender, e);
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки записи!");
            }
        }

        private void DeleteData(object sender, RoutedEventArgs e)
        {
            string message = "";

            if (RoomCategories.SelectedItems.Count > 1)
                message = "Вы действительно хотите удалить выбранные записи?";
            else
                message = "Вы действительно хотите удалить выбранную запись?";

            if (MessageBox.Show(message, "Удаление записей", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var item in RoomCategories.SelectedItems)
                    {
                        SourceCore.corpusReception.RoomCategories.Remove((DataBase.RoomCategories)item);
                    }
                    SourceCore.corpusReception.SaveChanges();
                    RoomCategories.ItemsSource = SourceCore.corpusReception.RoomCategories.ToList();
                    MessageBox.Show("Выбранные записи успешно удалены!");
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления записи!");
                }
            }
        }

        private void ShowDataCopier(object sender, RoutedEventArgs e)
        {
            ClearDataChanger();
            if (RoomCategories.SelectedItems.Count == 1)
            {
                DataBase.RoomCategories bufRoomCategory = (DataBase.RoomCategories)RoomCategories.SelectedItem;
                ShowDataAdder(sender, e);

                Name.Text = bufRoomCategory.name;
                PriceForNight.Text = bufRoomCategory.pricefornight.ToString();
                CountOfRooms.Text = bufRoomCategory.countofrooms.ToString();
                CountSingleBed.Text = bufRoomCategory.countsinglebed.ToString();
                CountDoubleBed.Text = bufRoomCategory.countdoublebed.ToString();
                CountExtraBed.Text = bufRoomCategory.countextrabed.ToString();
                CountWC.Text = bufRoomCategory.countwc.ToString();

                if (bufRoomCategory.withbathroom == 2)
                    WithBathroom.IsChecked = true;
                else
                    WithBathroom.IsChecked = false;

                if (bufRoomCategory.withshower == 2)
                    WithShower.IsChecked = true;
                else
                    WithShower.IsChecked = false;

                if (bufRoomCategory.withfridge == 2)
                    WithFridge.IsChecked = true;
                else
                    WithFridge.IsChecked = false;

                if (bufRoomCategory.withsofa == 2)
                    WithSofa.IsChecked = true;
                else
                    WithSofa.IsChecked = false;

                if (bufRoomCategory.withtv == 2)
                    WithTV.IsChecked = true;
                else
                    WithTV.IsChecked = false;

                if (bufRoomCategory.withtelephone == 2)
                    WithTelephone.IsChecked = true;
                else
                    WithTelephone.IsChecked = false;

                if (bufRoomCategory.withminibar == 2)
                    WithMinibar.IsChecked = true;
                else
                    WithMinibar.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Выберите одну запись!");
            }
        }

        private void ShowDataChanger(object sender, RoutedEventArgs e)
        {
            ClearDataChanger();
            if (RoomCategories.SelectedItems.Count == 1)
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


        private void UpdateData(object sender, RoutedEventArgs e)
        {
            try
            {
                var RoomCategory = (DataBase.RoomCategories)RoomCategories.SelectedItem;

                int bufwithbathroom;
                int bufwithshower;
                int bufwithfridge;
                int bufwithsofa;
                int bufwithtv;
                int bufwithtelephone;
                int bufwithminibar;

                if ((bool)WithBathroom.IsChecked)
                    bufwithbathroom = 2;
                else
                    bufwithbathroom = 3;

                if ((bool)WithShower.IsChecked)
                    bufwithshower = 2;
                else
                    bufwithshower = 3;

                if ((bool)WithFridge.IsChecked)
                    bufwithfridge = 2;
                else
                    bufwithfridge = 3;

                if ((bool)WithSofa.IsChecked)
                    bufwithsofa = 2;
                else
                    bufwithsofa = 3;

                if ((bool)WithTV.IsChecked)
                    bufwithtv = 2;
                else
                    bufwithtv = 3;

                if ((bool)WithTelephone.IsChecked)
                    bufwithtelephone = 2;
                else
                    bufwithtelephone = 3;

                if ((bool)WithMinibar.IsChecked)
                    bufwithminibar = 2;
                else
                    bufwithminibar = 3;

                string connectionString = "Server=server03; Database=CorpusReception; Trusted_Connection=True;";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = string.Format("" +
                    "Update RoomCategories Set " +
                    "name = '{0}'," +
                    "countofrooms = '{1}'," +
                    "pricefornight = '{2}'," +
                    "countsinglebed = '{3}'," +
                    "countdoublebed = '{4}'," +
                    "countextrabed = '{5}'," +
                    "countwc = '{6}'," +
                    "withbathroom = '{7}'," +
                    "withshower = '{8}'," +
                    "withfridge = '{9}'," +
                    "withsofa = '{10}'," +
                    "withtv = '{11}'," +
                    "withtelephone = '{12}'," +
                    "withminibar = '{13}'" +
                    "Where id = '{14}'",
                    Name.Text, int.Parse(CountOfRooms.Text), float.Parse(PriceForNight.Text),
                    short.Parse(CountSingleBed.Text), short.Parse(CountDoubleBed.Text), short.Parse(CountExtraBed.Text),
                    short.Parse(CountWC.Text), bufwithbathroom, bufwithshower, bufwithfridge, bufwithsofa,
                    bufwithtv, bufwithtelephone, bufwithminibar, RoomCategory.id);
                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.ExecuteNonQuery();
                }
                connect.Close();
            //RoomCategory.name = Name.Text;
            //RoomCategory.pricefornight = decimal.Parse(PriceForNight.Text);
            //RoomCategory.countofrooms = int.Parse(CountOfRooms.Text);
            //RoomCategory.countsinglebed = short.Parse(CountSingleBed.Text);
            //RoomCategory.countdoublebed = short.Parse(CountDoubleBed.Text);
            //RoomCategory.countextrabed = short.Parse(CountExtraBed.Text);
            //RoomCategory.countwc = short.Parse(CountWC.Text);

            //RoomCategory.withbathroom = bufwithbathroom;
            //RoomCategory.withshower = bufwithshower;
            //RoomCategory.withfridge = bufwithfridge;
            //RoomCategory.withsofa = bufwithsofa;
            //RoomCategory.withtv = bufwithtv;
            //RoomCategory.withtelephone = bufwithtelephone;
            //RoomCategory.withminibar = bufwithminibar;
                db.SaveChanges();
                SourceCore.corpusReception = new DataBase.CorpusReceptionEntities1();
                MessageBox.Show("Запись успешно изменена!");
                RoomCategories.ItemsSource = SourceCore.corpusReception.RoomCategories.ToList();
                CloseDataChanger(sender, e);
            }
            catch
            {
                MessageBox.Show("Ошибка изменения записи!");
            }
        }
    }
}
