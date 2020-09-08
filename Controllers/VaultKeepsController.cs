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
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vk;
        public VaultKeepsController(VaultKeepsService vk)
        {
            _vk = vk;
        }


        [HttpPost]
        public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                newVaultKeep.UserId = user.Value;
                return Ok(_vk.Create(newVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<VaultKeepViewModel>> Get(int id)
        {
            try
            {
                var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_vk.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<VaultKeep> Delete(int id)
        {
            try
            {
                return Ok(_vk.Delete(id));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}