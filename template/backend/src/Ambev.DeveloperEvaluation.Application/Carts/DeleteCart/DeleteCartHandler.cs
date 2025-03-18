using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    public DeleteCartHandler(
        ICartRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _repository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

        return new DeleteCartResult { Success = true };
    }
}
