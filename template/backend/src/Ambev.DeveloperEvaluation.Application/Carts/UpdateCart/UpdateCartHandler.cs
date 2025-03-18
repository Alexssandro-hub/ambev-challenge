using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    public UpdateCartHandler(
        ICartRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<UpdateCartResult> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = _mapper.Map<Cart>(request);

        if (await _repository.UpdatedAsync(cart, cancellationToken))
        {
            return _mapper.Map<UpdateCartResult>(cart);
        }

        throw new InvalidOperationException($"The cart can't be changed");
    }
}
