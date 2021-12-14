﻿using System;
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
    /// Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        public StaffPage()
        {
            InitializeComponent();
            DataContext = this;
            Staff.ItemsSource = SourceCore.corpusReception.Staff.ToList();
            DataChangeColumn.Width = new GridLength(0);
        }

        private void ShowDataChanger(object sender, RoutedEventArgs e)
        {
            if (DataChangeColumn.Width == new GridLength(0))
                DataChangeColumn.Width = new GridLength(300);
            else
                DataChangeColumn.Width = new GridLength(0);
        }

        private void CloseDataChanger(object sender, RoutedEventArgs e)
        {
            DataChangeColumn.Width = new GridLength(0);
        }

        private void ShowDataAdder(object sender, RoutedEventArgs e)
        {
            if (DataChangeColumn.Width == new GridLength(0))
            {
                DataChangeColumn.Width = new GridLength(300);
                AddButton.Visibility = Visibility.Visible;
            }
            else
            {
                DataChangeColumn.Width = new GridLength(0);
                AddButton.Visibility = Visibility.Hidden;
            }   
        }
    }
}
