using RecipeApplication.Data.Artefact;
using RecipeApplication.Data.Artefact.Common;
using RecipeApplication.Data.Artefact.Content;
using RecipeApplication.Data.Data.Content;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeApplication.Data.Processes
{
    public static
        class ContentProcesses
    {

        #region Recipe

        #region Create
        public static async Task<CallReturn<Recipe>> CreateRecipeAsync(RecipeNew recipe)
        {
            var retVal = new CallReturn<Recipe>();
            try
            {
                retVal.Object = await RecipeDBAsync.CreateAsync(new RecipeNew
                {
                    RecipeName = recipe.RecipeName
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
                    RecipeName = recipe.RecipeName
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

        #region Delete

        public static async Task<CallReturn<int>> DeleteRecipeAsync(int id)
        {
            var retVal = new CallReturn<int>();

            try
            {
            await RecipeDBAsync.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                retVal.SetError(ErrorType.SystemError, ex);
            }

            return retVal;
        }


        #endregion

       #endregion
        
        #region Ingredient

        #region Create
        public static async Task<CallReturn<Ingredient>> CreateIngredientAsync(IngredientNew ingredient)
        {
            var retVal = new CallReturn<Ingredient>();
            try
            {
                retVal.Object = await IngredientDBAsync.CreateAsync(new IngredientNew
                {
                    Ingredient = ingredient.Ingredient,
                    RecipeId = ingredient.RecipeId
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


        #region Gets

        public static async Task<List<Ingredient>> GetIngredientsAsync(int recipeId)
        {

            List<Ingredient> ingredientList = new List<Ingredient>();

            try
            {
                ingredientList = await IngredientDBAsync.GetsAsync(recipeId);
            }
            catch (Exception)
            {
                throw;
            }

            return ingredientList;
        }

        #endregion

        #endregion



    }
}





