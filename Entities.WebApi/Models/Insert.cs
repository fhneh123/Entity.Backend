using AutoMapper;
using Entities.Application.Common.Mappings;
using Entities.Application.Entities.Commands.CreateEntity;
using Entities.Application.Entities.Queries.GetEntityDetails;
using Entities.Domain;

namespace Entities.WebApi.Models
{
	public class Insert : IMapWith<CreateEntityCommand>
	{
		public Guid Id { get; set; }
		public DateTime OperationDate { get; set; }
		public decimal Amount { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<Insert, CreateEntityCommand>();
		}
	}
}
