using System;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103022300037
{
    public class CovidConfig
    {
        public string? satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string? pesan_ditolak { get; set; }
        public string? pesan_diterima { get; set; }

        public CovidConfig() { }

        public CovidConfig readJson()
        {
            string jsonString = File.ReadAllText("C:\\Users\\Dillan\\source\\repos\\TPMOD8_103022300037\\TPMOD8_103022300037\\covid_config.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Gunakan ini, bukan IncludeFields
            };

            CovidConfig? json = JsonSerializer.Deserialize<CovidConfig>(jsonString, options);
            if (json == null)
            {
                throw new Exception("Gagal membaca konfigurasi dari file JSON.");
            }

            return json;
        }

        public void ubahSatuan(CovidConfig json)
        {
            if (json.satuan_suhu == "celcius")
            {
                json.satuan_suhu = "Fahrenheit";
            }
            else
            {
                json.satuan_suhu = "celcius";
            }
        }
    }
}
