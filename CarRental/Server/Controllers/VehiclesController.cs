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
	public class VehiclesController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public VehiclesController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Vehicles
		[HttpGet]
		public async Task<IActionResult> GetVehicles()
		{
			var Vehicles = await _unitofWork.Vehicles.GetAll();
			return Ok(Vehicles);
		}

		// GET: api/Vehicles/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetVehicle(int id)
		{
			var Vehicle = await _unitofWork.Vehicles.Get(q => q.Id == id);

			if (Vehicle == null)
			{
				return NotFound();
			}

			return Ok(Vehicle);

		}

		// PUT: api/Vehicles/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutVehicle(int id, Vehicle Vehicle)
		{
			if (id != Vehicle.Id)
			{
				return BadRequest();
			}

			_unitofWork.Vehicles.Update(Vehicle);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await VehicleExists(id))
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

		// POST: api/Vehicles
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle Vehicle)
		{
			await _unitofWork.Vehicles.Insert(Vehicle);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetVehicle", new { id = Vehicle.Id }, Vehicle);
		}

		// DELETE: api/Vehicles/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteVehicle(int id)
		{
			var Vehicle = await _unitofWork.Vehicles.Get(q => q.Id == id);
			if (Vehicle == null)
			{
				return NotFound();
			}

			await _unitofWork.Vehicles.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> VehicleExists(int id)
		{
			var Vehicle = await _unitofWork.Vehicles.Get(q => q.Id == id);
			return Vehicle != null;
		}
	}
}
