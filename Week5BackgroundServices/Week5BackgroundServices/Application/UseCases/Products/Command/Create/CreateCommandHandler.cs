﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;

namespace Week5BackgroundServices.Application.UseCases.Products //.Command.Create
{
    public class CreateProductCommandHandler : IRequestHandler<BaseRequest<ProductInput>, BaseDto<ProductInput>>
    {
        private readonly ProjectContext _context;

        public CreateProductCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<ProductInput>> Handle(BaseRequest<ProductInput> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var product = new Domain.Entities.Product
            {
                name = input.name,
                price = input.price
            };

            _context.products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<ProductInput>
            {
                Message = "Success add product data",
                Status = true,
                Data = input
            };
        }
    }
}
