using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product 
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public required string Category { get; set; }
    public required string Image { get; set; }
    public required Rating Rating { get; set; }
}
