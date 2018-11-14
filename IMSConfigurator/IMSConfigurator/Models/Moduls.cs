using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.Models
{
    class Moduls
    {
        List<Modul> m_moduls = new List<Modul>();

        public Moduls()
        {

            m_moduls.Add("IMS - ACM M3000", "27550", "active cooling module for 3U IMS - chassis                ", 371, 00, ModulType.Processor);
            m_moduls.Add("IMS - ACM M1000"               ,"27551",   "active cooling module for 1U IMS - chassis                ",170, 00    , ModulType.Processor
            m_moduls.Add("IMS - BPE - 1040"              ,"27033",   "4 x TC AM / BNC Connectors                                ",513, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 1062"              ,"27045",   "4x DCF77 SIM / BNC Connectors - Hopf Level                ",513, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2000"              ,"27565",   "4 BNC outputs: 4 x PPS                                    ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2000"              ,"27066",   "4 BNC outputs: PPS, 10MHz, TC DCLS, TC AM                 ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2000"              ,"27566",   "4 BNC outputs: 4 x 10MHz                                  ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2000"              ,"27564",   "4 BNC outputs: PPS, 10MHz, TC DCLS, TC AM                 ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2000"              ,"27567",   "4 BNC outputs: 4 x 2048 kHz                               ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2002"              ,"27541",   "Fixed BNC outputs - PPS, 10MHz, TC DCLS, 2048 kHz         ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2010"              ,"27068",   "4x PPS / BNC Connectors                                   ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2012"              ,"27532",   "4 x PPS - 20µs BNC                                        ",523, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2014"              ,"27527",   "Fixed Outputs - 2 x PPS, 2 x 10MHz / BNC Connect          ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2020"              ,"27069",   "4x 10MHz / BNC Connectors                                 ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2030"              ,"27077",   "Fixed Outputs - 4x TC DCLS / BNC Connectors               ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2050"              ,"27078",   "Fixed Outputs - 3x TC DCLS, 1x TC AM / BNC                ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2080"              ,"27085",   "4x 2.048MHz TTL / BNC Connectors                          ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2090"              ,"27086",   "PP1 - PP4 - progr Pulses from pre-connected Clock         ",463, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2110"              ,"27531",   "Fixed PPS Outputs with 4 + 4(8) / BNC                     ",597, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2120"              ,"27530",   "Fixed 10MHz Outputs with 4 + 4(8) / BNC                   ",597, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2180"              ,"27537",   "Fixed 2048kHz Outputs mit 4 + 4(8) / BNC                  ",597, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2500"              ,"27524",   "4 x prog.pulses 2pin DFK PhotoMOS + 1 x TC AM BNC         ",528, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 2640"              ,"27535",   "Outputs - 4x PPO TTL / 2pin DFK                           ",528, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 4043"              ,"27522",   "4x programmable pulses RJ45, RS422 Level                  ",304, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 5000"              ,"27084",   "PPS, 10MHz, TC - DCLS, 2048kHz / FO Connectors            ",710, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 5010"              ,"27035",   "Fixed Outputs - 4x PPS / FO Connectors                    ",710, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 5020"              ,"27030",   "Fixed Outputs - 4 x 10MHz / FO Connectors                 ",710, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 5030"              ,"27038",   "Fixed Outputs - 4x TC DCLS / FO Connectors                ",710, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 5080"              ,"27031",   "Fixed Outputs - 4x 2048kHz / FO Connectors                ",710, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 5082"              ,"27529",   "Fixed Outputs - PPS, 10MHz, 2 x 2048kHz / FO              ",710, 00    , ModulType.Output
            m_moduls.Add("IMS - BPE - 5080"              ,"27575",   "Fixed Outputs - Fiber Optical ST Connectors PP1 - PP4     ",710, 00    , ModulType.Output
            m_moduls.Add("IMS - CES - 1000"              ,"27521",   "Standard Error Relay Out                                  ",24, 00     , ModulType.Output
            m_moduls.Add("IMS - CES - 1011"              ,"27071",   "PPS and 10MHz via BNC female and Error Relay Out.         ",88, 00     , ModulType.Output
            m_moduls.Add("IMS - CPE - 1000"              ,"27070",   "4 x configurable BNC pules outputs                        ",854, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 1002"              ,"27112",   "2x Capture Input Signals / BNC Connector                  ",854, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 1040"              ,"27570",   "4 x configurable BNC Outputs - TC AM                      ",944, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 1050"              ,"27036",   "3x Programmable Outputs, 1x TC AM / BNC                   ",854, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 2500"              ,"27037",   "4x Progr.Pulses / 2pin DFK PhotoMOS, 1x TC AM / BNC       ",847, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 3000"              ,"27028",   "Config.Serial Time String(RS232 + PPS) / 2x DSUB9         ",858, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 3010"              ,"27075",   "Configurable Serial Time String(RS422) / 2xDSUB9          ",858, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 3020"              ,"27526",   "Config.serial Time String: RS4222 + PPS, 2x DSUB9         ",858, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 3030"              ,"27114",   "Configurable Serial Time Strings(RS485) / 2x DSUB9        ",858, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 3040"              ,"27116",   "2x DSUB9 - Config.Serial Time Strings - RS485 + PPS       ",858, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 3060"              ,"27558",   "2x DSUB9 - RS232 + PPS / RS422 + PPS                      ",858, 00    , ModulType.Output
            m_moduls.Add("IMS - CPE - 5000"              ,"27023",   "4 x progr.Pulses / FO connectors                          ",1051, 00   , ModulType.Output
            m_moduls.Add("IMS - CPU"                     ,"27018",   "LANTIME Processor Unit                                    ",874, 00    , ModulType.Processor
            m_moduls.Add("IMS - ESI"                     ,"27007",   "Extended Reference Inputs                                 ",902, 00    ,
            m_moduls.Add("IMS - FDM180"                  ,"27076",   "Mains frequency 70 - 270 V AC, 50Hz or 60Hz               ",849, 00    ,
            m_moduls.Add("IMS-CLK GLN-DHQ"               ,"27044",   "incl.GNS - antenna and 20m cable Belden H155              ",2334, 00  ,
            m_moduls.Add("IMS - CLK GLN-HQ"              ,"27043",   "incl.GNS - antenna and 20m cable Belden H155              ",1948, 00  ,
            m_moduls.Add("IMS - CLK GLN-MQ"              ,"27014",   "incl.GNS - antenna and 20m cable Belden H155              ",1752, 00  ,
            m_moduls.Add("IMS - CLK GLN-SQ"              ,"27042",   "incl.GNS - antenna and 20m cable Belden H155              ",1623, 00  ,
            m_moduls.Add("IMS - CLK GNS-DHQ"             ,"27103",   "incl.GNS - antenna and 20m cable Belden H155              ",2334, 00  ,
            m_moduls.Add("IMS - CLK GNS-HQ"              ,"27102",   "incl.GNS - antenna and 20m cable Belden H155              ",1948, 00  ,
            m_moduls.Add("IMS - CLK GNS-MQ"              ,"27101",   "incl.GNS - antenna and 20m cable Belden H155              ",1752, 00  ,
            m_moduls.Add("IMS - CLK GNS-SQ"              ,"27100",   "incl.GNS - antenna and 20m cable Belden H155              ",1623, 00  ,
            m_moduls.Add("IMS - CLK GPS-DHQ "            ,"27041",   "incl.GPS antenna and 20m cable RG58                       ",1862, 00  ,
            m_moduls.Add("IMS - CLK GPS-HQ"              ,"27040",   "incl.GPS antenna and 20m cable RG58                       ",1476, 00  ,
            m_moduls.Add("IMS - CLK GPS-MQ"              ,"27002",   "incl.GPS antenna and 20m cable RG58                       ",1280, 00  ,
            m_moduls.Add("IMS - CLK GPS-SQ"              ,"27039",   "incl.GPS antenna and 20m cable RG58                       ",1151, 00  ,
            m_moduls.Add("IMS - CLK GNS181 - UC - DHQ"   ,"27593",   "incl.GPS antenna and 20m cable RG58                       ",2213, 00  ,
            m_moduls.Add("IMS - CLK GNS181 - UC - HQ"    ,"27603",   "incl.GPS antenna and 20m cable RG58                       ",1827, 00  ,
            m_moduls.Add("IMS - CLK GNS181 - UC - HQ"    ,"27603",   "incl.GPS antenna and 20m cable RG58                       ",1827, 00  ,
            m_moduls.Add("IMS - CLK GNS181 - UC - MQ"    ,"27604",   "incl.GPS antenna and 20m cable RG58                       ",1631, 00  ,
            m_moduls.Add("IMS - CLK GNS181 - UC - SQ"    ,"27605",   "incl.GPS antenna and 20m cable RG58                       ",1502, 00  ,
            m_moduls.Add("IMS - HPS100"                  ,"27063",   "PL - A: 8 Clients                                         ",876, 00    ,
            m_moduls.Add("IMS - HPS100"                  ,"27074",   "PL - B: 256 Clients                                       ",1185, 00   ,
            m_moduls.Add("IMS - HPS100"                  ,"27073",   "PL - C: 512 Clients                                       ",1701, 00   ,
            m_moduls.Add("IMS - HPS100"                  ,"27072",   "PL - D: 1024 Clients                                      ",2216, 00   ,
            m_moduls.Add("IMS - HPS100"                  ,"27061",   "PL - E: 2048 Clients                                      ",2732, 00   ,
            m_moduls.Add("IMS - LIU A0004"               ,"27091",   "Line Interface Unit, E1 / T1 generator, Clock(0 / 4)      ",623, 00    ,
            m_moduls.Add("IMS - LIU A0040"               ,"27090",   "Line Interface Unit, E1 / T1 generator, 4 x RJ45          ",623, 00    ,
            m_moduls.Add("IMS - LIU A0044"               ,"27571",   "Line Interface Unit, E1 / T1gen, Clock(4 / 4)             ",788, 00    ,
            m_moduls.Add("IMS - LIU A0400"               ,"27572",   "Line Interface Unit, E1 / T1 generator, BITS(0 / 4)       ",623, 00    ,
            m_moduls.Add("IMS - LIU A0404"               ,"27099",   "Line Interface Unit, E1 / T1gen, BITS(0 / 4) Clock(0 / 4) ",788, 00    ,
            m_moduls.Add("IMS - LIU A1111"               ,"27093",   "Line Interface Unit, E1 / T1gen, BITS(1 / 1) Clock(1 / 1) ",623, 00    ,
            m_moduls.Add("IMS - LIU A2002"               ,"27089",   "Line Interface Unit, E1 / T1gen, BITS(2 / 0) Clock(0 / 2) ",623, 00    ,
            m_moduls.Add("IMS - LIU A2020"               ,"27097",   "Line Interface Unit, E1 / T1gen, BITS(2 / 0) Clock(2 /    ",623, 00    ,
            m_moduls.Add("IMS - LIU A4000"               ,"27092",   "Line Interface Unit, E1 / T1 generator, BITS(4 / 0)       ",623, 00    ,
            m_moduls.Add("IMS - LNE - GbE"               ,"27010",   "Expansion card with 4 Gigabit LAN ports                   ",654, 00    ,
            m_moduls.Add("IMS - LNE - GbE - SFP"         ,"27064",   "Expansion card, 4 x Gigabit SFP ports                     ",961, 00    ,
            m_moduls.Add("IMS - LNO"                     ,"27011",   "4 x 10 MHz Sine - Low Phase Noise Option                  ",849, 00    ,
            m_moduls.Add("IMS - LNO - 12dBm"             ,"27576",   "4 x 10 MHz Sine 12dBm                                     ",885, 00    ,
            m_moduls.Add("IMS - MRI"                     ,"27008",   "Standard Reference Input - TC DCLS, TC AM, PPS, 10MHz     ",379, 00    ,
            m_moduls.Add("IMS - MRI - FO - CLK 1"        ,"27098",   "Standard Reference Inputs - TC DCLS, TC AM, PPS, 10MHz    ",689, 00    ,
            m_moduls.Add("IMS - MRI - FO - T - CLK 1"    ,"27082",   "TC AM / DCLS / FO - 10MHz and PPS - TTL / BNC             ",544, 00    ,
            m_moduls.Add("IMS - N2X180 - SQ"             ,"27119",   "Converter from NTP or IEEE - 1588 ref.to IRIG, 10MHz      ",950, 00    ,
            m_moduls.Add("IMS - PWR - AD10"              ,"27005",   "Power Supply 100 - 240 V AC / DC                          ",227, 00    ,
            m_moduls.Add("IMS - PWR - DC10"              ,"27509",   "Power Supply 10 - 36 V DC                                 ",279, 00    ,
            m_moduls.Add("IMS - PWR - DC20"              ,"27015",   "Power Supply 20 - 72 VDC                                  ",279, 00    ,
            m_moduls.Add("IMS - CLK PZF - DHQ"           ,"27115",   "incl.DCF antenna AW02 and 20m  cable RG58                 ",1482, 00   ,
            m_moduls.Add("IMS - CLK PZF - HQ"            ,"27056",   "incl.DCF antenna AW02 and 20m  cable RG58                 ",1096, 00   ,
            m_moduls.Add("IMS - CLK PZF - MQ"            ,"27055",   "incl.DCF antenna AW02 and 20m  cable RG58                 ",900, 00    ,
            m_moduls.Add("IMS - CLK PZF - SQ"            ,"27003",   "incl.DCF antenna AW02 and 20m  cable RG58                 ",771, 00    ,
            m_moduls.Add("IMS - REL - 1000"              ,"27026",   "3 x Relay Out: CLK 1, CLK 2, 10MHz                        ",186, 00    ,
            m_moduls.Add("IMS - RSC M3000"               ,"27019",   "Switchover for redundant System                           ",376, 00    ,
            m_moduls.Add("IMS - RSC - MDU"               ,"27502",   "                                                          ",561, 00    ,
            m_moduls.Add("IMS - SCG - B"                 ,"27534",   "Studio Clock Generator DARS(balanced)                     ",774, 00    ,
            m_moduls.Add("IMS - SCG - U"                 ,"27503",   "Studio Clock Generator Word Clock(unbalanced)             ",678, 00    ,
            m_moduls.Add("IMS - SDI - 2101"              ,"27568",   "MDU - 2 x Time Code Input AM / DCLS via BNC + USB         ",464, 00    ,
            m_moduls.Add("IMS - SDI - 4112"              ,"27533",   "MDU - Input with Error In, 2x TimeCode, PPS / 10MHz       ",361, 00    ,
            m_moduls.Add("IMS - SDI - 4505(MDU)"         ,"27540",   "MDU - 4X F - ST / Error In, TC AM DCLS In, PPS In, 10MHz  ",689, 00    ,
            m_moduls.Add("IMS - SDI - 5302"              ,"27525",   "MDU - Input with Error In, 2x TC AM DCLS PPS 10MHz        ",391, 00    ,
            m_moduls.Add("IMS - SPT M3000"               ,"27022",   "Standard Signal Distribution                              ",59, 00     ,
            m_moduls.Add("IMS - TCR - DHQ"               ,"27538",   "TCR Receiver / Generator DHQ Timebase                     ",1457, 00   ,
            m_moduls.Add("IMS - TCR - SQ"                ,"27096",   "TCR Receiver / Generator SQ Timebase                      ",732, 00    ,
            m_moduls.Add("IMS - TSU - GbE"               ,"27006",   "IEEE - 1588 Time Stamp Unit SFP Option                    ",1088, 00   ,
            m_moduls.Add("IMS - VSG"                     ,"27507",   "Video - Sync Generator                                    ",781, 00    ,
           
            






        }
    }
}
