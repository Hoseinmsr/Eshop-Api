using FluentValidation;

namespace Shop.Aplication.Orders.DecreaseItemCount
{
    public class DecreaseItemCountOrderCommandValidator:AbstractValidator<DecreaseItemCountOrderCommand>
    {
        public DecreaseItemCountOrderCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیش تر از 0 باشد");
        }
    }

}
