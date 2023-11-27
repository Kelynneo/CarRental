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
	public class CustomersController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public CustomersController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Customers
		[HttpGet]
		public async Task<IActionResult> GetCustomers()
		{
			var Customers = await _unitofWork.Customers.GetAll();
			return Ok(Customers);
		}

		// GET: api/Customers/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCustomer(int id)
		{
			var Customer = await _unitofWork.Customers.Get(q => q.Id == id);

			if (Customer == null)
			{
				return NotFound();
			}

			return Ok(Customer);

		}

		// PUT: api/Customers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCustomer(int id, Customer Customer)
		{
			if (id != Customer.Id)
			{
				return BadRequest();
			}

			_unitofWork.Customers.Update(Customer);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await CustomerExists(id))
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

		// POST: api/Customers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
		{
			await _unitofWork.Customers.Insert(Customer);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetCustomer", new { id = Customer.Id }, Customer);
		}

		// DELETE: api/Customers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			var Customer = await _unitofWork.Customers.Get(q => q.Id == id);
			if (Customer == null)
			{
				return NotFound();
			}

			await _unitofWork.Customers.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> CustomerExists(int id)
		{
			var Customer = await _unitofWork.Customers.Get(q => q.Id == id);
			return Customer != null;
		}
	}
}
