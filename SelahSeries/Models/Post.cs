﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Post
    {
        public Post()
        {

            ModifiedAt = DateTime.Now;
        }
        public int PostId { get; set; }




        public int? ParentId { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        [StringLength(100)]
        public string TitleImageUrl { get; set; }
        public bool Published { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public PostClap postClap { get; set; }

    }
}