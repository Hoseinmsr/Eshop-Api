using FluentValidation;

namespace Shop.Aplication.Orders.IncreaseItemCount
{
    public class IncreaseItemCountOrderCommandValidator:AbstractValidator<IncreaseItemCountOrderCommand>
    {
        public IncreaseItemCountOrderCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیش تر از 0 باشد");
        }
    }
}
