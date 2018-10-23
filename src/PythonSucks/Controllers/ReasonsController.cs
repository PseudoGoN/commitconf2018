using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PythonSucks.Service.Haters;
using PythonSucks.Service.Reasons;
using PythonSucks.ViewModels;

namespace PythonSucks.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ReasonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReasonService _reasonService;
        public ReasonsController(IReasonService reasonService, IMapper mapper)
        {
            _reasonService = reasonService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reason>> Get()
        {
            var reasons = _reasonService.GetReasons();
            var result = _mapper.Map<IEnumerable<Model.Reason>, IEnumerable<Reason>>(reasons);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Reason> Get(Guid id)
        {
            var reason = _reasonService.GetReasonById(id);
            if(reason == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Reason>(reason);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Hater> Post([FromBody] Reason reason)
        {
            var model = _mapper.Map<Model.Reason>(reason);
            var createdReason = _reasonService.CreateReason(model);
            var result = _mapper.Map<Reason>(createdReason);
            return Created(Url.Action("Get", new { id = result.Id }), result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Reason reason)
        {
            if(id != reason.Id)
            {
                return BadRequest("Ids should be the same in the route and the payload");
            }

            var model = _reasonService.GetReasonById(id);
            if(model == null)
            {
                return NotFound();
            }
            _mapper.Map(reason, model);
            _reasonService.UpdateReason(model);
            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult Patch(Guid id, [FromBody]JsonPatchDocument<Reason> reasonPatch)
        {
            var model = _reasonService.GetReasonById(id);
            if (model == null)
            {
                return NotFound();
            }
            var reason = _mapper.Map<Reason>(model);

            reasonPatch.ApplyTo(reason);
            if(id != reason.Id)
            {
                return BadRequest("Changes in id are not valid");
            }

            _mapper.Map(reason, model);
            _reasonService.UpdateReason(model);

            return Ok(reason);
        }

        [HttpPost("{id}/addVote")]
        public ActionResult Post(Guid id)
        {
            //TODO: que venga del usuario logado
            var haterId = new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6");
            if (!_reasonService.ExistsReason(id))
            {
                return NotFound();
            }
            var result = _reasonService.AddVote(id, haterId);
            if(result)
            {
                return Ok();
            }
            return Conflict("This user already voted this reason");            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (!_reasonService.ExistsReason(id))
            {
                return NotFound();
            }
            _reasonService.DeleteReason(id);
            return NoContent();
        }
    }
}
