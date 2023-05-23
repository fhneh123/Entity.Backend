using AutoMapper;
using Entities.Application.Common.Exceptions;
using Entities.Application.Interfaces;
using Entities.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Entities.Application.Entities.Queries.GetEntityDetails
{
	public class GetEntityDetailsQueryHandler : IRequestHandler<GetEntityDetailsQuery, EntityDetailsVm>
	{
		private readonly IEntitiesDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetEntityDetailsQueryHandler(IEntitiesDbContext dbContext,
			IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<EntityDetailsVm> Handle(GetEntityDetailsQuery request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Entities.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

			if (entity == null)
			{
				throw new NotFoundException(nameof(Entity), request.Id);
			}

			return _mapper.Map<EntityDetailsVm>(entity);
		}
	}
}
