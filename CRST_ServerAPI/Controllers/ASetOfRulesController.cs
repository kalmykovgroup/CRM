﻿using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core.Object.ABAC;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KTSF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ASetOfRulesController : ControllerBase
    {
        private ASetOfRulesService aSetOfRulesService;

        public ASetOfRulesController(ASetOfRulesService aSetOfRulesService)
        {
            this.aSetOfRulesService = aSetOfRulesService;
        }




        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] string str)
        {
            ASetOfRules setOfRules = JsonSerializer.Deserialize<ASetOfRules>(str);
            Result<ASetOfRules> result = await aSetOfRulesService.Insert(setOfRules);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] string str)
        {
            ASetOfRules setOfRules = JsonSerializer.Deserialize<ASetOfRules>(str);
            Result<ASetOfRules> result = await aSetOfRulesService.Insert(setOfRules);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            Result<List<ASetOfRules>> result = await aSetOfRulesService.GetAll();
            return Ok(result.Value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            Result<ASetOfRules> result = await aSetOfRulesService.Find(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }

    }
}
