using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.Models //TODO: veery stupid namespace
{
    public class ConnectTokenModel
    {
        public string Client_id { get; set; }
        public string Client_secret { get; set; }
        public string Scope { get; set; }
        public string Grant_type { get; set; }
    }
}
