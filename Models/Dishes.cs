using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dishes
    {
        [Key]
        public int DishId{get;set;}

        [Required(ErrorMessage="Name of dish is required")]
        public string Name{get;set;}

        [Required(ErrorMessage="Name of Chef is required")]
        public string Chef{get;set;}

        [Required(ErrorMessage="Please tell us how tasty it is!")]
        [Range(1,10, ErrorMessage="Keep it to a scale from 1-10")]
        public int Tastiness{get;set;}

        [Required(ErrorMessage="Please let us know how many calories the dish has")]
        public int Calories{get;set;}

        [Required(ErrorMessage="Please tell us a little about this dish")]
        public string Description{get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
    }
}