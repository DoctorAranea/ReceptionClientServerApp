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
    /// Interaction logic for HotelroomStatesPage.xaml
    /// </summary>
    public partial class HotelroomStatesPage : Page
    {
        public HotelroomStatesPage()
        {
            InitializeComponent();
            DataContext = this;
            HotelroomStates.ItemsSource = SourceCore.corpusReception.RoomStates.ToList();
        }
    }
}
