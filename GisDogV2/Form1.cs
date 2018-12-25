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
                string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;Password=vlad19957";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("TRUNCATE TABLE result");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                
                myCommand.CommandText = string.Format("INSERT INTO result SELECT ok.id_dog FROM ok,import_adress WHERE import_adress.id=ok.id_dog");//запрос: если есть такой логин в таблице
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
                string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;Password=vlad19957";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("TRUNCATE TABLE ok");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                // добавить проверку на уникальность
                myCommand.CommandText = string.Format("INSERT INTO ok SELECT id_gis,id_dog,status FROM import_project WHERE status='{0}'", textBox1.Text);//запрос: если есть такой логин в таблице
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
                
                string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE export");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("INSERT INTO export SELECT final.A,final.PUBL_B,final.NUM_DOG_C,final.DAT_DOG_D,final.DAT_VST_E,final.F,final.G,final.H,final.FAMIL_NAME_R,final.IMEN_NAME_R,final.OTCH_NAME_R,final.POL_L,final.M,final.SNILS,final.O,final.P,final.Q,final.R,final.SROK1,final.СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ,final.SROR2,final.СЛЕДУЮЩЕГОМЕСЯЦАЗАРАСЧЕТНЫМ2,final.DAT_NACH,final.НЕТ,final.DAT_OK,final.НЕТ2,final.id_gis FROM final,result WHERE final.NUM_DOG_C = result.id");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("update export, ok set export.id_gis = ok.id_gis where export.NUM_DOG_C = ok.id_dog");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос



                myConnection.Close();
                MessageBox.Show("Готово! Бегом в БД :) export");
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

                string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE export_adress_gis");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("INSERT INTO export_adress_gis SELECT result.id,import_adress.full_adr,import_adress.houseguid FROM result,import_adress WHERE result.id=import_adress.id");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос


                myCommand.CommandText = string.Format("TRUNCATE TABLE export_with");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("INSERT INTO export_with SELECT import_with.A,import_with.B,import_with.C, import_with.DATA1,import_with.DATA2 FROM import_with,result WHERE result.id=import_with.A");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myConnection.Close();
                MessageBox.Show("Готово! Бегом в БД (export_adress_gis) :)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
                try
                {
                    string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;Password=vlad19957";
                    MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                    MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = string.Format("TRUNCATE TABLE export_double");//запрос: если есть такой логин в таблице
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос
                
                    // добавить проверку на уникальность
                    myCommand.CommandText = string.Format("INSERT INTO export_double select id_dog, count(*) from import_double group by id_dog having count(*) > 1");//запрос: если есть такой логин в таблице
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос


                     myCommand.CommandText = string.Format("select count(id_dog) from export_double");//запрос: если есть такой логин в таблице
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос
                    int count = Convert.ToInt32(myCommand.ExecuteScalar());
                    myConnection.Close();
                    MessageBox.Show("Все export_double! " + count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                string Connect = "Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 240;Password=vlad19957";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;

                myCommand.CommandText = string.Format("TRUNCATE TABLE export_error");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("insert into export_error " +
                                                      "SELECT * FROM import_error_gis " +
                                                      "WHERE NOT EXISTS(" +
                                                      "SELECT * FROM import_error_LS " +
                                                      "WHERE import_error_LS.id = import_error_gis.id " +
                                                      "and import_error_LS.lastname = import_error_gis.lastname " +
                                                      "and import_error_LS.firtname = import_error_gis.firtname " +
                                                      "and import_error_LS.lastname = import_error_gis.lastname)");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                myCommand.CommandText = string.Format("select count(id) from export_error");//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос
                int count = Convert.ToInt32(myCommand.ExecuteScalar());

                myConnection.Close();
                MessageBox.Show("Готово export_error! Господи, спаси меня это этого: " + count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "select * from import_lischt join export_error on import_lischt.NUM_DOG_C = export_error.id join id_gis_and_LS on id_gis_and_LS.id_dog = import_lischt.NUM_DOG_C";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "SELECT * FROM export_error WHERE NOT EXISTS(SELECT * FROM import_error_LS WHERE import_error_LS.id = export_error.id)";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*
             * select * from import_with where EXISTS
(
select import_lischt.A 
from import_lischt 
join export_error on 
import_lischt.NUM_DOG_C = export_error.id 
join id_gis_and_LS 
on id_gis_and_LS.id_dog = import_lischt.NUM_DOG_C 
where import_lischt.A = import_with.A
)
             * 
             */
        }
    }
}
