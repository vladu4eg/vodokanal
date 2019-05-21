using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    class UpdateMegaBilling
    {
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999999;Password=" + Protect.PasswordMysql);
        public void SendToBD(string url, string command)
        {
            Clear clear = new Clear();
            clear.ImportMB(command);
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("LOAD DATA LOCAL INFILE '{0}' INTO TABLE vlad_m.{1} CHARACTER SET cp1251 FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';", url.Replace("\\", "\\\\"), command);
            myCommand.Prepare();
            int count = myCommand.ExecuteNonQuery();
            myConnection.Close();
            MessageBox.Show(command + " - " + count);
        }
    }

}