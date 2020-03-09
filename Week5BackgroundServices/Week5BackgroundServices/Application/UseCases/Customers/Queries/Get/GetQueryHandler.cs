﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Week5BackgroundServices.Application.UseCases.Customers //.Queries.Gets
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, BaseDto<CustomerInput>>
    {
        private readonly ProjectContext _context;

        public GetCustomerHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerInput>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.customers.FindAsync(request.id);
            if (result == null)
            {
                return new BaseDto<CustomerInput>
                {
                    Message = "Failed retrieve customer data",
                    Status = false,
                    Data = null
                };
            }
            else
            {
                return new BaseDto<CustomerInput>
                {
                    Message = "Success retrieve customer data",
                    Status = true,
                    Data = new CustomerInput
                    {
                        full_name = result.full_name,
                        username = result.username,
                        password = result.password,
                        email = result.email,
                        birthdate = result.birthdate,
                        gender = result.gender,
                        phone_number = result.phone_number
                    }
                };
            }
        }
    }
}
