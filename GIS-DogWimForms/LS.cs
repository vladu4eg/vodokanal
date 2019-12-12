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

        string checkMKD;
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);

        public void CreateLS(bool chk_mkd, string path, string name_db)
        {
            if (chk_mkd)
                checkMKD = "and ipadr_new.pomesh <> '' ";
            else
                checkMKD = "";

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();

            myConnection.Open();
            myCommand.Connection = myConnection;
            if (name_db == "gis_ls")
            myCommand.CommandText = string.Format(@"select distinct mb_ls.ls,   
                mb_ls.ls,
                '',
                'ЛС РСО',
                'Нет',
                '',
                '',
                '',
                '',
                '',
                '',
                '',
                '',
                '',
                '', '', '', '', '', '', '',
                mb_ls.ls,
                '',
                tmp_ipadr_new.ipadr,
                case when gis_object_adress.type_dom = 'Многоквартирный'
                    then 'Жилое помещение'
                when gis_object_adress.type_dom = 'Жилой'
                    then ''
                when gis_object_adress.type_dom = 'Жилой дом блокированной застройки'
                    then 'Блок в доме блокированной застройки'
                end JIL,
                case when gis_object_adress.type_dom = 'Многоквартирный'
                    then tmp_ipadr_new.pomesh
                when gis_object_adress.type_dom = 'Жилой'
                    then ''
                when gis_object_adress.type_dom = 'Жилой дом блокированной застройки'
                     then tmp_ipadr_new.pomesh
                end pomesh,
                mb_ls.ls,
                'Договор ресурсоснабжения (ЛС РСО или ЛС РЦ)',
                gis_id.id_gis 
                from mb_ls, tmp_ipadr_new, gis_object_adress, gis_id 
                where mb_ls.ls NOT IN 
                ( 
                SELECT gis_ls.id 
                FROM gis_ls 
                ) 
                and mb_ls.ls = tmp_ipadr_new.id 
                and mb_ls.ls = gis_id.id 
                and tmp_ipadr_new.ipadr = gis_object_adress.HOUSEGUID_fias 
                and gis_object_adress.data_delete = '' 
                -- and tmp_ipadr_new.pomesh = gis_object_adress.kv 
                and gis_id.`status` = 'Размещен' "
                + checkMKD +
                "order by mb_ls.ls; ");
            else
                myCommand.CommandText = string.Format(@"select distinct mb_ls.ls,   
                mb_ls.ls,
                gis_ls_cancel.ls_jky,
                'ЛС РСО',
                'Нет',
                '',
                '',
                '',
                '',
                '',
                '',
                '',
                '',
                '',
                '', '', '', '', '', '', '',
                mb_ls.ls,
                '',
                tmp_ipadr_new.ipadr,
                case when gis_object_adress.type_dom = 'Многоквартирный'
                    then 'Жилое помещение'
                when gis_object_adress.type_dom = 'Жилой'
                    then ''
                when gis_object_adress.type_dom = 'Жилой дом блокированной застройки'
                    then 'Блок в доме блокированной застройки'
                end JIL,
                case when gis_object_adress.type_dom = 'Многоквартирный'
                    then tmp_ipadr_new.pomesh
                when gis_object_adress.type_dom = 'Жилой'
                    then ''
                when gis_object_adress.type_dom = 'Жилой дом блокированной застройки'
                     then tmp_ipadr_new.pomesh
                end pomesh,
                mb_ls.ls,
                'Договор ресурсоснабжения (ЛС РСО или ЛС РЦ)',
                gis_id.id_gis 
                from mb_ls, tmp_ipadr_new, gis_object_adress, gis_id, gis_ls_cancel
                where mb_ls.ls = gis_ls_cancel.id
                and mb_ls.ls = tmp_ipadr_new.id 
                and mb_ls.ls = gis_id.id 
                and tmp_ipadr_new.ipadr = gis_object_adress.HOUSEGUID_fias 
                and gis_object_adress.data_delete = '' "
                + checkMKD +
                "order by mb_ls.ls;");
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
                           /* и правда. Нахуй нужны эти комменты. Лучше потом ванговать. 
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
                    string path2 = "c:\\gis\\LS" + y + "k.xlsx";

                    Ls.FileSave(path, path2, 1,2);
                    Ls.Rows.Clear();

                    adress.FileSave(path2, path2,2,2);
                    adress.Rows.Clear();

                    dogovor.FileSave(path2, path2,3,2);
                    dogovor.Rows.Clear();

                    y++;
                }
            }
            Ls.FileSave(path, "c:\\gis\\LS_Final.xlsx", 1,2);
            adress.FileSave("c:\\gis\\LS_Final.xlsx", "c:\\gis\\LS_Final.xlsx", 2,2);
            dogovor.FileSave("c:\\gis\\LS_Final.xlsx", "c:\\gis\\LS_Final.xlsx", 3,2);


            dogovor.Rows.Clear();
            Ls.Rows.Clear();
            adress.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\gis\\");
        }
    }
}
