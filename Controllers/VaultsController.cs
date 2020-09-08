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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        private readonly VaultKeepsService _vk;
        public VaultsController(VaultsService vs, VaultKeepsService vk)
        {
            _vs = vs;
            _vk = vk;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                return Ok(_vs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [Authorize]
        [HttpGet("user")]
        public ActionResult<IEnumerable<Vault>> GetMyVaults()
        {
            try
            {
                var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_vs.Get(user.Value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Vault> GetById(int id)
        {
            try
            {
                var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_vs.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                string getUser = user.Value;
                if (user == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_vk.GetKeepsByVaultId(vaultId, getUser));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            };
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Vault> Post([FromBody] Vault newVault)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                newVault.UserId = userId.Value;
                if (userId == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_vs.Create(newVault));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]

        public ActionResult<Vault> Edit([FromBody] Vault updatedVault, int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                updatedVault.UserId = userId.Value;
                updatedVault.Id = id;
                return Ok(_vs.Edit(updatedVault));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Vault> Delete(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    throw new Exception("Please Login to Continue!");
                }
                return Ok(_vs.Delete(userId.Value, id));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}