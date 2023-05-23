using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Application.Entities.Queries.GetEntityDetails
{
	public class GetEntityDetailsQuery : IRequest<EntityDetailsVm>
	{
		public Guid Id { get; set; }
	}
}
