using System.ComponentModel.DataAnnotations;

namespace HabitBuilder_Backend.Data
{
    public class Reward
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Cost { get; set; }

    }
}
