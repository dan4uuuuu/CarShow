using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShow.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Wiki { get; set; }
        public string Img { get; set; }
    }
}