using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Application.CRMs.Queries.Get_List_Order_Client_Details;
using CRM.Application.CRMs.Queries.Get_List_Order_Master_Details;

namespace CRM.Application.CRMs.Queries.Get_List_Order_Master
{
    public  class Get_List_Order_Master_Query_Handler : IRequestHandler<Get_List_Order_Master_Query, List_Master_ClientVm>
    {
        private readonly ICRM_DbContext _DbContext;
        private readonly IMapper _mapper;

        public Get_List_Order_Master_Query_Handler(ICRM_DbContext dbContext, IMapper mapper) =>
            (_DbContext, _mapper) = (dbContext, mapper);

        public async Task<List_Master_ClientVm> Handle(Get_List_Order_Master_Query request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Order_Clients
                 .Where(p => p.ID_Personnel_master == request.ID_Personnel_master)
                .ProjectTo<List_Order_Master>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new List_Master_ClientVm { Orders = entity };
        }
    }
}
