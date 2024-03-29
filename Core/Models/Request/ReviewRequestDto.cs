﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Request
{
    public class ReviewRequestDto
    {
        public float Rating { get; set; }
        public string Comment { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid PlaceId { get; set; }
        public Guid UserId { get; set; }
    }
}
