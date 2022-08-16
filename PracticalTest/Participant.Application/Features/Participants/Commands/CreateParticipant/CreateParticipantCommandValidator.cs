using FluentValidation;

namespace Participant.Application.Features.Participants.Commands.CreateParticipant
{
    public class CreateParticipantCommandValidator : AbstractValidator<CreateParticipantCommand>
    {
        public CreateParticipantCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull();

            RuleFor(p => p.NIK)
                .NotEmpty().WithMessage("{NIK} is required.")
                .NotNull()
                .Length(16, 16).WithMessage("{NIK} must be 16 digits");
        }
    }
}
