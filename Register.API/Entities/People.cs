﻿using System.ComponentModel.DataAnnotations;

namespace Register.API.Entities
{
    public class People
    {
        public People() { }
        public People(int id) { Id = id; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo Nome é Obrigatório!")]
        
        public required string Name { get; set; }
        
        public DateOnly BirthDate { get; set; }
        
        public Phones? Phone { get; set; }
        
        public bool IsActive { get; set; }
    }
}