using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Application.Entities.Commands.CreateEntity
{
	public class CreateEntityCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public DateTime OperationDate { get; set; }
		public decimal Amount { get; set; }
	}
}
