using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.Models
{
    class Moduls: IEnumerable<Modul>
    {
        List<Modul> m_moduls = new List<Modul>();

        public Moduls()
        {
            m_moduls.Add(new Modul ("IMS - ACM M3000"               ,"27550",   "active cooling module for 3U IMS - chassis                ",   371,    ModulType.Cooler     ));
            m_moduls.Add(new Modul ("IMS - ACM M1000"               ,"27551",   "active cooling module for 1U IMS - chassis                ",   170,    ModulType.Cooler     ));
            m_moduls.Add(new Modul ("IMS - BPE - 1040"              ,"27033",   "4 x TC AM / BNC Connectors                                ",   513,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 1062"              ,"27045",   "4x DCF77 SIM / BNC Connectors - Hopf Level                ",   513,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2000"              ,"27565",   "4 BNC outputs: 4 x PPS                                    ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2000"              ,"27066",   "4 BNC outputs: PPS, 10MHz, TC DCLS, TC AM                 ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2000"              ,"27566",   "4 BNC outputs: 4 x 10MHz                                  ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2000"              ,"27564",   "4 BNC outputs: PPS, 10MHz, TC DCLS, TC AM                 ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2000"              ,"27567",   "4 BNC outputs: 4 x 2048 kHz                               ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2002"              ,"27541",   "Fixed BNC outputs - PPS, 10MHz, TC DCLS, 2048 kHz         ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2010"              ,"27068",   "4x PPS / BNC Connectors                                   ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2012"              ,"27532",   "4 x PPS - 20µs BNC                                        ",   523,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2014"              ,"27527",   "Fixed Outputs - 2 x PPS, 2 x 10MHz / BNC Connect          ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2020"              ,"27069",   "4x 10MHz / BNC Connectors                                 ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2030"              ,"27077",   "Fixed Outputs - 4x TC DCLS / BNC Connectors               ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2050"              ,"27078",   "Fixed Outputs - 3x TC DCLS, 1x TC AM / BNC                ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2080"              ,"27085",   "4x 2.048MHz TTL / BNC Connectors                          ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2090"              ,"27086",   "PP1 - PP4 - progr Pulses from pre-connected Clock         ",   463,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2110"              ,"27531",   "Fixed PPS Outputs with 4 + 4(8) / BNC                     ",   597,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2120"              ,"27530",   "Fixed 10MHz Outputs with 4 + 4(8) / BNC                   ",   597,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2180"              ,"27537",   "Fixed 2048kHz Outputs mit 4 + 4(8) / BNC                  ",   597,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2500"              ,"27524",   "4 x prog.pulses 2pin DFK PhotoMOS + 1 x TC AM BNC         ",   528,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 2640"              ,"27535",   "Outputs - 4x PPO TTL / 2pin DFK                           ",   528,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 4043"              ,"27522",   "4x programmable pulses RJ45, RS422 Level                  ",   304,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 5000"              ,"27084",   "PPS, 10MHz, TC - DCLS, 2048kHz / FO Connectors            ",   710,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 5010"              ,"27035",   "Fixed Outputs - 4x PPS / FO Connectors                    ",   710,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 5020"              ,"27030",   "Fixed Outputs - 4 x 10MHz / FO Connectors                 ",   710,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 5030"              ,"27038",   "Fixed Outputs - 4x TC DCLS / FO Connectors                ",   710,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 5080"              ,"27031",   "Fixed Outputs - 4x 2048kHz / FO Connectors                ",   710,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 5082"              ,"27529",   "Fixed Outputs - PPS, 10MHz, 2 x 2048kHz / FO              ",   710,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - BPE - 5080"              ,"27575",   "Fixed Outputs - Fiber Optical ST Connectors PP1 - PP4     ",   710,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CES - 1000"              ,"27521",   "Standard Error Relay Out                                  ",   24,     ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CES - 1011"              ,"27071",   "PPS and 10MHz via BNC female and Error Relay Out.         ",   88,     ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 1000"              ,"27070",   "4 x configurable BNC pules outputs                        ",   854,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 1002"              ,"27112",   "2x Capture Input Signals / BNC Connector                  ",   854,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 1040"              ,"27570",   "4 x configurable BNC Outputs - TC AM                      ",   944,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 1050"              ,"27036",   "3x Programmable Outputs, 1x TC AM / BNC                   ",   854,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 2500"              ,"27037",   "4x Progr.Pulses / 2pin DFK PhotoMOS, 1x TC AM / BNC       ",   847,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 3000"              ,"27028",   "Config.Serial Time String(RS232 + PPS) / 2x DSUB9         ",   858,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 3010"              ,"27075",   "Configurable Serial Time String(RS422) / 2xDSUB9          ",   858,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 3020"              ,"27526",   "Config.serial Time String: RS4222 + PPS, 2x DSUB9         ",   858,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 3030"              ,"27114",   "Configurable Serial Time Strings(RS485) / 2x DSUB9        ",   858,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 3040"              ,"27116",   "2x DSUB9 - Config.Serial Time Strings - RS485 + PPS       ",   858,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 3060"              ,"27558",   "2x DSUB9 - RS232 + PPS / RS422 + PPS                      ",   858,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPE - 5000"              ,"27023",   "4 x progr.Pulses / FO connectors                          ",   1051,   ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - CPU"                     ,"27018",   "Процессор управления. Графический веб интерфейс, ПО: LTOSv6. HTTP, NTP, SSH, SNMP. 1 x LAN порт 10/100 Мбит/с.",   874,    ModulType.Processor  ));
            m_moduls.Add(new Modul ("IMS - ESI"                     ,"27007",   "Extended Reference Inputs                                 ",   902,    ModulType.Input      ));
            m_moduls.Add(new Modul ("IMS - FDM180"                  ,"27076",   "Mains frequency 70 - 270 V AC, 50Hz or 60Hz               ",   849,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS-CLK GLN-DHQ"               ,"27044",   "incl.GNS - antenna and 20m cable Belden H155              ",   2334,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GLN-HQ"              ,"27043",   "incl.GNS - antenna and 20m cable Belden H155              ",   1948,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GLN-MQ"              ,"27014",   "incl.GNS - antenna and 20m cable Belden H155              ",   1752,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GLN-SQ"              ,"27042",   "incl.GNS - antenna and 20m cable Belden H155              ",   1623,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS-DHQ"             ,"27103",   "incl.GNS - antenna and 20m cable Belden H155              ",   2334,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS-HQ"              ,"27102",   "incl.GNS - antenna and 20m cable Belden H155              ",   1948,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS-MQ"              ,"27101",   "incl.GNS - antenna and 20m cable Belden H155              ",   1752,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS-SQ"              ,"27100",   "incl.GNS - antenna and 20m cable Belden H155              ",   1623,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GPS-DHQ "            ,"27041",   "incl.GPS antenna and 20m cable RG58                       ",   1862,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GPS-HQ"              ,"27040",   "incl.GPS antenna and 20m cable RG58                       ",   1476,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GPS-MQ"              ,"27002",   "incl.GPS antenna and 20m cable RG58                       ",   1280,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GPS-SQ"              ,"27039",   "incl.GPS antenna and 20m cable RG58                       ",   1151,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS181 - UC - DHQ"   ,"27593",   "incl.GPS antenna and 20m cable RG58                       ",   2213,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS181 - UC - HQ"    ,"27603",   "incl.GPS antenna and 20m cable RG58                       ",   1827,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS181 - UC - HQ"    ,"27603",   "incl.GPS antenna and 20m cable RG58                       ",   1827,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS181 - UC - MQ"    ,"27604",   "incl.GPS antenna and 20m cable RG58                       ",   1631,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - CLK GNS181 - UC - SQ"    ,"27605",   "incl.GPS antenna and 20m cable RG58                       ",   1502,   ModulType.Generator  ));
            m_moduls.Add(new Modul ("IMS - HPS100"                  ,"27063",   "PL - A: 8 Clients                                         ",   876,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - HPS100"                  ,"27074",   "PL - B: 256 Clients                                       ",   1185,   ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - HPS100"                  ,"27073",   "PL - C: 512 Clients                                       ",   1701,   ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - HPS100"                  ,"27061",   "PL - E: 2048 Clients                                      ",   2732,   ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A0004"               ,"27091",   "Line Interface Unit, E1 / T1 generator, Clock(0 / 4)      ",   623,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A0040"               ,"27090",   "Line Interface Unit, E1 / T1 generator, 4 x RJ45          ",   623,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A0044"               ,"27571",   "Line Interface Unit, E1 / T1gen, Clock(4 / 4)             ",   788,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A0400"               ,"27572",   "Line Interface Unit, E1 / T1 generator, BITS(0 / 4)       ",   623,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A0404"               ,"27099",   "Line Interface Unit, E1 / T1gen, BITS(0 / 4) Clock(0 / 4) ",   788,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A1111"               ,"27093",   "Line Interface Unit, E1 / T1gen, BITS(1 / 1) Clock(1 / 1) ",   623,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A2002"               ,"27089",   "Line Interface Unit, E1 / T1gen, BITS(2 / 0) Clock(0 / 2) ",   623,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A2020"               ,"27097",   "Line Interface Unit, E1 / T1gen, BITS(2 / 0) Clock(2 /    ",   623,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LIU A4000"               ,"27092",   "Line Interface Unit, E1 / T1 generator, BITS(4 / 0)       ",   623,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LNE - GbE"               ,"27010",   "Expansion card with 4 Gigabit LAN ports                   ",   654,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LNE - GbE - SFP"         ,"27064",   "Expansion card, 4 x Gigabit SFP ports                     ",   961,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LNO"                     ,"27011",   "4 x 10 MHz Sine - Low Phase Noise Option                  ",   849,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - LNO - 12dBm"             ,"27576",   "4 x 10 MHz Sine 12dBm                                     ",   885,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - MRI"                     ,"27008",   "Standard Reference Input - TC DCLS, TC AM, PPS, 10MHz     ",   379,    ModulType.Input      ));
            m_moduls.Add(new Modul ("IMS - MRI - FO - CLK 1"        ,"27098",   "Standard Reference Inputs - TC DCLS, TC AM, PPS, 10MHz    ",   689,    ModulType.Input      ));
            m_moduls.Add(new Modul ("IMS - MRI - FO - T - CLK 1"    ,"27082",   "TC AM / DCLS / FO - 10MHz and PPS - TTL / BNC             ",   544,    ModulType.Input      ));
            m_moduls.Add(new Modul ("IMS - N2X180 - SQ"             ,"27119",   "Converter from NTP or IEEE - 1588 ref.to IRIG, 10MHz      ",   950,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - PWR - AD10"              ,"27005",   "Power Supply 100 - 240 V AC / DC                          ",   227,    ModulType.Power      ));
            m_moduls.Add(new Modul ("IMS - PWR - DC10"              ,"27509",   "Power Supply 10 - 36 V DC                                 ",   279,    ModulType.Power      ));
            m_moduls.Add(new Modul ("IMS - PWR - DC20"              ,"27015",   "Power Supply 20 - 72 VDC                                  ",   279,    ModulType.Power      ));
            m_moduls.Add(new Modul ("IMS - REL - 1000"              ,"27026",   "3 x Relay Out: CLK 1, CLK 2, 10MHz                        ",   186,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - RSC M3000"               ,"27019",   "Switchover for redundant System                           ",   376,    ModulType.Switcher   ));
            m_moduls.Add(new Modul ("IMS - RSC - MDU"               ,"27502",   "                                                          ",   561,    ModulType.Switcher   ));
            m_moduls.Add(new Modul ("IMS - SCG - B"                 ,"27534",   "Studio Clock Generator DARS(balanced)                     ",   774,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - SCG - U"                 ,"27503",   "Studio Clock Generator Word Clock(unbalanced)             ",   678,    ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - SPT M3000"               ,"27022",   "Standard Signal Distribution                              ",   59,     ModulType.Switcher   ));
            m_moduls.Add(new Modul ("IMS - TSU - GbE"               ,"27006",   "IEEE - 1588 Time Stamp Unit SFP Option                    ",   1088,   ModulType.Output     ));
            m_moduls.Add(new Modul ("IMS - VSG"                     ,"27507",   "Video - Sync Generator                                    ",   781,    ModulType.Output     ));

        }

        public IEnumerator<Modul> GetEnumerator()
        {
            foreach (var item in m_moduls)
            {
                yield return item;
            }
        }

        public Modul SearchModul(string name, ModulType type)
        {
            
            foreach (var item in m_moduls)
            {
                if (item.Type == type && item.Name == name)
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
    }
}
