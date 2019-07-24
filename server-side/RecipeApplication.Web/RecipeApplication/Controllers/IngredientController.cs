using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Data.Artefact.Common;
using RecipeApplication.Data.Artefact.Content;
using RecipeApplication.Data.Processes;

namespace RecipeApplication.Web.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody] IngredientNew ingredient)
        {
            try
            {
                var retVal = await ContentProcesses.CreateIngredientAsync(ingredient);
                switch (retVal.State)
                {
                    case CallReturnState.Success:
                        return Ok(retVal);
                    case CallReturnState.Warning:
                    case CallReturnState.ValidationError:
                        return BadRequest(retVal.Errors);
                    case CallReturnState.Failure:
                        return StatusCode((int)HttpStatusCode.InternalServerError, retVal.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Gets(int id)
        {

            try
            {
                var retVal = await ContentProcesses.GetIngredientsAsync(id);
                return Ok(retVal);
             
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }
}