using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    public GetCartHandler(
        ICartRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<GetCartResult> Handle(GetCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetCartCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (cart == null)
            throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

        return _mapper.Map<GetCartResult>(cart);
    }
}
