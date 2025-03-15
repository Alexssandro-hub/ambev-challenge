using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class RatingValidator : AbstractValidator<Rating>
{
    private const float zero = 0.0000f;
    public RatingValidator()
    {
        RuleFor(rating => rating.Id)
            .NotEmpty()
            .WithMessage($"The {nameof(Rating)} {nameof(Rating.Id)} property can't be empty or 0");

        RuleFor(rating => rating.Count)
            .Equal(ushort.MinValue)
            .WithMessage($"The {nameof(Rating)} {nameof(Rating.Count)} property can't be less than 1");

        RuleFor(rating => rating.Rate)
            .Equal(zero)
            .WithMessage($"The {nameof(Rating)} {nameof(Rating.Rate)} property can't be less than 1.0000f");
    }
}
