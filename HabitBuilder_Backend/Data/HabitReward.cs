
namespace HabitBuilder_Backend.Data
{
    public class HabitReward
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public Habit Habit { get; set; }
        public int RewardId { get; set; }
        public Reward Reward { get; set; }  
    }
}
