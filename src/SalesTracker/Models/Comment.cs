using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public string Title { get; set; }
        public string Body { get; set; }
        public int CommentId { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
