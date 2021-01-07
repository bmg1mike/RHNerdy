using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PlatformController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlatformController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllPlatform")]
        public async Task<IActionResult> GetAllPlatforms()
        {
            var platforms = await _unitOfWork.Platform.ListAllAsync();
            return Ok(new NerdyResponse { Result = platforms });
        }


    }
}
