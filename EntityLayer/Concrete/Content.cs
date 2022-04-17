using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentDate { get; set; }

        [ForeignKey("Heading")]
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }


        public bool ContentStatus { get; set; }


        [ForeignKey("Writer")]
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

    }
}
