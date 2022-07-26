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
    public class RewardsController : ControllerBase
    {
        private readonly HabitContext _context;

        public RewardsController(HabitContext context)
        {
            _context = context;
        }

        // GET: api/Rewards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reward>>> GetRewards()
        {
          if (_context.Rewards == null)
          {
              return NotFound();
          }
            return await _context.Rewards
                .FromSqlRaw("EXECUTE dbo.spRewards_GetAll")
                .ToListAsync();
        }

        // GET: api/Rewards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Reward>>> GetReward(int id)
        {
          if (_context.Rewards == null)
          {
              return NotFound();
          }
            var reward = await _context.Rewards
                .FromSqlInterpolated($"EXECUTE dbo.spRewards_GetById {id}")
                .ToListAsync();

            if (reward == null)
            {
                return NotFound();
            }

            return reward;
        }
        // GET: api/Rewards/habit/5
        [HttpGet("habit/{habitId}")]
        public async Task<ActionResult<IEnumerable<Reward>>> GetRewardByHabitId(int habitId)
        {
            if (_context.Rewards == null)
            {
                return NotFound();
            }

            var reward = await _context.Rewards
                .FromSqlInterpolated($"EXECUTE dbo.spRewards_GetByHabitId {habitId}")
                .ToListAsync();

            if (reward == null)
            {
                return NotFound();
            }

            return reward;
        }


        // POST: api/Rewards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost]
        public async Task<ActionResult<Reward>> PostReward(Reward reward)
        {
          if (_context.Rewards == null)
          {
              return Problem("Entity set 'HabitContext.Rewards'  is null.");
          }
            _context.Rewards.Add(reward);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReward", new { id = reward.Id }, reward);
        }

        // DELETE: api/Rewards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReward(int id)
        {
            if (_context.Rewards == null)
            {
                return NotFound();
            }
            var reward = await _context.Rewards.FindAsync(id);
            if (reward == null)
            {
                return NotFound();
            }

            _context.Rewards.Remove(reward);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RewardExists(int id)
        {
            return (_context.Rewards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
