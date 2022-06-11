using CarRental.Core.Entity.Concrete;
using System;
using System.Collections.Generic;

namespace CarRental.Entity.Concrete
{
    public class Blog : CoreEntity
    {
        public string Image { get; set; }
        public string Category { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }

        public List<Comment> Comments { get; set; }
    }
}