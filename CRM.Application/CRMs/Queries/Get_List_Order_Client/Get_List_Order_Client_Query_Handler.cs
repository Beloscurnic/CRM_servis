using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Application.CRMs.Queries.Get_List_Order_Client_Details;

namespace CRM.Application.CRMs.Queries.Get_List_Order_Client
{
    public  class Get_List_Order_Client_Query_Handler : IRequestHandler<Get_List_Order_Client_Query, List_Order_ClientVm>
    {
        private readonly ICRM_DbContext _DbContext;
        private readonly IMapper _mapper;

        public Get_List_Order_Client_Query_Handler(ICRM_DbContext dbContext, IMapper mapper) =>
            (_DbContext, _mapper) = (dbContext, mapper);

        public async Task<List_Order_ClientVm> Handle(Get_List_Order_Client_Query request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Order_Clients
                  .Where(note => note.ID_Client != null)
                .ProjectTo<List_Order_Client>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new List_Order_ClientVm { Orders = entity };
        }
    }
}
