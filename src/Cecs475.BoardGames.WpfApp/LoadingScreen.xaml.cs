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
using System.Windows.Shapes;

namespace Cecs475.BoardGames.WpfApp
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Window
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        async void OnLoad(object sender, RoutedEventArgs e)
        {
            var webAPI = new WebClient();
            await webAPI.ProcessGames();
            var gameChoiceWindow = new GameChoiceWindow();
            this.Close();
            gameChoiceWindow.Show();
            
        }
    }
}
