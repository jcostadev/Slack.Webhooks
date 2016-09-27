using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackApi.Domain {
    public class Layer
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<QueueInfo> Queues { get; set; }
    }
}