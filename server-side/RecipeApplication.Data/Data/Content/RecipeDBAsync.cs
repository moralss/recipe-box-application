using RecipeApplication.Data.Artefact;
using RecipeApplication.Data.Artefact.Content;
using RecipeApplication.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace RecipeApplication.Data.Data.Content
{
    internal static partial class RecipeDBAsync
    {
        #region Stored proc names, parameters...

        private struct StoredProc
        {
            public const string Recipe_Create = "Content.Recipe_Create";
            public const string Recipe_Get = "Content.Recipe_Get";
            public const string Recipes_Get = "Content.Recipes_Get";
            public const string Recipe_Update = "Content.Recipe_Update";
            public const string Recipe_Delete = "Content.Recipe_Delete";
        }

        private struct Parameter
        {
            public const string Id = "@Id";
            public const string RecipeName = "@RecipeName";
            public const string Ingredients = "@Ingredients";
 
        }

        #endregion Stored proc names, parameters...

        #region Create async

        internal static async Task<Recipe> CreateAsync(RecipeNew recipe)
        {
            Recipe addedRecipe = null;
            int id;
            try
      
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Recipe_Create, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue(Parameter.RecipeName, recipe.RecipeName);
                        cmd.Parameters.AddWithValue(Parameter.Ingredients, recipe.Ingredients);             
                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        id = Int32.Parse(cmd.Parameters[Parameter.Id].Value.ToString());
                         addedRecipe = await GetAsync(id);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return addedRecipe;
        }

        #endregion Create async

        #region Get async

        internal static async Task<Recipe> GetAsync(int id)
        {
            Recipe retVal = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Recipe_Get, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Value = id;
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader != null && await reader.ReadAsync())
                            {
                                retVal = new Recipe(reader);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retVal;
        }

        #endregion Get async

        #region Gets async
    
         internal static  async Task<List<Recipe>> GetsAsync()
        {     
            List<Recipe> listOfRecipes = new List<Recipe>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Recipes_Get, connection))
                    {

                        {                  
                            cmd.CommandType = CommandType.StoredProcedure;

                            connection.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                Recipe recipe = new Recipe();
                                recipe.Id = Convert.ToInt32(rdr["Id"]);
                                recipe.RecipeName = rdr["recipeName"].ToString();
                                recipe.Ingredients = rdr["Ingredients"].ToString();
                                listOfRecipes.Add(recipe);
                            }
                            connection.Close();
                        }
                        return listOfRecipes;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion Gets async


        #region Update async

        internal static async Task UpdateAsync(RecipeNew recipe)
        {
            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Recipe_Update, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(Parameter.Id, recipe.Id);
                        cmd.Parameters.AddWithValue(Parameter.RecipeName, recipe.RecipeName);
                        cmd.Parameters.AddWithValue(Parameter.Ingredients, recipe.Ingredients);
                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Update async


        #region Delete async


        internal static async Task DeleteAsync(int id)
        {

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Recipe_Delete, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Value = id;
                   
                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion Delete async

 
    }
}
