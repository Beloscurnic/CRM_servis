using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.CRMs.Queries.Get_List_Order_Client;
using CRM.Application.CRMs.Queries.Get_Order_Client_Details;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CRM.Application.CRMs.Commands.Create_Order;
using CRM.WebApi.Models;
using CRM.Application.CRMs.Commands.Update_Ored_Client;
using CRM.Application.CRMs.Commands.Delet_Order_Client;
using Microsoft.AspNetCore.Http;

namespace CRM.WebApi.Controllers
{

    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class Order_ClientController:BaseController
    {
        private readonly IMapper _mapper;
        public Order_ClientController(IMapper mapper) => _mapper = mapper;

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
        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List_Order_ClientVm>> GetAll()
        {
            var query = new Get_List_Order_Client_Query
            {
                 ID_Personnel = UserId
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
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Order_Client_DetailsVm>>Get(Guid id)
        {
            var query = new Get_Order_Client_Details_Query
            {
                ID_Order = id,
              
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /order_client
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="create_Order_ClientDto">Create_Order_ClientDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] Create_Order_ClientDto create_Order_ClientDto )
        {
            var command = _mapper.Map<Create_Order_Client_Command>(create_Order_ClientDto);
            command.ID_Personnel = UserId;
            var order_Id = await Mediator.Send(command);
            return Ok(order_Id);
        }

        /// <summary>
        /// Обновление заказка
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// PUT /Order_Client
        /// {
        ///     Status_Order: "обновление статуса заказа"
        /// }
        /// </remarks>
        /// <param name="update_Order_ClientDto">обновление записи заказа </param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] Update_Order_ClientDto update_Order_ClientDto)
        {
            var command = _mapper.Map<Update_Order_Client_Command>(update_Order_ClientDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удалить зака по ID
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// DELETE /Order_Client/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id заказа (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult>Delete (Guid id)
        {
            var command = new Delete_Order_Client_Command
            {
                ID_Order = id,   
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
