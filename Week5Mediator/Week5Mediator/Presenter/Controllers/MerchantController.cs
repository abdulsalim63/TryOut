﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchant;
using Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchants;
using Week5Mediator.Application.UseCases.Merchants.Command.CreateMerchant;

namespace Week5Mediator.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());

        public MerchantController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<GetMerchantsDto>> Get()
        {
            return Ok(await Mediator.Send(new GetMerchantsQuery() { }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMerchantDto>> Get(int id)
        {

            return Ok(await Mediator.Send(new GetMerchantQuery() { id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateMerchantCommandDto>> Post([FromBody] CreateMerchantCommand payload)
        {

            return Ok(await Mediator.Send(payload));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
