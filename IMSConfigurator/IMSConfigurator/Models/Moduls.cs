using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace IMSConfigurator.Models
{
    [Serializable]
    class Moduls: IEnumerable<Modul>
    {
        List<Modul> m_moduls = new List<Modul>();


        private static readonly Lazy<Moduls> lazy =
        new Lazy<Moduls>(() => new Moduls());

        public static Moduls modulInstance { get { return lazy.Value; } }
        private Moduls()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Modul>));



            using (FileStream fs = new FileStream("moduls.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    m_moduls = (List<Modul>)formatter.Deserialize(fs);
                }
                catch 
                {
                    
                    MessageBox.Show("Moduls file not foud!\n Load default moduls.", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                    #region
                    m_moduls.Add(new Modul("Устройство синхронизации частоты и времени Метроном - 3000", "27000", "Шасси системы синхронизации. Система IMS с автоматическим распознаванием модулей. Горячая замена, резервирование модулей. Стоечный металлический корпус 19\" 3U.", 1106, ModulType.Chassis));
                    m_moduls.Add(new Modul("Устройство синхронизации частоты и времени Метроном - 1000", "27543", "Шасси системы синхронизации. Система IMS с автоматическим распознаванием модулей. Горячая замена, резервирование модулей. Стоечный металлический корпус 19\" 1U.", 611, ModulType.Chassis));
                    m_moduls.Add(new Modul("IMS-ACM M3000", "27550", "Модуль охлаждения", 382, ModulType.Cooler));
                    m_moduls.Add(new Modul("IMS-ACM M1000", "27551", "Модуль охлаждения", 175, ModulType.Cooler));
                    m_moduls.Add(new Modul("IMS-BPE-1040", "27033", "Карта выходных сигналов 4 x TC AM/BNC", 529, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-1062", "27045", "Карта выходных сигналов 4x DCF77 SIM/BNC", 529, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2000", "27066", "Карта выходных сигналов 1x PPS, 10MГц, TC DCLS, TC AM / BNC", 477, ModulType.Output));
                    //m_moduls.Add(new Modul ("IMS-BPE-2000"              ,"27565",   "4 BNC outputs: 4 x PPS                                    ",   463,    ModulType.Output     ));
                    //m_moduls.Add(new Modul ("IMS-BPE-2000"              ,"27566",   "4 BNC outputs: 4 x 10MHz                                  ",   463,    ModulType.Output     ));
                    //m_moduls.Add(new Modul ("IMS-BPE-2000"              ,"27564",   "4 BNC outputs: PPS, 10MHz, TC DCLS, TC AM                 ",   463,    ModulType.Output     ));
                    //m_moduls.Add(new Modul ("IMS-BPE-2000"              ,"27567",   "4 BNC outputs: 4 x 2048 kHz                               ",   463,    ModulType.Output     ));
                    m_moduls.Add(new Modul("IMS-BPE-2002", "27541", "Карта выходных сигналов - PPS, 10MHz, TC DCLS, 2.048МГц", 477, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2010", "27068", "Карта выходных сигналов 4x PPS / BNC ", 477, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-BPE-2012", "27532", "4 x PPS - 20µs BNC                                        ", 539, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2014", "27527", "Карта выходных сигналов - 2 x PPS, 2 x 10МГц/BNC", 477, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2020", "27069", "Карта выходных сигналов 4x 10МГц/BNC", 477, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2030", "27077", "Карта выходных сигналов - 4x TC DCLS/BNC", 477, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2050", "27078", "Карта выходных сигналов - 3x TC DCLS, 1x TC AM/BNC", 477, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2080", "27085", "Карта выходных сигналов 4x 2.048МГц TTL/BNC", 477, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-BPE-2090", "27086", "PP1 - PP4 - progr Pulses from pre-connected Clock         ", 477, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-BPE-2110", "27531", "Карта выходных сигналов 8х PPS/BNC", 615, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2120", "27530", "Карта выходных сигналов 8х 10МГц/BNC", 615, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2180", "27537", "Карта выходных сигналов 8х 2.048МГц/BNC                  ", 615, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-BPE-2500", "27524", "4 x prog.pulses 2pin DFK PhotoMOS + 1 x TC AM BNC         ", 544, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-2640", "27535", "Outputs - 4x PPO TTL / 2pin DFK                           ", 544, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-4043", "27522", "4x programmable pulses RJ45, RS422 Level                  ", 313, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-BPE-5000", "27084", "Карта выходных сигналов PPS, 10MHz, TC - DCLS, 2.048МГц/оптическкий выход", 732, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-5010", "27035", "Карта выходных сигналов - 4x PPS/оптическкий выход", 732, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-5020", "27030", "Карта выходных сигналов - 4 x 10МГц/оптическкий выход", 732, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-5030", "27038", "Карта выходных сигналов - 4x TC DCLS/оптическкий выход", 732, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-5080", "27031", "Карта выходных сигналов - 4x 2.048МГц/оптическкий выход", 732, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-BPE-5082", "27529", "Карта выходных сигналов - PPS, 10МГц, 2 x 2.048МГц/оптическкий выход", 732, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-BPE-5080", "27575", "Fixed Outputs - Fiber Optical ST Connectors PP1 - PP4     ", 732, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CES-1000", "27521", "Карта аварийной сигнализации (реле).", 25, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CES-1011", "27071", "PPS and 10MHz via BNC female and Error Relay Out.         ", 91, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CPE-1000", "27070", "Управляемая карта выходных интерфейсов 1PPS, 10 МГц, синт частот синус, TTL, IRIG, AFNOR, IEEE1344, C37.118, NASA36, PPOs, DCF77 MARK, 4xBNC.", 880, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CPE-1002", "27112", "2x Capture Input Signals / BNC Connector                  ", 880, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-1040", "27570", "4 x configurable BNC Outputs - TC AM                      ", 973, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-1050", "27036", "3x Programmable Outputs, 1x TC AM / BNC                   ", 880, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-2500", "27037", "4x Progr.Pulses / 2pin DFK PhotoMOS, 1x TC AM / BNC       ", 873, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CPE-3000", "27028", "Карта выходных сигналов RS232+PPS. 2x DSUB9", 885, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CPE-3010", "27075", "Configurable Serial Time String(RS422) / 2xDSUB9          ", 885, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-3020", "27526", "Config.serial Time String: RS4222 + PPS, 2x DSUB9         ", 885, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-3030", "27114", "Configurable Serial Time Strings(RS485) / 2x DSUB9        ", 885, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-3040", "27116", "2x DSUB9 - Config.Serial Time Strings - RS485 + PPS       ", 885, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-3060", "27558", "2x DSUB9 - RS232 + PPS / RS422 + PPS                      ", 885, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-CPE-5000", "27023", "4 x progr.Pulses / FO connectors                          ", 1084, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CPU", "27018", "Процессор управления. Графический веб интерфейс, ПО: LTOSv6. HTTP, NTP, SSH, SNMP. 1 x LAN порт 10/100 Мбит/с.", 901, ModulType.Processor));
                    m_moduls.Add(new Modul("IMS-ESI", "27007", "Карта внешней синхронизации от сигналов E1 (2,048 МГц / 2,048 Мбит/с, SSM/BOC).", 930, ModulType.Input));

                    m_moduls.Add(new Modul("IMS-FDM180", "27076", "Mains frequency 70 - 270 V AC, 50Hz or 60Hz               ", 875, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-CLK GNS-DHQ", "27103", "Приемник ГЛОНАСС/GPS, опорный генератор OCXO-DHQ.", 2406, ModulType.Generator));
                    m_moduls.Add(new Modul("IMS-CLK GNS-HQ", "27102", "Приемник ГЛОНАСС/GPS, опорный генератор OCXO-HQ.", 2008, ModulType.Generator));


                    //m_moduls.Add(new Modul ("IMS - CLK GLN-MQ"              ,"27014",   "incl.GNS - antenna and 20m cable Belden H155              ",   1752,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS - CLK GLN-SQ"              ,"27042",   "incl.GNS - antenna and 20m cable Belden H155              ",   1623,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS - CLK GNS-DHQ"             ,"27103",   "incl.GNS - antenna and 20m cable Belden H155              ",   2334,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS - CLK GNS-HQ"              ,"27102",   "incl.GNS - antenna and 20m cable Belden H155              ",   1948,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS - CLK GNS-MQ"              ,"27101",   "incl.GNS - antenna and 20m cable Belden H155              ",   1752,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS - CLK GNS-SQ"              ,"27100",   "incl.GNS - antenna and 20m cable Belden H155              ",   1623,   ModulType.Generator  ));
                    m_moduls.Add(new Modul("IMS-CLK GPS-DHQ", "27041", "Приемник GPS, опорный генератор OCXO-DHQ.", 1920, ModulType.Generator));
                    m_moduls.Add(new Modul("IMS-CLK GPS-HQ", "27040", "Приемник GPS, опорный генератор OCXO-HQ.", 1522, ModulType.Generator));
                    m_moduls.Add(new Modul("IMS-CLK GPS-MQ", "27002", "Приемник GPS, опорный генератор OCXO-MQ.", 1320, ModulType.Generator));
                    m_moduls.Add(new Modul("IMS-CLK GPS-SQ", "27039", "Приемник GPS, опорный генератор OCXO-SQ.", 1187, ModulType.Generator));
                    //m_moduls.Add(new Modul ("IMS-CLK GNS181-UC-DHQ"   ,"27593",   "incl.GPS antenna and 20m cable RG58                       ",   2213,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS-CLK GNS181-UC-HQ"    ,"27603",   "incl.GPS antenna and 20m cable RG58                       ",   1827,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS-CLK GNS181-UC-HQ"    ,"27603",   "incl.GPS antenna and 20m cable RG58                       ",   1827,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS-CLK GNS181-UC-MQ"    ,"27604",   "incl.GPS antenna and 20m cable RG58                       ",   1631,   ModulType.Generator  ));
                    //m_moduls.Add(new Modul ("IMS-CLK GNS181-UC-SQ"    ,"27605",   "incl.GPS antenna and 20m cable RG58                       ",   1502,   ModulType.Generator  ));
                    m_moduls.Add(new Modul("IMS-HPS100 PL-A", "27063", "Карта PTP (IEEE 1588-2008)/NTP Gigabit (Комбинированный порт RJ45 / SFP). Режим One Step mode, Layer 2 / Layer 3 / IPv4 / IPv6, SyncE. 8 клиентов PTP.", 903, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-HPS100 PL-B", "27074", "Карта PTP (IEEE 1588-2008)/NTP Gigabit (Комбинированный порт RJ45 / SFP). Режим One Step mode, Layer 2 / Layer 3 / IPv4 / IPv6, SyncE. 256 клиентов PTP.", 1222, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-HPS100 PL-C", "27073", "Карта PTP (IEEE 1588-2008)/NTP Gigabit (Комбинированный порт RJ45 / SFP). Режим One Step mode, Layer 2 / Layer 3 / IPv4 / IPv6, SyncE. 512 клиентов PTP.", 1754, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-HPS100 PL-D", "27072", "Карта PTP (IEEE 1588-2008)/NTP Gigabit (Комбинированный порт RJ45 / SFP). Режим One Step mode, Layer 2 / Layer 3 / IPv4 / IPv6, SyncE. 1024 клиентов PTP.", 2285, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-HPS100 PL-E", "27061", "Карта PTP (IEEE 1588-2008)/NTP Gigabit (Комбинированный порт RJ45 / SFP). Режим One Step mode, Layer 2 / Layer 3 / IPv4 / IPv6, SyncE. 2048 клиентов PTP.", 2816, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-LIU A0004", "27091", "Line Interface Unit, E1 / T1 generator, Clock(0 / 4)      ", 642, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A0040", "27090", "Карта интерфейсов  4 x 2,048 МГц. 120 Ом. Разъём RJ45.", 642, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A0044", "27571", "Line Interface Unit, E1 / T1gen, Clock(4 / 4)             ", 812, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A0400", "27572", "Line Interface Unit, E1 / T1 generator, BITS(0 / 4)       ", 642, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A0404", "27099", " Карта интерфейсов E1.  4x 2 048 Мбит/с, 4 x 2 048 МГц. 75 Ом, несимметричный интерфейс. Разъём BNC.", 788, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A1111", "27093", "Line Interface Unit, E1 / T1gen, BITS(1 / 1) Clock(1 / 1) ", 642, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A2002", "27089", "Line Interface Unit, E1 / T1gen, BITS(2 / 0) Clock(0 / 2) ", 642, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A2020", "27097", "Line Interface Unit, E1 / T1gen, BITS(2 / 0) Clock(2 /    ", 642, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LIU A4000", "27092", "Line Interface Unit, E1 / T1 generator, BITS(4 / 0)       ", 642, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-LNE-GbE", "27010", "Сетевая карта расширения. 4 x LAN порта 10/100/1000 Мбит/с.", 674, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LNE-GbE-SFP", "27064", "Сетевая карта расширения. 4 x LAN порта 1000 Мбит/с SFP. SFP модули не входят в комплект.", 991, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LNO", "27011", "4 x 10 МГц Синус - с низким фазовым шумом", 875, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-LNO-12dBm", "27576", "Модуль выходных сигналов 10 МГц синус с низким уровнем фазовых шумов 12dBm. 4 выхода, BNC", 912, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-MRI", "27008", "Карта внешней синхронизации от сигналов IRIG (DCLS, AM) ,PPS,10 МГц.", 391, ModulType.Input));

                    m_moduls.Add(new Modul("IMS-MRI-FO-CLK 1", "27098", "Standard Reference Inputs - TC DCLS, TC AM, PPS, 10MHz    ", 710, ModulType.Input));
                    m_moduls.Add(new Modul("IMS-MRI-FO-T-CLK 1", "27082", "TC AM / DCLS / FO - 10MHz and PPS - TTL / BNC             ", 561, ModulType.Input));
                    m_moduls.Add(new Modul("IMS-N2X180 - SQ", "27119", "Converter from NTP or IEEE - 1588 ref.to IRIG, 10MHz      ", 979, ModulType.Output));

                    m_moduls.Add(new Modul("IMS-PWR-AD10", "27005", "Блок питания шасси. Входное напряжение переменное, постоянное 100…240 В.", 234, ModulType.Power));
                    m_moduls.Add(new Modul("IMS-PWR-DC10", "27509", "Блок питания шасси. Входное напряжение постоянное 10-36 В.", 288, ModulType.Power));
                    m_moduls.Add(new Modul("IMS-PWR-DC20", "27015", "Блок питания шасси. Входное напряжение постоянное 20…72 В.", 288, ModulType.Power));
                    m_moduls.Add(new Modul("IMS-REL-1000", "27026", "Карта вывода сигналов неисправности. 3xDFK", 192, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-RSC M3000", "27019", "Модуль резервного переключения", 388, ModulType.Switcher));
                    m_moduls.Add(new Modul("IMS-RSC-MDU", "27502", "Описание!!!", 578, ModulType.Switcher));
                    m_moduls.Add(new Modul("IMS-SCG-B", "27534", "Модуль-генератор цифрового сигнала синхронизации звука DARS (симм) 1x 25pin, 4 x DARS.", 798, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-SCG-U", "27503", "Модуль-генератор сигналов Word Clock и AES11 (несимм, 2,5 В TL на 75 Ом), 4x BNC", 699, ModulType.Output));
                    m_moduls.Add(new Modul("IMS-SPT M3000", "27022", "Проходной модуль", 61, ModulType.Switcher));
                    m_moduls.Add(new Modul ("IMS-TSU-GbE"               ,"27006",   "IEEE - 1588 Time Stamp Unit SFP Option                    ",   1122,   ModulType.Output     ));
                    m_moduls.Add(new Modul("IMS-VSG", "27507", "Модуль-генератор видеосинхронизации. 1 x bi-level sync ,1x Tri-Level Sync, 1x Sync Signals (H-Sync, V-Sync, .. .), 1x DARS. 4 x BNC.", 805, ModulType.Output));



                    
                    
                     formatter.Serialize(fs, m_moduls);
                   
                    #endregion


                }

            }

        }

        internal Modul SearchModul(string text)
        {
            foreach (var item in m_moduls)
            {
                if (item.Name == text)
                    return item;
            }
            return null;
        }

        public IEnumerator<Modul> GetEnumerator()
        {
            foreach (var item in m_moduls)
            {
                yield return item;
            }
        }


        public Modul SearchModulByIDAndName(string id, string name)
        {

            foreach (var item in m_moduls)
            {
                if (item.ID.ToLower() == id.ToLower() && item.Name.ToLower() == name.ToLower())
                    return item;
            }
            return null;

        }

        public Modul SearchModul(string name, ModulType type)
        {
            
            foreach (var item in m_moduls)
            {
                if (item.Type == type && item.Name.ToLower() == name.ToLower())
                    return item;
            }
            return null;
            
        }

        public List<Modul> SearchModulsByType(ModulType type)
        {
            var query =
                from item in m_moduls
                where item.Type == type
                select item;
            return query.ToList();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<Modul> GetAllModuls()
        {
            return m_moduls;
        }

    }
}
