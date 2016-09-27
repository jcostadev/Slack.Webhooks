using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackApi.Domain {
    public class Response
    {
        public string CreateDate { get; set; }

        public List<Layer> Layers { get; set; }
    }
}