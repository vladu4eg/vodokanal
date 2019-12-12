using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace isk
{
    public partial class Form1 : Form
    {

        Excel importFile = new Excel();
        List<string> Rows = new List<string>();
        MySqlDataReader MyDataReader;
        Excel isk = new Excel();

        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=vlad19957");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Import(openFileDialog1.FileName);

        }

        private void Import(string path)
        {
            importFile.FileOpen(path);

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("TRUNCATE TABLE isk_abon;");
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос


            StringBuilder sCommand = new StringBuilder("INSERT INTO isk_abon VALUES ");

            importFile.Rows.RemoveRange(0, 1);

            for (int i = 0; i < importFile.Rows.Count; i++)
            {
                Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}')",
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
                    MySqlHelper.EscapeString(importFile.Rows[i][35].ToString())));
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

        private void Create(int col_people = 1, int col_lgo = 0)
        {
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format(@"select distinct CONCAT(month,'.',year), '',usluga, tariff, month_volume, month_sum, month_lgo, month_lgo * tariff, month_pay_sum,  month_saldo,type_nach  from isk_abon
where isk_abon.isStep = 'False'
and STR_TO_DATE(CONCAT(month,'.',year), '%m.%Y') > STR_TO_DATE('01.2016', '%m.%Y')
order by STR_TO_DATE(CONCAT(month,'.',year), '%m.%Y') asc;");

            myCommand.Prepare();//подготавливает строку
            MyDataReader = myCommand.ExecuteReader();

            string nach = "0";

            while (MyDataReader.Read())
            {
                isk.AddRow("Период",
                "Начальный долг",
                "Проживающие",
                "Услуга",
                "Тариф",
                "м3",
                "руб",
                "Льгота м3",
                "Льгота руб",
                "Оплата",
                "Долг",
                "Тип расчета");

                isk.AddRow(MyDataReader.GetString(0),
                       nach,
                       "",
                       MyDataReader.GetString(1),
                       MyDataReader.GetString(2),
                       MyDataReader.GetString(3),
                       MyDataReader.GetString(4),
                       MyDataReader.GetString(5),
                       MyDataReader.GetString(6),
                       MyDataReader.GetString(7),
                       MyDataReader.GetString(8),
                       MyDataReader.GetString(9));

            }

            isk.FileSave("c:\\isk.xlsx");

            isk.Rows.Clear();

            MyDataReader.Close();
            myConnection.Close();

            MessageBox.Show("Готово! С:\\");
        }
    }

}
