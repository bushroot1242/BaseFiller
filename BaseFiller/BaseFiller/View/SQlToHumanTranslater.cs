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
            
            //имена таблиц
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


            //тут начинаются поля таблиц, всех
            dictionary.Add("Account", "Аккаунт");
            dictionary.Add("ComputerName", "Имя компьютера");
            dictionary.Add("ConfigurationId", "ИД Конфигурации");
            dictionary.Add("CPUId", "ИД ЦПУ");
            dictionary.Add("Date", "Дата");
            dictionary.Add("DepartamentId", "ИД Департамента");
            dictionary.Add("FathersName", "Отчество");
            dictionary.Add("FinishData", "Дата окончания");
            dictionary.Add("GPUId", "ИД ГПУ");
            dictionary.Add("HddId", "ИД ЖД");
            dictionary.Add("Id", "ИД");
            dictionary.Add("IdOs", "ИД ОС");
            dictionary.Add("IDPC", "ИД ПК");
            dictionary.Add("IDUser", "ИД Пользователя");
            dictionary.Add("InventaryNumber", "Инвентаризационный номер");
            dictionary.Add("IsMan", "Пол");
            dictionary.Add("Manufacturer", "Производитель");
            dictionary.Add("ManufacturerId", "ИД  Производителя");
            dictionary.Add("Model", "Модель");
            dictionary.Add("ModelId", "ИД Модели");
            dictionary.Add("MonitorId", "ИД Монитора");
            dictionary.Add("MotherboardId", "ИД Мат. Платы");
            dictionary.Add("Name", "Имя");
            dictionary.Add("NewConfig", "Новая конфигурация");
            dictionary.Add("OldConfigId", "Старая конфигурация");
            dictionary.Add("PersonalNumber", "Табельный номер");
            dictionary.Add("PostId", "ИД Должности");
            dictionary.Add("RamId", "ИД ОЗУ");
            dictionary.Add("ReplaceDate", "Дата переустановки");
            dictionary.Add("ResponsiblePersonId", "ИД ответственного лица");
            dictionary.Add("Room", "Кабинет");
            dictionary.Add("SerialNumber", "Серийный номер");
            dictionary.Add("SocketNumber", "Сокет");
            dictionary.Add("StartData", "Дата начала");
            dictionary.Add("Status", "Статус");
            dictionary.Add("StatusRepearID", "ИД статуса ремонта");
            dictionary.Add("Surname", "Фамилия");
            dictionary.Add("Type", "Тип");
            dictionary.Add("TypeId", "ИД Типа");
            dictionary.Add("TypeRepearID", "ИД Типа ремонта");
            dictionary.Add("UnitId", "ИД Подразделения");
            dictionary.Add("Volume", "Объем");



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
