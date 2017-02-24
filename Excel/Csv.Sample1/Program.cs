using CsvFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\sercanakmaz\Desktop\Lead to Sales\LMS-2016.csv";

            var results = CsvFile.Read<Lead>(new CsvSource(filePath, Encoding.UTF8));

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
    public class Lead
    {
        public override string ToString()
        {
            return string.Format("Tarih: {0}, BayiAdi: {1}, BayiKodu: {2}, Telefon: {3}, CallCenterDurum: {4}, Kisi: {5}, Kaynak: {6}"
                , Tarih
                , BayiAdi
                , BayiKodu
                , Telefon
                , CallCenterDurum
                , Kisi
                , Kaynak);
        }
        public DateTime Tarih { get; set; }
        public string BayiAdi { get; set; }
        public string BayiKodu { get; set; }
        public string Telefon { get; set; }
        public string CallCenterDurum { get; set; }
        public string Kisi { get; set; }
        public string Kaynak { get; set; }
    }
}
