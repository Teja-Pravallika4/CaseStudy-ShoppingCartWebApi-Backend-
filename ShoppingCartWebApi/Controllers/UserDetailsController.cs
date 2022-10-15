using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using MailKit.Net.Smtp;


namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly ShoppingCartDbContext _context;

        public UserDetailsController(ShoppingCartDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        [HttpGet("GetAllUserDetails")]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }

        // GET: api/UserDetails/5
        [HttpGet("GetUserDetailsById")]
        public async Task<ActionResult<UserDetails>> GetUserDetails(int id)
        {
            var userDetails = await _context.UserDetails.FindAsync(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return userDetails;
        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("UpdateUserDetails")]
        public async Task<IActionResult> PutUserDetails(int id, UserDetails userDetails)
        {
            if (id != userDetails.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<UserDetails>> PostUserDetails(UserDetails userDetails)
        {
            //byte[] passwordHash;
            //CreatePasswordHash(userDetails.Password, out passwordHash);

            //userDetails.Password = Encoding.Default.GetString(passwordHash);
            //Console.WriteLine(userDetails.Password);
            _context.UserDetails.Add(userDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDetails", new { id = userDetails.UserId }, userDetails);
        }

        private bool UserDetailsExists(int id)
        {
            return _context.UserDetails.Any(e => e.UserId == id);
        }
        #region EmailService
        [HttpGet("EmailService")]

        public IActionResult SendEmail(string name, string reciever)
        {
            string body = "Thanks " + name + "!\n\n Your email id " + reciever + " is succesfully registered with" +
                " Online Shopping \n\n Regards,\n Online Shopping Ltd.\n Contact us: onlineshopping20010@outlook.com";
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse("onlineshopping20010@outlook.com"));
            email.To.Add(MailboxAddress.Parse(reciever));
            email.Subject = "Registration comfirmation mail.";
            email.Body = new TextPart(TextFormat.Plain) { Text = body };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp-mail.outlook.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            smtp.Authenticate("onlineshopping20010@outlook.com", "Online20010");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok("200");
        }
        #endregion

        //private void CreatePasswordHash(string password, out byte[] passwordHash)
        //{
        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {

        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        }
    }

