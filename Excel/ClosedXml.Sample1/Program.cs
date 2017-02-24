using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedXml.Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\sercanakmaz\Desktop\Lead to Sales\LMS-2016.xlsx";

            FileInfo fi = new FileInfo(filePath);
            XSSFWorkbook workBook = new XSSFWorkbook(fi);
            ISheet sheet = workBook.GetSheet("Final");
            for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);

                if (row == null) continue;

                var cell = row.GetCell(13);

                Console.WriteLine(cell.DateCellValue);
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
