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
    public class CartController : ControllerBase
    {
        //private readonly ShoppingCartDbContext _context;

        //public CartController(ShoppingCartDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Cart
        //[HttpGet("GetAllCart")]
        //public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        //{
        //    return await _context.Cart.ToListAsync();
        //}

        //// GET: api/Cart/5
        //[HttpGet("GetCartByCartId")]
        //public async Task<ActionResult<Cart>> GetCart(int id)
        //{
        //    var cart = await _context.Cart.FindAsync(id);

        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return cart;
        //}

        ////[HttpGet("GetCartByUserId")]
        ////public async Task<ActionResult<UserDetails>> GetCartByUserId(int id)
        ////{
        ////    var user = await _context.UserDetails.FindAsync(id);

        ////    if (user == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    return user;
        ////}

        //// PUT: api/Cart/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("UpdateCart")]
        //public async Task<IActionResult> PutCart(int id, Cart cart)
        //{
        //    if (id != cart.CartId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cart).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CartExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Cart
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost("AddToCart")]
        //public async Task<ActionResult<Cart>> PostCart(Cart cart)
        //{
        //    _context.Cart.Add(cart);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        //}

        //// DELETE: api/Cart/5
        //[HttpDelete("DeleteCart")]
        //public async Task<ActionResult<Cart>> DeleteCart(int id)
        //{
        //    var cart = await _context.Cart.FindAsync(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cart.Remove(cart);
        //    await _context.SaveChangesAsync();

        //    return cart;
        //}

        //private bool CartExists(int id)
        //{
        //    return _context.Cart.Any(e => e.CartId == id);

        
            private readonly ShoppingCartDbContext _context;

            public CartController(ShoppingCartDbContext context)
            {
                _context = context;
            }

            // GET: api/Cart
            [HttpGet("GetAllCart")]
            public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
            {
                return await _context.Cart.ToListAsync();
            }

            // GET: api/Cart/5
            [HttpGet("GetCartByCartId")]
            public async Task<ActionResult<Cart>> GetCart(int id)
            {
                var cart = await _context.Cart.FindAsync(id);

                if (cart == null)
                {
                    return NotFound();
                }

                return cart;
            }

            //[HttpGet("GetCartByUserId")]
            //public async Task<ActionResult<UserDetails>> GetCartByUserId(int id)
            //{
            //    var user = await _context.UserDetails.FindAsync(id);

            //    if (user == null)
            //    {
            //        return NotFound();
            //    }

            //    return user;
            //}

            // PUT: api/Cart/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("UpdateCart")]
            public async Task<IActionResult> PutCart(int id, Cart cart)
            {
                if (id != cart.CartId)
                {
                    return BadRequest();
                }

                _context.Entry(cart).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(id))
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

            // POST: api/Cart
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost("AddToCart")]
            public async Task<ActionResult<Cart>> PostCart(Cart cart)
            {
                _context.Cart.Add(cart);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
            }

            // DELETE: api/Cart/5
            [HttpDelete("DeleteCart")]
            public async Task<ActionResult<Cart>> DeleteCart(int id)
            {
                var cart = await _context.Cart.FindAsync(id);
                if (cart == null)
                {
                    return NotFound();
                }

                _context.Cart.Remove(cart);
                await _context.SaveChangesAsync();

                return cart;
            }

            private bool CartExists(int id)
            {
                return _context.Cart.Any(e => e.CartId == id);
            }
    }
}
