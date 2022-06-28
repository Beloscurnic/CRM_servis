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
using CRM.Application.CRMs.Commands.Update_Provider;
using CRM.Application.CRMs.Commands.Create_Provider;
using CRM.Application.CRMs.Commands.Delet_Accessories;
using CRM.Application.CRMs.Commands.Create_Accessories;
using CRM.Application.CRMs.Queries.Get_List_CPU;
using CRM.Application.CRMs.Queries.Get_Accessories;
using CRM.Application.CRMs.Commands.Update_Accessories;
using CRM.Application.CRMs.Queries.Get_Accessories_Type;
using CRM.Application.CRMs.Commands.Creat_Delivery;
using CRM.Application.CRMs.Queries.Get_List_Delivery;
using CRM.Application.CRMs.Queries.Get_List_All_Accessories;
using CRM.Application.CRMs.Queries.Get_List_Accessories_company;
using CRM.Application.CRMs.Commands.Create_Motherboard;
using CRM.Application.CRMs.Commands.Create_RAM;
using CRM.Application.CRMs.Queries.Get_Accessories_RAM;
using CRM.Application.CRMs.Queries.Get_Accessories_Motherboard;
using CRM.Application.CRMs.Commands.Create_Radio_components;
using CRM.Application.CRMs.Queries.Get_Accessories_Radio_components;

