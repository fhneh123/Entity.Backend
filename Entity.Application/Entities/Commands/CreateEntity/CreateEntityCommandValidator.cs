using FluentValidation;

namespace Entities.Application.Entities.Commands.CreateEntity
{
	public class CreateEntityCommandValidator : AbstractValidator<CreateEntityCommand>
	{
		public CreateEntityCommandValidator()
		{
			RuleFor(x => x.Id).NotEqual(Guid.Empty);
			RuleFor(x => x.Amount).Must(x => x >= 0);
		}
	}
}
