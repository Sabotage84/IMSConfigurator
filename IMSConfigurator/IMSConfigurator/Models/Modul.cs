using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.Models
{
    public class Modul
    {
        string name;
        string iD;
        string discription;
        double price;
        ModulType type;

        public string Name { get => name; set => name = value; }
        public string ID { get => iD; set => iD = value; }
        public string Discription { get => discription; set => discription = value; }
        public double Price { get => price; set => price = value; }
        internal ModulType Type { get => type; set => type = value; }

        public Modul(string name, string iD, string discription, double price, ModulType type)
        {
            Name = name;
            ID = iD;
            Discription = discription;
            Price = price;
            Type = type;
        }
        public Modul()
        {

        }
    }

    public enum ModulType
    {
        Power, Generator, Processor, Output, Cooler, Input, Switcher
    }
}
