using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
Music Contracts

Artist|Title|Usages|StartDate|EndDate
Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|

*/

namespace Contracts
{
    public class MusicContracts
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string[] Usages { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
