using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootcamp.Models
{
    public class BotSession
    {
        public string Name { get; set; }
        public string StartDateTime { get; set; }
        public string FinishDateTime { get; set; }
        public string SessionType { get; set; }
        public string Description { get; set; }
        public DateTime DateTime_Start { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public string Track { get; set; }
        public List<BotPresenter> Presenters { get; set; }
    }
}
