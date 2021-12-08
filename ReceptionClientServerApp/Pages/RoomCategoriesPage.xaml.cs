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
    /// Interaction logic for RoomCategoriesPage.xaml
    /// </summary>
    public partial class RoomCategoriesPage : Page
    {
        public RoomCategoriesPage()
        {
            InitializeComponent();
            DataContext = this;
            RoomCategories.ItemsSource = SourceCore.corpusReception.Room_Categories.ToList();
            /*
            List<string> with = new List<string>();
            with.Add("bathroom");
            with.Add("shower");
            with.Add("fridge");
            with.Add("sofa");
            with.Add("tv");
            with.Add("telephone");
            with.Add("minibar");

            foreach (var item in with)
            {
                if (Int32.Parse(item) > 0)
                    item = "Есть";
            }*/
        }


    }
}
