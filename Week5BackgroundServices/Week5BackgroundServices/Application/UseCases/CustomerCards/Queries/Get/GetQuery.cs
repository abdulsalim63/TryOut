﻿using System;
using System.Collections.Generic;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.CustomerCards //.Queries.Gets
{
    public class GetCustomerCardQuery : IRequest<BaseDto<CustomerCardInput>>
    {
        public int id { get; set; }
    }
}
