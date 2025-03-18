using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    public CreateCartHandler(
        ICartRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateCartResult> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = _mapper.Map<Cart>(request);

        var createdCart = await _repository.CreateAsync(cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);
        return result;
    }
}
