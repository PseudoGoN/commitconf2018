﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PythonSucks.Service.Haters;
using PythonSucks.Service.Reasons;
using PythonSucks.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PythonSucks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReasonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReasonService _reasonService;
        private readonly UserManager<IdentityUser> _userManager;
        public ReasonsController(IReasonService reasonService, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _reasonService = reasonService;
            _mapper = mapper;
            _userManager = userManager;
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
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
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
                return BadRequest(
                    new ErrorData(StatusCodes.Status400BadRequest, "There was an error in your request", 
                    new List<string> { "Ids should be the same in the route and the payload" }));
            }

            var model = _reasonService.GetReasonById(id);
            if(model == null)
            {
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
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
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
            }
            var reason = _mapper.Map<Reason>(model);

            reasonPatch.ApplyTo(reason);
            if(id != reason.Id)
            {
                return BadRequest(
                    new ErrorData(StatusCodes.Status400BadRequest, "There was an error in your request",
                    new List<string> { "Changes in id are not valid" }));
            }

            _mapper.Map(reason, model);
            _reasonService.UpdateReason(model);

            return Ok(reason);
        }

        [HttpPost("{id}/addVote")]
        public async Task<ActionResult> Post(Guid id)
        {
            var username = User.Claims.FirstOrDefault(m => m.Type == "sub");
            if (username == null)
            {
                return Unauthorized();
            }
            var user = await _userManager.FindByEmailAsync(username.Value);
            if(user == null)
            {
                return Unauthorized();
            }
            if (!_reasonService.ExistsReason(id))
            {
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
            }
            var result = _reasonService.AddVote(id, user.Id);
            if(result)
            {
                return Ok();
            }
            return Conflict(new ErrorData(StatusCodes.Status409Conflict, 
                "Conflict", new List<string> { "This user already voted this reason" }));            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (!_reasonService.ExistsReason(id))
            {
                return NotFound(new ErrorData(StatusCodes.Status404NotFound, "Not found", null));
            }
            _reasonService.DeleteReason(id);
            return NoContent();
        }
    }
}
