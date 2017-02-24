using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOI.Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\sercanakmaz\Desktop\Lead to Sales\LMS-2016.xls";

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                HSSFWorkbook workBook = new HSSFWorkbook(stream);
                ISheet sheet = workBook.GetSheet("Final");
                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    var row = sheet.GetRow(rowIndex);

                    if (row == null) continue;

                    var cell = row.GetCell(13);

                    Console.WriteLine(cell.DateCellValue);
                }
            }

            Console.ReadKey();
        }
    }
    class LMSRaw
    {
        [DisplayName("LMS Kayıt")]
        public DateTime Date { get; set; }
    }
}
