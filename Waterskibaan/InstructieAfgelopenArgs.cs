using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieAfgelopenArgs : EventArgs
    {
        public List<Sporter> NewUninstructedSpelers { get; set; }
        public List<Sporter> InstructedSporters { get; set; }
    }
}
