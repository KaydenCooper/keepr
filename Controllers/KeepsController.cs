using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _ks;
        public KeepsController(KeepsService ks)
        {
            _ks = ks;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Keep>> Get()
        {
            try
            {
                return Ok(_ks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [Authorize]
        [HttpGet("user")]
        public ActionResult<IEnumerable<Keep>> GetMyKeeps()
        {
            try
            {
                var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_ks.Get(user.Value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Keep> GetById(int id)
        {
            try
            {
                return Ok(_ks.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }




        [HttpPost]
        public ActionResult<Keep> Post([FromBody] Keep newKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                newKeep.UserId = userId.Value;
                if (userId == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_ks.Create(newKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]

        public ActionResult<Keep> Edit(int id, [FromBody] Keep updatedKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                updatedKeep.UserId = userId.Value;
                updatedKeep.Id = id;
                return Ok(_ks.Edit(updatedKeep));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_ks.Delete(userId.Value, id));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}