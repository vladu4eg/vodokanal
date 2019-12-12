﻿using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GIS_DogWimForms
{
    public class Excel
    {
        public List<List<string>> Rows = new List<List<string>>();
        public static int count = 0;

        public void FileOpen(string path)
        {
            using (XLWorkbook workbook = new XLWorkbook(path))
            {
                for (int i = 2; i <= workbook.Worksheets.Count(); i++) // Удаление лишних листов, но я не увидел улучшение производительности :(
                    workbook.Worksheet(i).Delete();
                IXLWorksheet ws1 = workbook.Worksheet(1);

                foreach (var xlRow in ws1.RangeUsed().Rows())
                {
                    Rows.Add(new List<string>());

                    foreach (var xlCell in xlRow.Cells())
                    {
                        var formula = xlCell.FormulaA1;
                        var value = xlCell.Value.ToString();

                        string targetCellValue = (formula.Length == 0) ? value : "=" + formula;

                        Rows[Rows.Count - 1].Add(targetCellValue);
                    }
                }
                workbook.Worksheet(1).Delete();
            }
        }

        public void FileSave(string path, string pathSave, int workNum, int numPos)
        {
            try
            {
                CreateDirIfNotExist(path, true);
                using (XLWorkbook wb = new XLWorkbook(path))
                {
                    var workSheet = wb.Worksheet(workNum);
                    for (int row = 0; row < Rows.Count; row++)
                    {
                        for (int col = 0; col < Rows[row].Count; col++)
                        {
                            var cellAdress = GetExcelPos(row + numPos, col);

                            if (Rows[row][col].StartsWith("="))
                            {
                                workSheet.Cell(cellAdress).FormulaA1 = Rows[row][col];
                            }
                            else
                            {
                                workSheet.Cell(cellAdress).Style.NumberFormat.Format = "@";
                                workSheet.Cell(cellAdress).Value = Rows[row][col];
                            }
                        }
                        count = 0;
                    }
                    wb.SaveAs(pathSave);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void AddRow(params string[] cells)
        {
            Rows.Add(cells.ToList());
        }

        public static string GetExcelPos(int row, int cell)
        {
            char[] alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            string alphResult = string.Empty;
            int temp = count / 26;
            if (cell >= 26)
            {
                alphResult = alph[temp] + alph[count % 26].ToString();
                count++;
            }
            else
            {
                alphResult = alph[cell].ToString();
            }

            return alphResult + (row + 1);
        }

        private void CreateDirIfNotExist(string dirPath, bool removeFilename = false)
        {
            if (removeFilename)
            {
                dirPath = Directory.GetParent(dirPath).FullName;
            }

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
    }
}