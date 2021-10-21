using DesafioIti.Core.Services.Interface;
using FluentValidation;

namespace DesafioIti.Api.Validations
{
    public class HashValidator : AbstractValidator<string>
    {
        private readonly IHashService _hashService;


        public HashValidator(IHashService hashService)
        {
            _hashService = hashService;

            RuleFor(x => x)
                .MustAsync(async (hashValue, _ ) => { return  await _hashService.ValidateHash(hashValue); });
        }
    }
}
