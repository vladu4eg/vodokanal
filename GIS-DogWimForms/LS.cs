using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class LS
    {
        Excel Ls = new Excel();
        Excel adress = new Excel();
        Excel dogovor = new Excel();
        MySqlDataReader MyDataReader;

        string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=vlad19957";

        public void CreateLS()
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();

            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("select distinct LS.l_schet, " +
                "LS.l_schet, " +
                "LS.ident, " +
                "LS.lsrso, " +
                "LS.Yav, " +
                "LS.Pomesh, " +
                "LS.Famil, " +
                "LS.Imen, " +
                "LS.Otch, " +
                "LS.IDENT_NO, " +
                "LS.O, " +
                "LS.DOC_NO, " +
                "LS.DOC_SE, " +
                "LS.DOC_DATE," +
                "'', '', '', '', '', ''," +
                "LS.KOL_GIL," +
                "LS.l_schet," +
                "''," +
                "ipadr_new.ipadr," +
                "case when object_adress.id_kvt != '' " +
                "then 'Жилое помещение' " +
                "else '' " +
                "end JIL, " +
                "case when object_adress.id_kvt != '' " +
                "then ipadr_new.pomesh " +
                "else '' " +
                "end pomesh, " +
                "LS.l_schet," +
                "'Договор ресурсоснабжения (ЛС РСО или ЛС РЦ)'," +
                "id_gis.id_gis " +
                "from LS, ipadr_new, object_adress,id_gis " +
                "where LS.l_schet NOT IN " +
                "(" +
                "SELECT distinct LS.l_schet " +
                "FROM LS, id_ls " +
                "WHERE LS.l_schet = id_ls.id " +
                ") " +
                "and LS.l_schet = ipadr_new.id " +
                "and LS.l_schet = id_gis.id " +
                "and ipadr_new.ipadr = object_adress.HOUSEGUID_fias " +
                "and ipadr_new.pomesh = object_adress.kv " +
                "and id_gis.`status` = 'Размещен' " +
                //"and ipadr_new.pomesh <> '' " +                 //мкд. нужно убрать <>, если проверяешь еще и ЖД
                "order by LS.l_schet; ");
            myCommand.Prepare();//подготавливает строку

            MyDataReader = myCommand.ExecuteReader();

            int y = 1;
            int z = 1;

            while (MyDataReader.Read())
            {
                Ls.AddRow(MyDataReader.GetString(0),
                           MyDataReader.GetString(1),
                           MyDataReader.GetString(2),
                           MyDataReader.GetString(3),
                           MyDataReader.GetString(4),
                           MyDataReader.GetString(5),
                           MyDataReader.GetString(6),
                           MyDataReader.GetString(7),
                           MyDataReader.GetString(8),
                           "", "", "", "", "",
                           /*
                           MyDataReader.GetString(9),
                           MyDataReader.GetString(10),
                           MyDataReader.GetString(11),
                           MyDataReader.GetString(12),
                           MyDataReader.GetString(13),
                           */
                           MyDataReader.GetString(14),
                           MyDataReader.GetString(15),
                           MyDataReader.GetString(16),
                           MyDataReader.GetString(17),
                           MyDataReader.GetString(18),
                           MyDataReader.GetString(19),
                           MyDataReader.GetString(20));

                adress.AddRow(MyDataReader.GetString(21),
                               MyDataReader.GetString(22),
                               MyDataReader.GetString(23),
                               MyDataReader.GetString(24),
                               MyDataReader.GetString(25));

                dogovor.AddRow(MyDataReader.GetString(26),
                                MyDataReader.GetString(27),
                                MyDataReader.GetString(28));

                z++;
                if (z % 1000 == 0)
                {
                    Ls.FileSave("c:\\gis\\LS" + y + "k.xlsx");
                    Ls.Rows.Clear();

                    adress.FileSave("c:\\gis\\adress" + y + "k.xlsx");
                    adress.Rows.Clear();

                    dogovor.FileSave("c:\\gis\\DOGLS" + y + "k.xlsx");
                    dogovor.Rows.Clear();

                    y++;
                }
            }
            dogovor.FileSave("c:\\gis\\DOGLS-Final.xlsx");
            adress.FileSave("c:\\gis\\adress-Final.xlsx");
            Ls.FileSave("c:\\gis\\LS-Final.xlsx");

            dogovor.Rows.Clear();
            Ls.Rows.Clear();
            adress.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
