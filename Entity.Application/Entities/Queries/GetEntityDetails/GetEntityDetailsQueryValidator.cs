using FluentValidation;

namespace Entities.Application.Entities.Queries.GetEntityDetails
{
	public class GetEntityDetailsQueryValidator : AbstractValidator<GetEntityDetailsQuery>
	{
		public GetEntityDetailsQueryValidator()
		{
			RuleFor(x => x.Id).NotEqual(Guid.Empty);
		}
	}
}
