using FluentValidation;

namespace MyBizAPI.DTOs.PositionDTOs
{
    public class UpdatePositionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdatePositionDTOValidator : AbstractValidator<UpdatePositionDTO>
    {
        public UpdatePositionDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bosh ola bilmez!")
                               .NotNull().WithMessage("Null ola bilmez!")
                               .MaximumLength(50).WithMessage("Uzunluq 50den chox ola bilmez!")
                               .MinimumLength(3).WithMessage("Uzunluq 3den az ola bilmez!");
        }
    }
}
