using MySql.Data.MySqlClient;
using System.Windows;

namespace GIS_JKH
{
    class Pokaz
    {
        Excel ipy = new Excel();
        Excel odpy = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

        public void AddPokazIPY(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"SELECT distinct gis_py_main.full_adress, 
                gis_py_main.id_gis,  
                'Холодная вода', 
                mb_pokaz_ipy.pokaz1, 
                '', '', 
                date_format(STR_TO_DATE(mb_pokaz_ipy.data_pokaz,  '%d/%m/%Y'),'%d.%m.%Y') 
                FROM mb_pokaz_ipy, gis_py_main 
                where mb_pokaz_ipy.inv = gis_py_main.nomer 
                and mb_pokaz_ipy.ls = gis_py_main.LS 
                and gis_py_main.type = 'Индивидуальный' 
                and trim(mb_pokaz_ipy.inv) not in ('-', '*')  
                and gis_py_main.LS = mb_pokaz_ipy.ls  
                order by mb_pokaz_ipy.inv, mb_pokaz_ipy.ls ");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();
            
            int y1 = 1;
            int z1 = 1;

            while (MyDataReader.Read())
            {
                    ipy.AddRow(MyDataReader.GetString(0),
                               MyDataReader.GetString(1),
                               MyDataReader.GetString(2),
                               MyDataReader.GetString(3),
                               MyDataReader.GetString(4),
                               MyDataReader.GetString(5),
                               MyDataReader.GetString(6));
                    z1++;

                if (z1 % 20000 == 0)
                {
                    ipy.FileSave(path,"c:\\gis\\ipy" + y1 + "k.xlsx",1,1);
                    ipy.Rows.Clear();
                    y1++;
                }
            }
            ipy.FileSave(path,"c:\\gis\\ipy-Final.xlsx",1,1);
            ipy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }

        public void AddPokazODPY(string path)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"SELECT distinct gis_py_main.full_adress, 
                gis_py_main.id_gis,  
                'Холодная вода', 
                mb_pokaz_odpy.pokaz1, 
                '', '', 
                date_format(STR_TO_DATE(mb_pokaz_odpy.data_pokaz,  '%d/%m/%Y'),'%d.%m.%Y') 
                FROM mb_pokaz_odpy, gis_py_main 
                where mb_pokaz_odpy.inv = gis_py_main.nomer 
                and gis_py_main.type = 'Коллективный (общедомовой)' 
                and trim(mb_pokaz_odpy.inv) not in ('-', '*')  
                order by mb_pokaz_odpy.inv ");
            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();
            int y1 = 1;
            int z1 = 1;

            while (MyDataReader.Read())
            {
                odpy.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6));
                z1++;

                if (z1 % 20000 == 0)
                {
                    odpy.FileSave(path,"c:\\gis\\odpy" + y1 + "k.xlsx",1,1);
                    odpy.Rows.Clear();
                    y1++;
                }
            }

            odpy.FileSave(path,"c:\\gis\\odpy-Final.xlsx",1,1);
            odpy.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
