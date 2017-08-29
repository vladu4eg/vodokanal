using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GisDogV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> listAndressOK = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Connect = "Database=test1;Data Source=127.0.0.1;User Id=root;charset=cp1251";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("TRUNCATE TABLE result");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                
                myCommand.CommandText = string.Format("INSERT INTO result SELECT ok.id_dog FROM ok,adress WHERE adress.id=ok.id_dog");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myConnection.Close();
                MessageBox.Show("Result!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Connect = "Database=test1;Data Source=127.0.0.1;User Id=root;charset=cp1251";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("TRUNCATE TABLE ok");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                // добавить проверку на уникальность
                myCommand.CommandText = string.Format("INSERT INTO ok SELECT id_gis,id_dog,status FROM project WHERE status='{0}'", textBox1.Text);//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myConnection.Close();
                MessageBox.Show("Все OK!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<String> ListNameId = new List<String>();
            try
            {
                
                string Connect = "Database=test1;Data Source=127.0.0.1;User Id=root;charset=cp1251;default command timeout = 240";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE export");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("INSERT INTO export SELECT final.A,final.PUBL_B,final.NUM_DOG_C,final.DAT_DOG_D,final.DAT_VST_E,final.F,final.G,final.H,final.FAMIL_NAME_R,final.IMEN_NAME_R,final.OTCH_NAME_R,final.POL_L,final.M,final.SNILS,final.O,final.P,final.Q,final.R,final.SROK1,final.СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ,final.SROR2,final.СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ2,final.DAT_NACH,final.НЕТ,final.DAT_OK,final.НЕТ2,final.opis,final.ychet,final.kachestvo,final.plan,final.id_gis FROM final,result WHERE final.NUM_DOG_C = result.id");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("update export, ok set export.id_gis = ok.id_gis where export.NUM_DOG_C = ok.id_dog");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос



                myConnection.Close();
                MessageBox.Show("Готово! Бегом в БД :)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

                string Connect = "Database=test1;Data Source=127.0.0.1;User Id=root;charset=cp1251;default command timeout = 240";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE adress_gis");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("INSERT INTO adress_gis SELECT result.id,adress.full_adr,adress.houseguid FROM result,adress WHERE result.id=adress.id");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос


                myCommand.CommandText = string.Format("TRUNCATE TABLE new_with");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("INSERT INTO new_with SELECT firstwith.A,firstwith.B,firstwith.C, firstwith.DATA1,firstwith.DATA2 FROM firstwith,result WHERE result.id=firstwith.A");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myConnection.Close();
                MessageBox.Show("Готово! Бегом в БД (Adress_gis) :)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
