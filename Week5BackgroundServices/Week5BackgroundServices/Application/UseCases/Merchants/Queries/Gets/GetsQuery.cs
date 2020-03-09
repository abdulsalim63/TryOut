﻿using System;
using System.Collections.Generic;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Merchants //.Queries.Gets
{
    public class GetMerchantsQuery : IRequest<BaseDto<IList<MerchantInput>>>
    {
    }
}
