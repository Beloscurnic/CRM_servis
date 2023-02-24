using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using CRM.Application.CRMs.Queries.Get_Provider;
using Microsoft.AspNetCore.Authorization;
using CRM.WebApi.Models;
using CRM.Application.CRMs.Queries.Get_List_Equipment;
using CRM.Application.CRMs.Commands.Creat_Equipment;
using CRM.Application.CRMs.Queries.Get_List_Order_Master;
using CRM.Application.CRMs.Queries.Get_Order_Client_Details;
using CRM.Application.CRMs.Queries.Get_Accessories;
using CRM.Application.CRMs.Commands.Delet_Equipment;
using CRM.Application.CRMs.Commands.Creat_services_rendered;
using CRM.Application.CRMs.Queries.Get_List_Services;
using CRM.Application.CRMs.Commands.Delet_services;
using CRM.Application.CRMs.Commands.Creat_Equipment_radio;

namespace CRM.WebApi.Controllers
{
    [ApiVersion("3.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class StorekeeperController : BaseController
    {
        private readonly IMapper _mapper;
        public StorekeeperController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получает список заказов 
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client
        /// </remarks>
        /// <returns>Returns NoteListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("order")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List_Master_ClientVm>> Get_List_Order()
        {
            var query = new Get_List_Order_Master_Query
            {
              ID_Personnel_master = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получает список поставщиков
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET order_client/provider
        /// </remarks>

        /// <param name=" id_order"> Name_Company</param>
        /// <returns>Returns List_ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet]
        [Authorize]
        [Route("Equipment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_List_Equipment.List_EquipmentVm>> Get_List_Equipment(int id_order)
        {
            var query = new Get_List_Equipment.Query
            {
                ID_Order = id_order
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Получает список поставщиков
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET order_client/provider
        /// </remarks>

      
        /// <returns>Returns List_ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet]
        [Authorize]
        [Route("Servives")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_List_services.List_ServicesVm>> Get_List_Services()
        {
            var query = new Get_List_services.Query
            {
              
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Получает заметку по идентификатору
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Order_Id (guid)</param>
        /// <returns>Returns Order_Client_DetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("order/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Order_Client_DetailsVm>> Get_Order(int id)
        {
            var query = new Get_Order_Client_Details_Query
            {
                ID_Order = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Информация о процессоре 
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/1
        /// </remarks>
        /// <param name="id"> ID комплектующего </param>

        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("accessories/CPU/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_Accessories_CPU.Accessories_CPUVm>> Get_Accessories_CPU(int id)
        {
            var query1 = new Get_Accessories_CPU.Query
            {
                ID_Accessories = id,
            };
            var vm1 = await Mediator.Send(query1);
            return Ok(vm1);
        }

        /// <summary>
        /// Создать замененые комплектующие
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="creat_EquimpentDto">Create_ProviderDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/equipment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_Equipment([FromBody] Creat_EquimpentDto creat_EquimpentDto)
        {
            var command = _mapper.Map<Create_Equipment.Command>(creat_EquimpentDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }

        /// <summary>
        /// Создать радиодетали
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="creat_Equimpent_RadioDto">Create_ProviderDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/Radio_components")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_Radio_components([FromBody] Creat_Equimpent_RadioDto creat_Equimpent_RadioDto)
        {
            var command = _mapper.Map<Creat_Equipment_radio.Command>(creat_Equimpent_RadioDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }

        /// <summary>
        /// Создать оказаную услугу
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="creat_servicesDto"> Creat_servicesDto  object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/services")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_services([FromBody] Creat_servicesDto creat_servicesDto)
        {
            var command = _mapper.Map<Creat_services.Command>(creat_servicesDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }



        /// <summary>
        /// Удалить комлектующие из поставщика по ID
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// DELETE /Admin/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="delet_EquipmentDto">обновление записи доставки</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpDelete("equipment/delet")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete_Equipment([FromBody] Delet_EquipmentDto delet_EquipmentDto)
        {
            //var command = new Delet_Equipment.Command
            //{
            //    ID_Order=id_order,
            //    ID_Accessories = id_accessories
            //};
            var command = _mapper.Map<Delet_Equipment.Command>(delet_EquipmentDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удалить комлектующие из поставщика по ID
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// DELETE /Admin/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="delet_ServicesDto">обновление записи доставки</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpDelete("services/delet")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete_Services([FromBody] Delet_ServicesDto delet_ServicesDto)
        {
            var command = _mapper.Map<Delet_Services.Command>(delet_ServicesDto);
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
