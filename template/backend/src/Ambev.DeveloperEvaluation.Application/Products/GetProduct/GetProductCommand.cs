﻿using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductCommand : IRequest<GetProductResult>
{
    public int Id { get; set; }
}
