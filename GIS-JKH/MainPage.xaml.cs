using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GIS_JKH
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        MySqlDataReader MyDataReader;
        MySqlConnection myConnection = new MySqlConnection();
        MySqlCommand myCommand = new MySqlCommand();
        Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
        Nullable<bool> result = false;

        string login;
        string password;
        string connect;
        string menu;

        public MainPage()
        {
            
        }

        public MainPage(string _login, string _password)
        {
            InitializeComponent();
            login = _login;
            password = _password;
            connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id='{0}';charset=cp1251;SslMode=none;default command timeout = 999;Password='{1}'", login, password);
            myConnection.ConnectionString = connect;
            myConnection.Open();
            myCommand.Connection = myConnection;
        }

        private void MenuItemDogovor_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            menu = menuItem.Header.ToString();

            DogovorStatistic statistic = new DogovorStatistic();
            LabelStatictic.Content = statistic.CheckCount();
            Button1.Content = "Новый";
            Button2.Content = "Проект";

            LabelStatictic.Visibility = Visibility.Visible;
            Button1.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            
        }

        private void MenuItemPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (menu == "Договор")
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    if (openFileDialog1.ShowDialog() == result)
                        return;
                    Dogovor dogovor = new Dogovor();
                    dogovor.CreateDogovor(openFileDialog1.FileName);
                }
                else if(menu == "ЛС")
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    if (openFileDialog1.ShowDialog() == result)
                        return;
                    LS ls = new LS();
                    ls.CreateLS(false, openFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show("Список пустой.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (menu == "Договор")
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    if (openFileDialog1.ShowDialog() == result)
                        return;
                    Dogovor dogovor = new Dogovor();
                    dogovor.ProjectDogovor(openFileDialog1.FileName);
                }
                else if (menu == "ЛС")
                {
                    openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    if (openFileDialog1.ShowDialog() == result)
                        return;
                    LS ls = new LS();
                    ls.CreateLS(true, openFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show("Список пустой.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
