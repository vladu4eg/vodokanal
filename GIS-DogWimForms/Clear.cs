using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIS_DogWimForms
{
    class Clear
    {
        StringBuilder sCommand = new StringBuilder("INSERT INTO import_lischt VALUES ");

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);
        string connectionString = string.Format("DATA SOURCE=SERVER;PASSWORD=" + Protect.PasswordOracleAndUser);


        //clear
        public void All()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE import_lischt;TRUNCATE TABLE import_vkh;TRUNCATE TABLE import_with;TRUNCATE TABLE ipadr_new;TRUNCATE TABLE PY;TRUNCATE TABLE LS;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void Adress()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE tmp_ipadr_new;TRUNCATE TABLE import_vkh;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void ImportMB(string table)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            if(table == "mb_buh")
                myCommand.CommandText = string.Format("DELETE FROM {0} where mb_buh.period = date_format(DATE_SUB(now(),INTERVAL + 1 MONTH), '%m.%Y');", table);
            else
                myCommand.CommandText = string.Format("TRUNCATE TABLE {0};",table);

            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void House()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE mb_house;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void AllGis()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE gis_ls;TRUNCATE TABLE gis_id;TRUNCATE TABLE gis_py_main;TRUNCATE TABLE gis_object_adress;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }

        public void GisPY()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE gis_py_main;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void GisLS(string name_db)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE {0};", name_db);
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void GisDogovor()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE gis_id;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void GisAdress()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE gis_object_adress;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
        public void GisPD()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;
            myCommand.CommandText = string.Format("DELETE FROM gis_PD where gis_PD.period = date_format(DATE_SUB(now(),INTERVAL + 1 MONTH), '%m.%Y');");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            myConnection.Close();
        }
    }
}
