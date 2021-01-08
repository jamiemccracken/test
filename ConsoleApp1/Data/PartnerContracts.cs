using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/*
Distribution Partner Contracts

Partner|Usage
ITunes|digital download
YouTube|streaming

*/

namespace Contracts
{
    public class PartnerContract
    {
        public string Partner { get; set; }
        public string Usage { get; set; }
    }
    
}
