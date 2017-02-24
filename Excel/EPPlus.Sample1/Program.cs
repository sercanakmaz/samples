using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlus.Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\sercanakmaz\Desktop\Lead to Sales\LMS-2016.xls";
            FileInfo fi = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fi))
            {
                var workSheet = package.Workbook.Worksheets["Final"];

                var cell = workSheet.Cells[1, 13];

                var date = cell.GetValue<DateTime>();

                Console.WriteLine(date);
            }
        }
    }
}
