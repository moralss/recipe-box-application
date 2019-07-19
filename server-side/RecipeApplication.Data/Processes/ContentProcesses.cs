using RecipeApplication.Data.Artefact;
using RecipeApplication.Data.Artefact.Common;
using RecipeApplication.Data.Artefact.Content;
using RecipeApplication.Data.Data.Content;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeApplication.Data.Processes
{
    public static class ContentProcesses
    {
        #region Create
        public static async Task<CallReturn<int>> CreateRecipeAsync(RecipeNew recipe)
        {
            var retVal = new CallReturn<int>();
            try
            {
                retVal.Object = await RecipeDBAsync.CreateAsync(new RecipeNew
                {
                    RecipeName = recipe.RecipeName,
                    Ingredients = recipe.Ingredients
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                retVal.SetError(ErrorType.SystemError, ex);
            }

            return retVal;

        }
        #endregion


        #region Get

        public static async Task<CallReturn<Recipe>> GetRecipeAsync(int id)
        {
            var retVal = new CallReturn<Recipe>();

            try
            {
                retVal.Object = await RecipeDBAsync.GetAsync(id);
            }
            catch (Exception ex)
            {
                retVal.SetError(ErrorType.SystemError, ex);
            }

            return retVal;
        }

        #endregion

        #region Gets

        public static async Task<List<Recipe>> GetRecipesAsync()
        {

            List<Recipe> recipesList = new List<Recipe>();

            try
            {
                recipesList = await RecipeDBAsync.GetsAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return recipesList;
        }

        #endregion


        #region Update

        public static async Task<CallReturn<int>> UpdateRecipeAsync(RecipeNew recipe)
        {
            var retVal = new CallReturn<int>();

            try
            {
                await RecipeDBAsync.UpdateAsync(new RecipeNew
                {
                    Id = recipe.Id,
                    RecipeName = recipe.RecipeName,
                    Ingredients = recipe.Ingredients
                });
            }
            catch (Exception ex)
            {
              retVal.SetError(ErrorType.SystemError, ex);
                throw;
            }

            return retVal;
        }

        #endregion
    }
}





