using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul8_103022300100
{
    class MainClass
    {
        public static void Main(string[] agrs)
        {
            CovidConfig covidConfig = new CovidConfig();

            Console.WriteLine("Nilai Default JSON");
            Console.WriteLine($"Satuan Suhu: {covidConfig.config.satuan_suhu}");
            Console.WriteLine($"Batas Hari Demam: {covidConfig.config.batas_hari_demam}");
            Console.WriteLine($"Pesan Diterima: {covidConfig.config.pesan_diterima}");
            Console.WriteLine($"Pesan Ditolak: {covidConfig.config.pesan_ditolak}\n");

            Console.WriteLine("Berapa suhu badan anda saat ini? dalam satuan " + covidConfig.config.satuan_suhu);
            double suhuSekarang = double.Parse(Console.ReadLine());

            Console.WriteLine("Berapa lama anda mengalami gejala demam?");
            int lamaDemam = int.Parse(Console.ReadLine());

            bool kondisi = covidConfig.CekKondisi(suhuSekarang, lamaDemam);

            if (kondisi)
            {
                Console.WriteLine(covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(covidConfig.config.pesan_ditolak);
            }

            covidConfig.UbahSatuan();
            Console.WriteLine("\nNilai JSON setelah diubah");
            Console.WriteLine($"Satuan Suhu: {covidConfig.config.satuan_suhu}");
            Console.WriteLine($"Batas Hari Demam: {covidConfig.config.batas_hari_demam}");
            Console.WriteLine($"Pesan Diterima: {covidConfig.config.pesan_diterima}");
            Console.WriteLine($"Pesan Ditolak: {covidConfig.config.pesan_ditolak}");
        }
    }
}