namespace CRM.WebApi.Controllers
{
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class AdminController : BaseController
    {
        private readonly IMapper _mapper;
        public AdminController(IMapper mapper) => _mapper = mapper;

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
        [HttpGet("provider2")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List_ProviderVm>> GetAll_Provider()
        {
            var query = new Get_Provider.Query
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Информация о компонентов от  поставщика
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/string
        /// </remarks>
        /// <param name="name_company"> Name_Company </param>
        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("provider2/list2/{name_company}")]
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_List_Accessories2.List_Accessories2Vm>> Get_Accessories_Company2(string name_company)
        {
            var query = new Get_List_Accessories2.Query
            {
                Name_Company=name_company
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Информация о компонентов от  поставщика
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/string
        /// </remarks>
        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("provider2/accessories/all")]
        [Authorize]
       
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_List_All_Accessories.List_AccessoriesVm>> Get_Accessories_All()
        {
            var query = new Get_List_All_Accessories.Query
            {
              
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Получает список CPU
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET order_client/provider
        /// </remarks>
        /// <returns>Returns List_ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("CPU/get")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_List_CPU.List_CPUVm>> GetAll_CPU()
        {
            var query = new Get_List_CPU.Query
            {
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
        [HttpGet("delivery/get")]
        [Authorize]
   
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_List_Delivery.List_DeliveryVm>> GetAll_Delivery()
        {
            var query = new Get_List_Delivery.Query
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Информация о поставщике
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/1
        /// </remarks>
        /// <param name="name_company"> Name_Company </param>
        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("provider2/get/{name_company}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_Provider2.ProviderVm>> Get_Provider(string name_company)
        {
            var query = new Get_Provider2.Query
            {
                Name_Company = name_company,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Информация о компоненте 
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/1
        /// </remarks>
        /// <param name="ID_Accessories">Номер комплектующей </param>
        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("provider/accessories/{ID_Accessories}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_Accessories.Info_AccessoriesVm>> Get_accessories(int ID_Accessories)
        {
            var query = new Get_Accessories.Query
            {
                ID_Accessories = ID_Accessories,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Информация о компоненте 
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/1
        /// </remarks>
        /// <param name="ID_Accessories">Номер комплектующей </param>
        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("provider/type/{ID_Accessories}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_Type_Accessories.Type_AccessoriesVm>> Get_Type_accessories(int ID_Accessories)
        {
            var query = new Get_Type_Accessories.Query
            {
               ID_Accessories = ID_Accessories,
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
        /// Информация о ОЗУ
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/1
        /// </remarks>
        /// <param name="id"> ID комплектующего </param>

        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("accessories/RAM/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_Accessories_RAM.Accessories_RAMVm>> Get_Accessories_RAM(int id)
        {
            var query1 = new Get_Accessories_RAM.Query
            {
                ID_Accessories = id,
            };
            var vm1 = await Mediator.Send(query1);
            return Ok(vm1);
        }

        /// <summary>
        /// Информация о Материской плате
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/1
        /// </remarks>
        /// <param name="id"> ID комплектующего </param>

        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("accessories/Motherboard/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_Motherboard.MotherboardVm>> Get_Accessories_Motherboard(int id)
        {
            var query1 = new Get_Motherboard.Query
            {
                ID_Accessories = id,
            };
            var vm1 = await Mediator.Send(query1);
            return Ok(vm1);
        }

        /// <summary>
        /// Информация о радиодетали
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// GET /order_client/1
        /// </remarks>
        /// <param name="id"> ID комплектующего </param>

        /// <returns>Returns ProviderVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("accessories/Radio_component/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Get_Accessories_Radio_components.Radio_componentsVm>> Get_Accessories_Radio_component(int id)
        {
            var query1 = new Get_Accessories_Radio_components.Query
            {
                ID_Accessories = id,
            };
            var vm1 = await Mediator.Send(query1);
            return Ok(vm1);
        }

        /// <summary>
        /// Создать потсавщика
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="create_ProviderDto">Create_ProviderDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/provider")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_Provider([FromBody] Create_ProviderDto create_ProviderDto)
        {
            var command = _mapper.Map<Create_Provider.Command>(create_ProviderDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }

        /// <summary>
        /// Создать процессор 
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin/CPU
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="create_CPUDto">create_CPUDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/CPU")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_CPU([FromBody] Create_CPUDto create_CPUDto)
        {
            var command = _mapper.Map<Create_CPU.Command>(create_CPUDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }

        /// <summary>
        /// Создать материскую плату 
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin/CPU
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="create_MotherboardDto">create_CPUDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/Motherboard")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_Motherboard([FromBody] Create_MotherboardDto create_MotherboardDto)
        {
            var command = _mapper.Map<Create_Motherboard.Command>(create_MotherboardDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }


        /// <summary>
        /// Создать ОЗУ
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin/CPU
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="create_RAMDto">create_CPUDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/RAM")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_RAM([FromBody] Create_RAMDto create_RAMDto)
        {
            var command = _mapper.Map<Create_RAM.Command>(create_RAMDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }

        /// <summary>
        /// Создать радио-компонент
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin/CPU
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="create_CPUDto">create_CPUDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/Radio_component")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_Radio_component([FromBody] Create_Radio_componentsDto create_CPUDto)
        {
            var command = _mapper.Map<Create_Radio_components.Command>(create_CPUDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }

        /// <summary>
        /// Создать потсавщика
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// POST /Admin
        /// {
        ///     Name_Client: "Name",
        ///     LastName_Client: "LastName"
        /// }
        /// </remarks>
        /// <param name="creat_DeliveryDto">Create_ProviderDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPost("create/delivery")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create_Delivery([FromBody] Creat_DeliveryDto creat_DeliveryDto)
        {
            var command = _mapper.Map<Create_Delivery.Command>(creat_DeliveryDto);
            var provider_Id = await Mediator.Send(command);
            return Ok(provider_Id);
        }

        /// <summary>
        /// Обновление поставщика
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// PUT /Order_Client
        /// {
        ///     Status_Order: "обновление заказа"
        /// }
        /// </remarks>
        /// <param name="update_ProviderDto">обновление записи поставщика</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPut("Provider/update")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update_Provider([FromBody] Update_ProviderDto update_ProviderDto)
        {
            var command = _mapper.Map<Update_Provider.Command>(update_ProviderDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Обновление поставщика
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// PUT /Order_Client
        /// {
        ///     Status_Order: "обновление заказа"
        /// }
        /// </remarks>
        /// <param name="update_DeliveryDto">обновление записи доставки</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPut("Delivery/update")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update_Delivery([FromBody] Update_DeliveryDto update_DeliveryDto)
        {
            var command = _mapper.Map<Update_Delivery.Command>(update_DeliveryDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Обновление поставщика
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        /// PUT /Order_Client
        /// {
        ///     Status_Order: "обновление заказа"
        /// }
        /// </remarks>
        /// <param name="update_AccessoriesDto">обновление записи комплектующих</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpPut("Provider/accessories/update")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update_Accessor([FromBody] Update_AccessoriesDto update_AccessoriesDto)
        {
            var command = _mapper.Map<Update_Accessories.Command>(update_AccessoriesDto);
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
        /// <param name="id">Id заказа (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpDelete("accessories/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete_Accessories(int id)
        {
            var command = new Delet_Accessories.Command
            {
                ID_Accessories = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
