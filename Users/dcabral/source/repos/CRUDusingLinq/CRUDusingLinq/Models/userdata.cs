using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;
namespace CRUDusingLinq.Models
{
    

    public partial class userdata
    {
        public int id { get; set; }

       [Required]
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
    }
}
