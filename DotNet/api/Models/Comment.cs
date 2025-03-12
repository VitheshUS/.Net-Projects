using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        // public int? UserId { get; set; }
        // User? User { get; set; } //Navigation Property
        public int? StockId { get; set; }
        //public Stock? Stock { get; set; } //Navigation Property
        public string Description { get; set; }=string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}