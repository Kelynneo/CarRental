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
	public class BookingsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public BookingsController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Bookings
		[HttpGet]
		public async Task<IActionResult> GetBookings()
		{
			var Bookings = await _unitofWork.Bookings.GetAll();
			return Ok(Bookings);
		}

		// GET: api/Bookings/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBooking(int id)
		{
			var Booking = await _unitofWork.Bookings.Get(q => q.Id == id);

			if (Booking == null)
			{
				return NotFound();
			}

			return Ok(Booking);

		}

		// PUT: api/Bookings/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBooking(int id, Booking Booking)
		{
			if (id != Booking.Id)
			{
				return BadRequest();
			}

			_unitofWork.Bookings.Update(Booking);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await BookingExists(id))
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

		// POST: api/Bookings
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Booking>> PostBooking(Booking Booking)
		{
			await _unitofWork.Bookings.Insert(Booking);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetBooking", new { id = Booking.Id }, Booking);
		}

		// DELETE: api/Bookings/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBooking(int id)
		{
			var Booking = await _unitofWork.Bookings.Get(q => q.Id == id);
			if (Booking == null)
			{
				return NotFound();
			}

			await _unitofWork.Bookings.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> BookingExists(int id)
		{
			var Booking = await _unitofWork.Bookings.Get(q => q.Id == id);
			return Booking != null;
		}
	}
}

