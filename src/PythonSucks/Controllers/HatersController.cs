using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PythonSucks.Service.Haters;
using PythonSucks.ViewModels;

namespace PythonSucks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HatersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHaterService _haterService;
        public HatersController(IHaterService haterService, IMapper mapper)
        {
            _haterService = haterService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hater>> Get()
        {
            var haters = _haterService.GetHaters();
            var result = _mapper.Map<IEnumerable<Model.Hater>, IEnumerable<Hater>>(haters);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Hater> Get(Guid id)
        {
            var hater = _haterService.GetHaterById(id);
            if(hater==null)
            {
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
            }
            var result = _mapper.Map<Hater>(hater);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Hater> Post([FromBody] Hater hater)
        {
            var model = _mapper.Map<Model.Hater>(hater);
            var createdHater = _haterService.CreateHater(model);
            var result = _mapper.Map<Hater>(createdHater);
            return Created(Url.Action("Get", new { id = result.Id }), result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Hater hater)
        {
            if(id != hater.Id)
            {
                return BadRequest(
                    new ErrorData(StatusCodes.Status400BadRequest, "There was an error in your request",
                    new List<string> { "Ids should be the same in the route and the payload" }));
            }
            
            var model = _haterService.GetHaterById(id);
            if (model == null)
            {
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
            }
            _mapper.Map(hater, model);
            _haterService.UpdateHater(model);
            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult Patch(Guid id, [FromBody]JsonPatchDocument<Hater> haterPatch)
        {
            var model = _haterService.GetHaterById(id);
            if (model == null)
            {
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
            }
            var hater = _mapper.Map<Hater>(model);

            haterPatch.ApplyTo(hater);
            if (id != hater.Id)
            {
                return BadRequest(
                    new ErrorData(StatusCodes.Status400BadRequest, "There was an error in your request",
                    new List<string> { "Changes in id are not valid" }));
            }
            _mapper.Map(hater, model);
            _haterService.UpdateHater(model); 
            
            return Ok(hater);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (!_haterService.ExistsHater(id))
            {
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
            }
            _haterService.DeleteHater(id);
            return NoContent();
        }
    }
}
