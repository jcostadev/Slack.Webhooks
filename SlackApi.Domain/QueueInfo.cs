using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackApi.Domain {
    public class QueueInfo
    {
        public string Name { get; set; }
        public QueueData Data { get; set; }
    }
}