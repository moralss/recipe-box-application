using RecipeApplication.Data.Artefact.Content;
using RecipeApplication.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Data.Data.Content
{
    internal static partial class IngredientDBAsync
    {

        #region Stored proc names, parameters...

        private struct StoredProc
        {
            public const string Ingredient_Create = "Content.Ingredient_Create";
            public const string Ingredient_Gets = "Content.Ingredient_Gets";
            public const string Ingredient_Get = "Content.Ingredient_Get";
        }

        private struct Parameter
        {
            public const string Id = "@Id";
            public const string Ingredient = "@Ingredient";
            public const string RecipeId = "@RecipeId";


        }

        #endregion Stored proc names, parameters...

        #region Create async

        internal static async Task<Ingredient> CreateAsync(IngredientNew ingredient)
        {
            Ingredient addedIngredient = null;
            int id;
            try

            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Ingredient_Create, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue(Parameter.Ingredient, ingredient.Ingredient);
                        cmd.Parameters.AddWithValue(Parameter.RecipeId, ingredient.RecipeId);
                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        id = Int32.Parse(cmd.Parameters[Parameter.Id].Value.ToString());
                       addedIngredient = await GetAsync(id);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return addedIngredient;
        }

        #endregion Create async

        #region Get async

        internal static async Task<Ingredient> GetAsync(int id)
        {
            Ingredient retVal = null;

            try

            {
                using (SqlConnection connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Ingredient_Get, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Value = id;
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader != null && await reader.ReadAsync())
                            {
                                retVal = new Ingredient(reader);
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

        internal static async Task<List<Ingredient>> GetsAsync(int recipeId)
        {
            List<Ingredient> listOfIngredients = new List<Ingredient>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Ingredient_Gets, connection))
                    {

                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            connection.Open();
                            cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Value = recipeId;
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                Ingredient ingredient = new Ingredient();
                                ingredient.Id = Convert.ToInt32(rdr["Id"]);
                                ingredient.IngredientName = rdr["Ingredient"].ToString();
                                ingredient.RecipeId = Convert.ToInt32(rdr["RecipeId"]);
                                listOfIngredients.Add(ingredient);
                            }
                            connection.Close();
                        }
                        return listOfIngredients;
                    }
                }
            }
            catch (Exception)
            {
                throw;
           }

        }
        #endregion Gets async     
    }
}
