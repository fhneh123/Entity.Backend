using AutoMapper;
using Entities.Application.Entities.Commands.CreateEntity;
using Entities.Application.Entities.Queries.GetEntityDetails;
using Entities.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entities.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EntityController : BaseController
	{
		private readonly IMapper _mapper;

		public EntityController(
			IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<EntityDetailsVm>> Get(Guid get, CancellationToken cancellationToken)
		{
			var query = new GetEntityDetailsQuery
			{
				Id = get
			};

			var vm = await Mediator.Send(query, cancellationToken);
			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] Insert createEntityDto, CancellationToken cancellationToken)
		{
			var command = _mapper.Map<CreateEntityCommand>(createEntityDto);
			var entityId = await Mediator.Send(command, cancellationToken);
			return CreatedAtAction(nameof(Get), new { get = entityId }, null);
		}
	}
}
