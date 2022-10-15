using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class feedbackController : ControllerBase
    {
        private readonly ShoppingCartDbContext _context;

        public feedbackController(ShoppingCartDbContext context)
        {
            _context = context;
        }

        // GET: api/feedback
        [HttpGet("GetAllFeedback")]
        public async Task<ActionResult<IEnumerable<feedback>>> Getfeedback()
        {
            return await _context.feedback.ToListAsync();
        }

        // GET: api/feedback/5
        [HttpGet("GetFeedbackByUserId")]
        public async Task<ActionResult<feedback>> Getfeedback(int id)
        {
            var feedback = await _context.feedback.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // PUT: api/feedback/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        

          
        // POST: api/feedback
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddFeedback")]
        public async Task<ActionResult<feedback>> Postfeedback(feedback feedback)
        {
            _context.feedback.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfeedback", new { name = feedback.Username }, feedback);
        }

      
       

        private bool feedbackExists(string name)
        {
            return _context.feedback.Any(e => e.Username == name);
        }
    }
}
