using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIS_DogWimForms
{
    class FastExcel
    {
        string Connect = string.Format("Database=vlad_m;Data Source=192.168.27.79;User Id=vlad_m;charset=cp1251;default command timeout = 999;Password=" + Protect.PasswordMysql);
        /*
        public void FileOpen(string path, string sCommand)
        {

            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            var workbook = new XLWorkbook(path);
            var ws1 = workbook.Worksheet(1);

            foreach (var xlRow in ws1.RangeUsed().Rows())
            {

                foreach (var xlCell in xlRow.Cells())
                {
                    var formula = xlCell.FormulaA1;
                    var value = xlCell.Value.ToString();

                    string targetCellValue = (formula.Length == 0) ? value : "=" + formula;

                    Rows.Add(string.Format("('{0}','{1}','{2}')",
                    MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][37].ToString())));

                    Rows[Rows.Count - 1].Add(targetCellValue);
                }
            }

            for (int i = 0; i < importFile.Rows.Count(); i++)
            {
                Rows.Add(string.Format("('{0}','{1}','{2}')",
                    MySqlHelper.EscapeString(importFile.Rows[i][2].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][0].ToString()),
                    MySqlHelper.EscapeString(importFile.Rows[i][37].ToString())));
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
            */
    }
}

