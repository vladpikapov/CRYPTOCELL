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

namespace OOP.Frames
{
    /// <summary>
    /// Логика взаимодействия для LogInFrame.xaml
    /// </summary>
    public partial class LogInFrame : Page
    {
        public LogInFrame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Application.Current.MainWindow.Close();
            main.Show();
            
           
        }

       
    }
}
