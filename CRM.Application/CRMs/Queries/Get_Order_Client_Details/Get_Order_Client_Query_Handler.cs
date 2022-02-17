using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Application.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Order_Client_Details
{
    public class Get_Order_Client_Query_Handler
         : IRequestHandler<Get_Order_Client_Details_Query,Order_Client_DetailsVm>
    {
        private readonly ICRM_DbContext _DbContext;
        private readonly IMapper _mapper;

        public Get_Order_Client_Query_Handler(ICRM_DbContext dbContext, IMapper mapper) =>
            (_DbContext, _mapper) = (dbContext, mapper);

        public async Task<Order_Client_DetailsVm> Handle(Get_Order_Client_Details_Query request, CancellationToken cancellationToken )
        {
            var entity = await _DbContext.Order_Clients
                .FirstOrDefaultAsync(order => order.ID_Order==request.ID_Order, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Order_Client), request.ID_Order);
            }
            return _mapper.Map<Order_Client_DetailsVm>(entity);
        }
    }
}
