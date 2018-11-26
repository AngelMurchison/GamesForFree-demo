using System;
using System.ComponentModel.DataAnnotations;

namespace GamesForFree.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}