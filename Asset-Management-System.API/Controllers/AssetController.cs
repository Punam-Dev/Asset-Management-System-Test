using Asset_Management_System.API.Models;
using Asset_Management_System.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendors()
        {
            try
            {
                return Ok(await _assetService.GetVendorsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetHardwares()
        {
            try
            {
                return Ok(await _assetService.GetHardwaresAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid result))
                {
                    return BadRequest("Invaid Asset");
                }

                return Ok(await _assetService.GetAssetAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(Assets asset)
        {
            try
            {
                return Ok(await _assetService.CreateAssetAsync(asset));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update(Assets asset)
        {
            try
            {

                if (!Guid.TryParse(asset.Id, out Guid result))
                {
                    return BadRequest("Invaid Asset");
                }
                return Ok(await _assetService.UpdateAssetAsync(asset));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {

                if (!Guid.TryParse(id, out Guid result))
                {
                    return BadRequest("Invaid Asset");
                }

                _assetService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAssetSummary()
        {
            try
            {
                return Ok(await _assetService.GetAssetSummariesASync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
