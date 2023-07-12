using FluentValidation;

namespace SimpleCrudDotNetSix.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Campo Obrigatório");

            RuleFor(p => p.DateOfBirth)
                .LessThan(DateTime.Now)
                .WithMessage("Data inválida.");

            When(p => !p.IsEmancipated, () =>
            {
                var dateNow = DateTime.Now;
                var dateMoreThanEighteen = new DateTime(dateNow.Year - 18, dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute, dateNow.Second);

                RuleFor(p => p.DateOfBirth)
                    .LessThanOrEqualTo(dateMoreThanEighteen)
                    .WithMessage("Menor de 18 anos");

            });

            RuleFor(p => p.Affiliation)
                .Must(a => a.Count >= 1 && a.Count <= 2)
                .WithMessage("O campo filiação deve contar 01 ou 02 pais.");

            RuleForEach(p => p.Affiliation)
                .NotEmpty()
                .WithMessage("Campo invalido, caso possua apenas uma filiação informar 'Não Consta.'");



        }
    }
}
