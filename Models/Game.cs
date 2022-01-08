using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicatie_Web.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }
        public string Platform { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
   

        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }

        public int StudioID { get; set; }
        public Studio Studio { get; set; }

        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
