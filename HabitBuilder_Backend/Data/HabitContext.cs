using Microsoft.EntityFrameworkCore;
using HabitBuilder_Backend.Data;

namespace HabitBuilder_Backend.Data
{
    public class HabitContext : DbContext
    {
        public HabitContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<HabitReward> HabitRewards { get; set; }
        
        
    }
}
