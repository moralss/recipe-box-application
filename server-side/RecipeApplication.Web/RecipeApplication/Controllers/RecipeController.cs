using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Data.Processes;
using RecipeApplication.Data.Artefact;
using RecipeApplication.Data.Artefact.Common;
using System.Net;
using RecipeApplication.Data.Artefact.Content;

namespace RecipeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RecipeController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> AddRecipes([FromBody] RecipeNew recipe)
        {
            try
            {
                var retVal = await ContentProcesses.CreateRecipeAsync(recipe);
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


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RecipeNew recipe)
        {
            try
            {
                var retVal = await ContentProcesses.UpdateRecipeAsync(recipe);
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
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var retVal = await ContentProcesses.GetRecipeAsync(id);
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // my code for retriving all recipes is not working 

           List<Recipe> recipeList = await ContentProcesses.GetRecipesAsync();
            return Ok(recipeList);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}
