using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int? StockId { get; set; }
        public Models.Stock? Stock { get; set; } //Navigation Property

        [Required]
        [MinLength(5,ErrorMessage ="min 5 character required")]
        [MaxLength(280,ErrorMessage ="Only 280 character allowed")]
        public string Description { get; set; }=string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}