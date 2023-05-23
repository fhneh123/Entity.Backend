using AutoMapper;
using Entities.Application.Common.Mappings;
using Entities.Domain;

namespace Entities.Application.Entities.Queries.GetEntityDetails
{
	public class EntityDetailsVm : IMapWith<Entity>
	{
		public Guid Id { get; set; }
		public DateTime OperationDate { get; set; }
		public decimal Amount { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<Entity, EntityDetailsVm>();
		}
	}
}
