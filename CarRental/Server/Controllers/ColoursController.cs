using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Server.Data;
using CarRental.Shared.Domain;
using CarRental.Server.IRepository;
using CarRental.Server.Repository;

namespace CarRental.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColoursController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public ColoursController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Colours
		[HttpGet]
		public async Task<IActionResult> GetColours()
		{
			var Colours = await _unitofWork.Colours.GetAll();
			return Ok(Colours);
		}

		// GET: api/Colours/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetColour(int id)
		{
			var Colour = await _unitofWork.Colours.Get(q => q.Id == id);

			if (Colour == null)
			{
				return NotFound();
			}

			return Ok(Colour);

		}

		// PUT: api/Colours/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutColour(int id, Colour Colour)
		{
			if (id != Colour.Id)
			{
				return BadRequest();
			}

			_unitofWork.Colours.Update(Colour);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await ColourExists(id))
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

		// POST: api/Colours
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Colour>> PostColour(Colour Colour)
		{
			await _unitofWork.Colours.Insert(Colour);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetColour", new { id = Colour.Id }, Colour);
		}

		// DELETE: api/Colours/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteColour(int id)
		{
			var Colour = await _unitofWork.Colours.Get(q => q.Id == id);
			if (Colour == null)
			{
				return NotFound();
			}

			await _unitofWork.Colours.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> ColourExists(int id)
		{
			var Colour = await _unitofWork.Colours.Get(q => q.Id == id);
			return Colour != null;
		}
	}
}
