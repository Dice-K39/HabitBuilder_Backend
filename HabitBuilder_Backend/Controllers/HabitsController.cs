using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HabitBuilder_Backend.Data;

namespace HabitBuilder_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly HabitContext _context;

        public HabitsController(HabitContext context)
        {
            _context = context;
        }

        
        // GET: api/Habits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habit>>> GetHabits()
        {
          if (_context.Habits == null)
          {
              return NotFound();
          }
            return await _context.Habits
                .FromSqlRaw("EXECUTE dbo.spHabits_GetAll")
                .ToListAsync();
            
        }

        // GET: api/Habits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Habit>>> GetHabit(int id)
        {
          if (_context.Habits == null)
          {
              return NotFound();
          }
            
            var habit = await _context.Habits
                .FromSqlInterpolated($"EXECUTE dbo.spHabits_GetById {id}")
                .ToListAsync();

            if (habit == null)
            {
                return NotFound();
            }

            return habit;
        }
        // GET: api/Habits/reward/5
        [HttpGet("reward/{rewardid}")]
        public async Task<ActionResult<IEnumerable<Habit>>> GetHabitByRewardId(int rewardid)
        {
            if (_context.Habits == null)
            {
                return NotFound();
            }

            var habit = await _context.Habits
                .FromSqlInterpolated($"EXECUTE dbo.spHabits_GetByRewardId {rewardid}")
                .ToListAsync();

            if (habit == null)
            {
                return NotFound();
            }

            return habit;
        }

        
        // POST: api/Habits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Habit>> PostHabit(Habit habit)
        {
          if (_context.Habits == null)
          {
              return Problem("Entity set 'HabitContext.Habits'  is null.");
          }
            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabit", new { id = habit.Id }, habit);
        }

        // DELETE: api/Habits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(int id)
        {
            if (_context.Habits == null)
            {
                return NotFound();
            }
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }

            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitExists(int id)
        {
            return (_context.Habits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
