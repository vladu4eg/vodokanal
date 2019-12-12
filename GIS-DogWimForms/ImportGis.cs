using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIS_DogWimForms
{
    class ImportGis
    {
        Excel importFile = new Excel();
        List<string> Rows = new List<string>();

        StringBuilder sCommand;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

        public void ImportLS(string path, string name_db)
        {
            importFile.FileOpen(path);

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;
            importFile.Rows.RemoveAt(0);

            sCommand = new StringBuilder("INSERT INTO " + name_db + " VALUES ");

            for (int i = 0; i < importFile.Rows.Count(); i++)
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}')",
                    MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][1].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][4].ToString())));
            }

            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            importFile.Rows.Clear();
            myConnection.Close();
            sCommand.Clear();
            Rows.Clear();
        }

        public void ImpotGis(string path)
        {
            importFile.FileOpen(path);
            importFile.Rows.RemoveRange(0, 2);

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            sCommand = new StringBuilder("INSERT INTO gis_id VALUES ");

            for (int i = 0; i < importFile.Rows.Count(); i++)
            {
                Rows.Add(string.Format("('{0}','{1}','{2}')",
                    MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][42].ToString())));
            }

            importFile.Rows.Clear();

            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            Rows.Clear();

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
                sCommand.Clear();
            }
            myConnection.Close();

        }

        public void ImportObject(string path)
        {
            importFile.FileOpen(path);

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            sCommand = new StringBuilder("INSERT INTO gis_object_adress VALUES ");

            importFile.Rows.RemoveRange(0, 2);

            for (int i = 0; i < importFile.Rows.Count(); i++)
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')",
                    MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][1].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][4].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][5].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][6].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][7].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][8].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][9].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][10].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][11].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][12].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][13].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][14].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][15].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][16].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][17].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][18].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][19].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][20].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][21].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][22].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][23].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][24].ToString())));
            }

            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            importFile.Rows.Clear();
            myConnection.Close();
            sCommand.Clear();
            Rows.Clear();
        }

        public void ImportPY(string path)
        {
            importFile.FileOpen(path);

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            sCommand = new StringBuilder("INSERT INTO gis_py_main VALUES ");

            importFile.Rows.RemoveRange(0, 2);

            for (int i = 0; i < importFile.Rows.Count(); i++)
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}','{49}')",
                    MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][1].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][4].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][5].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][6].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][7].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][8].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][9].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][10].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][11].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][12].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][13].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][14].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][15].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][16].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][17].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][18].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][19].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][20].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][21].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][22].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][23].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][24].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][25].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][26].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][27].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][28].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][29].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][30].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][31].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][32].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][33].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][34].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][35].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][36].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][37].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][38].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][39].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][40].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][41].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][42].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][43].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][44].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][45].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][46].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][47].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][48].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][49].ToString())));
            }

            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            importFile.Rows.Clear();
            myConnection.Close();
            sCommand.Clear();
            Rows.Clear();
        }

        public void ImportPD(string path)
        {
            importFile.FileOpen(path);

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            sCommand = new StringBuilder("INSERT INTO gis_PD VALUES ");

            importFile.Rows.RemoveRange(0, 2);

            for (int i = 0; i < importFile.Rows.Count(); i++)
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}')",
                    MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][1].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][3].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][4].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][5].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][6].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][7].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][8].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][9].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][10].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][11].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][12].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][13].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][14].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][15].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][16].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][17].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][18].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][19].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][20].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][21].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][22].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][23].ToString())));
            }

            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");

            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), myConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
            importFile.Rows.Clear();
            myConnection.Close();
            sCommand.Clear();
            Rows.Clear();
        }

    }

}
