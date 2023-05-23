using Entities.Application.Interfaces;
using Entities.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entities.Application.Entities.Commands.CreateEntity
{
	public class CreateEntityCommandHandler : IRequestHandler<CreateEntityCommand, Guid>
	{
		private readonly IEntitiesDbContext _dbContext;

		public CreateEntityCommandHandler(
			IEntitiesDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Guid> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
		{
			if (await _dbContext.Entities.AnyAsync(x => x.Id == request.Id, cancellationToken))
			{
				return request.Id;
			}

			var entity = new Entity
			{
				Id = request.Id,
				OperationDate = request.OperationDate,
				Amount = request.Amount
			};

			await _dbContext.Entities.AddAsync(entity, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}
	}
}
