using System;
using tpmodul8_103022300037;

class Program
{
    static void Main()
    {
        CovidConfig covid = new CovidConfig();
        CovidConfig covidConfig = covid.readJson();

        Console.WriteLine("Config Awal:");
        Console.WriteLine("Satuan Suhu     : " + covidConfig.satuan_suhu);
        Console.WriteLine("Batas Hari Demam: " + covidConfig.batas_hari_demam);
        Console.WriteLine("Pesan Ditolak   : " + covidConfig.pesan_ditolak);
        Console.WriteLine("Pesan Diterima  : " + covidConfig.pesan_diterima);

        covidConfig.ubahSatuan(covidConfig);

        Console.WriteLine("\nConfig Setelah Ubah Satuan:");
        Console.WriteLine("Satuan Suhu     : " + covidConfig.satuan_suhu);
        Console.WriteLine("Batas Hari Demam: " + covidConfig.batas_hari_demam);
        Console.WriteLine("Pesan Ditolak   : " + covidConfig.pesan_ditolak);
        Console.WriteLine("Pesan Diterima  : " + covidConfig.pesan_diterima);

        Console.WriteLine("\nBerapa suhu badan anda saat ini? Dalam nilai " + covidConfig.satuan_suhu);
        if (!double.TryParse(Console.ReadLine(), out double suhu))
        {
            Console.WriteLine("Input suhu tidak valid.");
            return;
        }

        bool cekSuhu;
        if (covidConfig.satuan_suhu == "celcius")
        {
            cekSuhu = suhu > 36.5 && suhu < 37.5;
        }
        else if (covidConfig.satuan_suhu == "Fahrenheit")
        {
            cekSuhu = suhu > 97.7 && suhu < 99.5;
        }
        else
        {
            cekSuhu = false;
        }

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        if (!int.TryParse(Console.ReadLine(), out int lama))
        {
            Console.WriteLine("Input hari tidak valid.");
            return;
        }

        bool cekLama = lama < covidConfig.batas_hari_demam;

        Console.WriteLine("\n" + (cekLama && cekSuhu ? covidConfig.pesan_diterima : covidConfig.pesan_ditolak));
    }
}
