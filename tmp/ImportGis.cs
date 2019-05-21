
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmp
{
    class ImportGis
    {
        Excel importFile = new Excel();
        List<string> Rows = new List<string>();

        public void ImportLS(string path)
        {
            importFile.FileOpen(path);


            string temp = importFile.Rows[0][0].ToString();

            for(int i = 0; i < importFile.Rows.Count(); i++)
            {
                if(IsDigitsOnly(importFile.Rows[i][0].ToString()))
                {
                    importFile.Rows[i][2] = temp;
                }
                else
                {
                    temp = importFile.Rows[i][0].ToString();
                }

            }
            importFile.FileSave(path, "C:\\dolg1.xlsx", 1, 1);
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
