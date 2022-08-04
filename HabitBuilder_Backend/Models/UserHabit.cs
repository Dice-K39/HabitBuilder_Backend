using HabitBuilder_Backend.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitBuilder_Backend.Models
{
    public class UserHabit
    {

        public int Id { get; set; } 


        public string UserId { get;set;}=null!;

        public int? HabitId { get; set; }

        
         public ICollection <AppUser> AppUser { get; set; }//This is the USERID


    }
}
