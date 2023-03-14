using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sale_With_Maui.API.Data;
using Sale_With_Maui.API.Helpers;
using Sale_With_Maui.Shared.DTOs;
using Sale_With_Maui.Shared.Entities;

namespace Sale_With_Maui.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDto pagination)
        {
            var queryable = _context.Countries
                .Include(x => x.States).AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }


            return Ok(await queryable
                .OrderBy(n => n.Name)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDto pagination)
        {
            var queryable = _context.Countries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetFullAsync()
        {
            return Ok(await _context.Countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            
            try
            {
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.InnerException.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries
                .Include(s => s.States!)
                .ThenInclude(c => c.Cities).FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            
            try
            {
                _context.Update(country);
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un pais con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DelelteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
