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
            Dictionary<String,String> informations = Auth.Login(tbx_email.Text, pbx_password.Password);
            if (informations["message"] == "Success")
            {
                switch (informations["role"])
                {
                    case "1":
                        ShellWindow agentWindow = new ShellWindow();
                        agentWindow.Show();

                        this.Close();
                        break;
                    case "2":
                        SalerWindow salerWindow = new SalerWindow();
                        salerWindow.Show();

                        this.Close();
                        break;
                }
                
            }
            else
            {
                tbx_message.Text = informations["message"];
            }

        }
    }
}
