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
            public const string Recipe_Create = "content.Recipe_Create";
            public const string Recipe_Get = "content.Recipe_Get";
            public const string Recipes_Get = "Content.Recipes_Get";
            public const string Recipe_Update = "Content.Recipe_Update";
            //public const string Commentary_Delete = "Content.Commentary_Delete";
        }

        private struct Parameter
        {
            public const string Id = "@Id";
            public const string RecipeName = "@RecipeName";
            public const string Ingredients = "@Ingredients";
          
        }

        #endregion Stored proc names, parameters...

        #region Create async

        internal static async Task<int> CreateAsync(RecipeNew recipe)
        {
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
                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return id;
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
                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Value = id;
                        await connection.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader != null && await reader.ReadAsync())
                            {
                                retVal = new Recipe(reader);
                            }
                        }
                    }
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
    
         internal static async Task<List<Recipe>> GetsAsync()
        {
            Recipe retVal = null;
            List<Recipe> RecipeList = new List<Recipe>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Recipes_Get, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        await connection.OpenAsync();
                        SqlDataReader reader = cmd.ExecuteReader();
                        //using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            //                        if (reader != null && await reader.ReadAsync())
                            //                      {
                            //                        retVal = new Recipe(reader);
                            //                      RecipeList.Add(retVal);
                            //                }
                            while (reader.Read())
                            {
                                retVal = new Recipe();
                                retVal.Id = int.Parse(reader["Id"].ToString());
                                retVal.RecipeName = reader["RecipeName"].ToString();
                                retVal.Ingredients = reader["Ingredients"].ToString();
                                RecipeList.Add(retVal);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RecipeList;
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
    }
}
