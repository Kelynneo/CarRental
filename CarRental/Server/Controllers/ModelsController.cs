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
	public class ModelsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitofWork;

		public ModelsController(IUnitOfWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		// GET: api/Models
		[HttpGet]
		public async Task<IActionResult> GetModels()
		{
			var Models = await _unitofWork.Models.GetAll();
			return Ok(Models);
		}

		// GET: api/Models/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetModel(int id)
		{
			var Model = await _unitofWork.Models.Get(q => q.Id == id);

			if (Model == null)
			{
				return NotFound();
			}

			return Ok(Model);

		}

		// PUT: api/Models/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutModel(int id, Model Model)
		{
			if (id != Model.Id)
			{
				return BadRequest();
			}

			_unitofWork.Models.Update(Model);

			try
			{
				await _unitofWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await ModelExists(id))
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

		// POST: api/Models
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Model>> PostModel(Model Model)
		{
			await _unitofWork.Models.Insert(Model);
			await _unitofWork.Save(HttpContext);

			return CreatedAtAction("GetModel", new { id = Model.Id }, Model);
		}

		// DELETE: api/Models/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteModel(int id)
		{
			var Model = await _unitofWork.Models.Get(q => q.Id == id);
			if (Model == null)
			{
				return NotFound();
			}

			await _unitofWork.Models.Delete(id);
			await _unitofWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> ModelExists(int id)
		{
			var Model = await _unitofWork.Models.Get(q => q.Id == id);
			return Model != null;
		}
	}
}
