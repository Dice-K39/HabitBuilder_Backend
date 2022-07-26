using System.ComponentModel.DataAnnotations;

namespace HabitBuilder_Backend.Data
{
    public class Habit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int DailyCompletion { get; set; }
        [Required]
        public int MonthlyCompletion { get; set; }
        [Required]
        public int YearlyCompletion { get; set; }

    }
}

