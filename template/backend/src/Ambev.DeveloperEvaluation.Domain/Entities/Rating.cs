﻿using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Rating 
{
    public required int Id { get; set; }
    public required float Rate { get; set; }
    public required int Count { get; set; }
}
