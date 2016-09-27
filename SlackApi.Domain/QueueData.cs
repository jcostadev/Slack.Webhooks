using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackApi.Domain {

    public class QueueData
    {
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public bool Auto_Delete { get; set; }
        public string Idle_Since { get; set; }
        public int Messages { get; set; }
        public int Messages_Ready { get; set; }
        public int Messages_Unacknowledged { get; set; }
        public int Consumers { get; set; }
        private string State { set; get; }
    }
}