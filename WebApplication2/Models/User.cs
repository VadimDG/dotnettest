﻿namespace WebApplication2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public List<Order> Orders { get; set; }
    }
}
