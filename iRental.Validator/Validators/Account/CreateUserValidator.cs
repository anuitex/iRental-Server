using FluentValidation;
using iRental.ViewModel.ViewModels;

namespace iRental.Validator.Validators.Account
{
    public class CreateUserValidator : AbstractValidator<UserCreateRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(userRequest => userRequest.Email)
                .EmailAddress()
                .NotNull()
                .NotEmpty();


            RuleFor(userRequest => userRequest.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .When(userRequest => userRequest.Password.Equals(userRequest.PasswordRepeat));


            RuleFor(userRequest => userRequest.PasswordRepeat)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .When(userRequest => userRequest.PasswordRepeat.Equals(userRequest.Password));


            RuleFor(userRequest => userRequest.FirstName)
                .NotNull();


            RuleFor(userRequest => userRequest.LastName)
                .NotNull();


            RuleFor(userRequest => userRequest.Birthday)
                .NotNull();


            RuleFor(userRequest => userRequest.Gender)
                .NotNull()
                .IsInEnum();


            RuleFor(userRequest => userRequest.Country)
                .NotNull()
                .NotEmpty();


            RuleFor(userRequest => userRequest.City)
                .NotNull()
                .NotEmpty();


            RuleFor(userRequest => userRequest.Address)
                .NotNull()
                .NotEmpty();


            RuleFor(userRequest => userRequest.PhoneNumber)
                .NotNull()
                .NotEmpty();
        }
    }
}
