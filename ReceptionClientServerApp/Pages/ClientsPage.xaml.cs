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
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private DataBase.CorpusReceptionEntities1 db;
        
        public ClientsPage()
        {
            InitializeComponent();
            DataContext = this;
            Clients.ItemsSource = SourceCore.corpusReception.Clients.ToList();
            DataChangeColumn.Width = new GridLength(0);
            db = new DataBase.CorpusReceptionEntities1();
        }  
        private void ClearDataChanger()
        {
            Lastname.Text = "";
            Name.Text = "";
            Middlename.Text = "";
            Phonenum.Text = "";
            Address.Text = "";
            Birthday.Text = "";
        }

        private void EnableButtons()
        {
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            Clients.IsEnabled = true;
        }

        private void DisableButtons()
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            Clients.IsEnabled = false;
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
                DataBase.Clients Client = new DataBase.Clients();
                Client.lastname = Lastname.Text;
                Client.name = Name.Text;
                Client.middlename = Middlename.Text;
                Client.phonenum = Phonenum.Text;
                Client.address = Address.Text;
                Client.birthday = DateTime.Parse(Birthday.Text);
                db.Clients.Add(Client);
                db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена!");
                Clients.ItemsSource = SourceCore.corpusReception.Clients.ToList();
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

            if (Clients.SelectedItems.Count > 1)
                message = "Вы действительно хотите удалить выбранные записи?";
            else
                message = "Вы действительно хотите удалить выбранную запись?";

            if (MessageBox.Show(message, "Удаление записей", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var item in Clients.SelectedItems)
                    {
                        SourceCore.corpusReception.Clients.Remove((DataBase.Clients)item);
                    }

                    SourceCore.corpusReception.SaveChanges();
                    Clients.ItemsSource = SourceCore.corpusReception.Clients.ToList();
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
            if (Clients.SelectedItems.Count == 1)
            {
                DataBase.Clients bufClient = (DataBase.Clients)Clients.SelectedItem;
                ShowDataAdder(sender, e);
                Lastname.Text = bufClient.lastname;
                Name.Text = bufClient.name;
                Middlename.Text = bufClient.middlename;
                Phonenum.Text = bufClient.phonenum;
                Address.Text = bufClient.address;
                string bufBirthday = bufClient.birthday.ToString();
                var split = bufBirthday.Split(' ');
                Birthday.Text = split[0];
            }
            else
            {
                MessageBox.Show("Выберите одну запись!");
            }
        }

        private void ShowDataChanger(object sender, RoutedEventArgs e)
        {
            ClearDataChanger();
            if (Clients.SelectedItems.Count == 1)
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
                var Client = (DataBase.Clients)Clients.SelectedItem;

                string connectionString = "Server=server03; Database=CorpusReception; Trusted_Connection=True;";
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                string sql = string.Format("" +
                    "Update Clients Set " +
                    "lastname = '{0}'," +
                    "name = '{1}'," +
                    "middlename = '{2}'," +
                    "phonenum = '{3}'," +
                    "address = '{4}'," +
                    "birthday = '{5}'" +
                    "Where id = '{6}'",
                    Lastname.Text, Name.Text, Middlename.Text,
                    Phonenum.Text, Address.Text, DateTime.Parse(Birthday.Text), Client.id);
                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    cmd.ExecuteNonQuery();
                }
                connect.Close();
                //Client.lastname = Lastname.Text;
                //Client.name = Name.Text;
                //Client.middlename = Middlename.Text;
                //Client.phonenum = Phonenum.Text;
                //Client.address = Address.Text;
                //Client.birthday = DateTime.Parse(Birthday.Text);
                db.SaveChanges();
                SourceCore.corpusReception = new DataBase.CorpusReceptionEntities1();
                MessageBox.Show("Запись успешно изменена!");
                Clients.ItemsSource = SourceCore.corpusReception.Clients.ToList();
                CloseDataChanger(sender, e);
            }
            catch
            {
                MessageBox.Show("Ошибка изменения записи!");
            }
        }
    }
}
