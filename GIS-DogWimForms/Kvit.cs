using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIS_DogWimForms
{
    class Kvit
    {
        Excel razdel1 = new Excel();
        Excel razdel2 = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";

        public void CreatKvit()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;


        }
    }
}
