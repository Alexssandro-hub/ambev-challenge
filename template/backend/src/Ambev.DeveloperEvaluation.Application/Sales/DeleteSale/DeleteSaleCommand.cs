﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

public class DeleteSaleCommand
{
    public int Id { get; set; }
    public DeleteSaleCommand(int id)
    {
        Id = id;
    }
}
