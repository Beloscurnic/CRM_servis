using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain;
using MediatR;
using CRM.Application.Interfaces;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Create_Motherboard
{
    public partial class Create_Motherboard
    {
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {
               
                var provider = _dbContext.Accessoriess
                         .Where(p => p.ID_Accessories == request.ID_Accessories)
                         .Select(c => c.ID_Accessories)
                         .FirstOrDefault();
                var id_provider = _dbContext.Providers
                       .Where(p => p.Name_Company == request.Name_Company)
                       .Select(c => c.ID_Provider)
                       .FirstOrDefault();
                if (provider != null)
                {
                    Guid iD_Сomponent;
                    iD_Сomponent = Guid.NewGuid();
          
                        var central_process = new Motherboard
                        {
                            ID_Сomponent = iD_Сomponent,
                            Name_Сomponent=request.Name_Сomponent,
                            Price=request.Price,
                            Motherboard_socket=request.Motherboard_socket,
                            Motherboard_chipset=request.Motherboard_chipset,
                            RAM=request.RAM,
                            Disk_controllers=request.Disk_controllers,
                            Expansion_slots=request.Expansion_slots,
                            Net=request.Net,
                            audio_and_video=request.audio_and_video,
                            Form_factor=request.Form_factor
                        };
                    
                    var providerinfo = new Accessories
                    {
                        ID_Сomponent = iD_Сomponent,
                        Type_Сomponent= "Motherboard",
                        Name_Сomponent=request.Name_Сomponent,
                        Сharacteristics_info="Активный",
                        Price_Сomponent=request.Price,
                        Name_Company=request.Name_Company,
                        ID_Provider=id_provider
                    };
                    await _dbContext.Motherboards.AddAsync(central_process, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    await _dbContext.Accessoriess.AddAsync(providerinfo, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return providerinfo.ID_Accessories;
                }
                else return 0;
            }
        }
    }
}
