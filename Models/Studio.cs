using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicatie_Web.Models
{
    public class Studio
    {
        public int ID { get; set; }
        public string Studioname { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
