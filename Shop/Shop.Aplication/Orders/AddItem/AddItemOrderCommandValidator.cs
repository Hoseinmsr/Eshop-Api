using FluentValidation;

namespace Shop.Aplication.Orders.AddItem
{
    public class AddItemOrderCommandValidator:AbstractValidator<AddItemOrderCommand>
    {
        public AddItemOrderCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1)
                .WithMessage("تعداد باید بیش تر از 0 باشد");
    
        }
    }
}
