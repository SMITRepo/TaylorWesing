using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorWesing.Contracts.Models
{
    public class Audit
    {
        public int Id { get; set; }
        public string URL { get; set; }

        public string Data { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
