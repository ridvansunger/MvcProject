﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        public Heading()
        {
            this.Contents = new HashSet<Content>();
        }

        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }


        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


        [ForeignKey("Writer")]
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}