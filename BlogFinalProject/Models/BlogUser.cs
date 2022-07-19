using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogFinalProject.Models
{
    public class BlogUser 
    {
        [Key]
        public int blogid { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }


        public DateTime? TimeStamp { get; set; }
    }
}
