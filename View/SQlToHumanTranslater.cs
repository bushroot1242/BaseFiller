using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFiller.View
{/// <summary>
/// Переводчик с SQL на человеческий
/// </summary>
    class SQlToHumanTranslater
    {
        private static Dictionary<string, string> dictionary;
        static SQlToHumanTranslater()
        {
            //заполнение словаря сделать сериализацией из файла
            dictionary = new Dictionary<string, string>();
            dictionary.Add("PCUser", "Пользователь - компьютер");
            dictionary.Add("PcManufacturer", "Производители ПК");
            dictionary.Add("Units", "Отделы");
            dictionary.Add("Users", "Пользователи");
            dictionary.Add("Departaments", "Департаменты");
            dictionary.Add("ResponsiblePerson", "Ответственные лица");
            dictionary.Add("MonitorManufacturers", "Производители мониторов");
            dictionary.Add("MonitorModels", "Модели мониторов");
            dictionary.Add("CpuManufacturer", "Производители ЦПУ");
            dictionary.Add("GpuModel", "Модель ГПУ");
            dictionary.Add("GpuManufacturer", "Производитель ГПУ");
            dictionary.Add("RamManufacturer", "Производитель ОЗУ");
            dictionary.Add("RamType", "Тип ОЗУ");
            dictionary.Add("Ram", "ОЗУ");
            dictionary.Add("HddManufacturer", "Производитель ЖД");
            dictionary.Add("Hdd", "Жесткие диски");
            dictionary.Add("MotherboardManufacturers", "Производитель мат. Платы");
            dictionary.Add("RepairsType", "Тип ремонта");
            dictionary.Add("RepairsStatus", "Статус ремонта");
            dictionary.Add("Motherboards", "Материнские платы");
            dictionary.Add("Posts", "Должности");
            dictionary.Add("RepairsHistory", "История ремонтов");
            dictionary.Add("OS", "Операционные системы");
            dictionary.Add("OsReplaceHistory", "История переустановок ОС");
            dictionary.Add("PcConfiguration", "Конфигурация ПК");
            dictionary.Add("CpuModel", "Модель ЦПУ");
            dictionary.Add("PC", "ПК");
            dictionary.Add("PcMonitors", "ПК - монитор");
            dictionary.Add("Monitors", "Мониторы");
            dictionary.Add("Modernization", "Апгрейд");
            dictionary.Add("Laptops", "Ноутбуки");


        }
        /// <summary>
        /// Возвращает переведенную на человеческий строку из БД, если найдет в словаре
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string TranslateToHuman(string sql)
        {
            if (dictionary.ContainsKey(sql))
                return dictionary[sql];
            return sql;
        }
        /// <summary>
        /// Вернет переведенную с человеческого на БДшную строку
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string TranslateToSQL(string word)
        {
            if (dictionary.ContainsValue(word))
                return dictionary.FirstOrDefault(x => x.Value == word).Key;
            return null;
        }

    }
}
