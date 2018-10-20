using CWitter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWitter.ViewModels
{
    public class CweetListViewModel
    {
        public string Search { get; set; }
        public IEnumerable<Cweet> Cweets { get; set; }
    }
}
