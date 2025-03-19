﻿using System.Security.Cryptography;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly CreateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _productRepository = Substitute.For<IProductRepository>();
        _handler = new CreateSaleHandler(_saleRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = RandomNumberGenerator.GetInt32(1,
                999),
            InitialDate = command.InitialDate,
            CustomerId = command.CustomerId,
            BranchSaleWasMade = command.BranchSaleWasMade,
            TotalAmount = command.TotalAmount,
            Status = command.Status,
            Products = command.Products.Select(p => new Product
                {
                    Title = p.Title,
                    Category = p.Category,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                    Id = RandomNumberGenerator.GetInt32(1,
                        999),
                    Image = string.Empty,
                    RatingId = 0,
                    Rating = new Rating
                    {
                        Id = 0,
                        Rate = 0,
                        Count = 0
                    },
                    Discount = 0,
                    Total = 0
                })
                .ToList(),
            IsCanceled = false
        };

        var result = new CreateSaleResult
        {
            Id = sale.Id,
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid sale creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the total amount is correctly calculated from the products in the sale.
    /// </summary>
    [Fact(DisplayName = "Given sale request When handling Then total amount is calculated correctly")]
    public async Task Handle_ValidRequest_CalculatesTotalAmount()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = RandomNumberGenerator.GetInt32(1,
                999),
            InitialDate = command.InitialDate,
            CustomerId = command.CustomerId,
            BranchSaleWasMade = command.BranchSaleWasMade,
            TotalAmount = command.TotalAmount,
            Status = command.Status,
            Products = command.Products.Select(p => new Product
                {
                    Title = p.Title,
                    Category = p.Category,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                    Id = RandomNumberGenerator.GetInt32(1,
                        999),
                    Image = string.Empty,
                    RatingId = 0,
                    Rating = new Rating
                    {
                        Id = 0,
                        Rate = 0,
                        Count = 0
                    },
                    Discount = 0,
                    Total = 0
                })
                .ToList(),
            IsCanceled = false
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.TotalAmount.Should().Be(sale.TotalAmount);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to sale entity")]
    public async Task Handle_ValidRequest_MapsCommandToSale()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = RandomNumberGenerator.GetInt32(1,
                999),
            InitialDate = command.InitialDate,
            CustomerId = command.CustomerId,
            BranchSaleWasMade = command.BranchSaleWasMade,
            TotalAmount = command.TotalAmount,
            Status = command.Status,
            Products = command.Products.Select(p => new Product
                {
                    Title = p.Title,
                    Category = p.Category,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                    Id = RandomNumberGenerator.GetInt32(1,
                        999),
                    Image = string.Empty,
                    RatingId = 0,
                    Rating = new Rating
                    {
                        Id = 0,
                        Rate = 0,
                        Count = 0
                    },
                    Discount = 0,
                    Total = 0
                })
                .ToList(),
            IsCanceled = false
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
            c.CustomerId == command.CustomerId &&
            c.BranchSaleWasMade == command.BranchSaleWasMade &&
            c.TotalAmount == command.TotalAmount &&
            c.Status == command.Status));
    }
}
