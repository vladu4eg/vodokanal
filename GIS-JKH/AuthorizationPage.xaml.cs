using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GIS_JKH
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int countEnter = 3; // количество попыток ввода пароля 

        public MainWindow()
        {
            InitializeComponent();

        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TextBoxLogin.Text.ToString()) & !String.IsNullOrEmpty(TextBoxPassword.Password))
                {
                    string Connect = string.Format("Database=vlad_m;Data Source='{0}';User Id='{1}';charset=cp1251;SslMode=none;default command timeout = 999;Password='{2}'", TextBoxServer.Text.ToString(), TextBoxLogin.Text.ToString(), TextBoxPassword.Password);
                    MySqlConnection myConnection = new MySqlConnection(Connect);
                    MySqlCommand myCommand = new MySqlCommand();

                    myConnection.Open();
                    myCommand.Connection = myConnection;

                    MainPage mainPage = new MainPage(TextBoxLogin.Text.ToString(), TextBoxPassword.Password);
                    mainPage.Show();
                    myConnection.Close();
                    this.Close();
                }
                else
                    MessageBox.Show("Вы не ввели логин и/или пароль!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                countEnter--;
            }

            if (countEnter == 0)
                this.Close();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
