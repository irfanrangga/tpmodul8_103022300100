using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300100
{
    class CovidConfig
    {
        public Config config;
        public const string filePath = "covid_config.json";

        public CovidConfig()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {
                string configJson = File.ReadAllText(filePath);
                config = JsonSerializer.Deserialize<Config>(configJson);
            }
            catch(FileNotFoundException)
            {
                config = new Config
                {
                    satuan_suhu = "celcius",
                    batas_hari_demam = 14,
                    pesan_ditolak = "anda tidak diperbolehkan masuk ke dalam gedung ini",
                    pesan_diterima = "anda dipersilahkan untuk masuk ke dalam gedung ini"
                };

                SaveConfig();
            }
        }
        public void SaveConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string configJson = System.Text.Json.JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, configJson);
        }

        public bool CekKondisi(double suhuSekarang, int lamaDemam)
        {
            bool suhuNormal = false;
            bool durasiDemam = lamaDemam < config.batas_hari_demam;

            if(config.satuan_suhu == "celcius")
            {
                if(suhuSekarang >= 36.5 && suhuSekarang <= 37.5)
                {
                    suhuNormal = true;
                }
            } else if(config.satuan_suhu == "fahrenheit")
            {
                if(suhuSekarang >= 97.7 && suhuSekarang <= 99.5)
                {
                    suhuNormal = true;
                }
            }

            return suhuNormal && durasiDemam;
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu.ToLower() == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
            }
            else if (config.satuan_suhu.ToLower() == "fahrenheit")
            {
                config.satuan_suhu = "celcius";
            }

            SaveConfig();
        }
    }
    class Config
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }
}
