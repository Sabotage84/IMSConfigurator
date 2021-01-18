using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.ViewModel
{
    public class HistoryVM
    {
        public HistoryVM()
        {

        }
        Dictionary<string, List<Modul>> historyLogVM = new Dictionary<string, List<Modul>>();
        public HistoryVM(History history)
        {
            historyLogVM = history.HistoryLog;
        }
        public Dictionary<string, List<Modul>> HistoryLogVM { get => historyLogVM; set => historyLogVM = value; }
    }
}
