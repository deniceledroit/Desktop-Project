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
using BGInventory.Models;
using MahApps.Metro.Controls;

namespace BGInventory.Views
{
    /// <summary>
    /// Logique d'interaction pour AuthenticateWindow.xaml
    /// </summary>
    public partial class AuthenticateWindow : MetroWindow
    {
        public AuthenticateWindow()
        {
            InitializeComponent();
        }
        private void Btn_Signin_Click(object sender, RoutedEventArgs e)
        {
            String message = Auth.Login(tbx_email.Text, pbx_password.Password);
            if (message == "Success")
            {
                ShellWindow mainWindow = new ShellWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                tbx_message.Text = message;
            }

        }
    }
}
