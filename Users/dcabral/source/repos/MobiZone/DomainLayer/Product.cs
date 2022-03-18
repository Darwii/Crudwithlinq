using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
