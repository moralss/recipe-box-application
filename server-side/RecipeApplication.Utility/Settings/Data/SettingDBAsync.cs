using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using RecipeApplication.Utility.Settings.Artefacts;
//using RecipeApplication.Utility.Setting.Artefacts;

namespace RecipeApplication.Utility.Settings.Data
{
    internal static partial class SettingDBAsync
    {
        #region Stored proc names, parameters...

        private struct StoredProc
        {
            public const string Setting_Create = "System.Setting_Create";
            //public const string Setting_Get = "System.Setting_Get";
            public const string Setting_Search = "System.Setting_Search";
           // public const string Setting_Update = "System.Setting_Update";
          //  public const string Setting_Delete = "System.Setting_Delete";

        }

        private struct Parameter
        {
            public const string Id = "@Id";
            public const string RecipeName = "@RecipeName";
            public const string Ingredients = "@Ingredients";
            public const string IsActive = "@IsActive";
            //public const string Key = "@Key";
            // public const string Value = "@Value";
            // public const string Comment = "@Comment";
        }

        #endregion Stored proc names, parameters...

        #region Create async

        internal static async Task<int?> CreateAsync(Setting setting)
        {
            int? id;

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Create, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue(Parameter.RecipeName, setting.RecipeName);
                        cmd.Parameters.AddWithValue(Parameter.Ingredients, setting.Ingredients);
                        //cmd.Parameters.AddWithValue(Parameter.Comment, setting.Comment);
                        //cmd.Parameters.AddWithValue(Parameter.ModifiedUserId, setting.ModifiedUserId);
                        //cmd.Parameters.AddWithValue(Parameter.IsActive, setting.IsActive);

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

        #region Search async

        #region Search 

        internal static Artefacts.Settings Search( string recipeName = null , 
            string ingredients = null ,
            bool ? isActive = null)
        {
            var retVal = new Artefacts.Settings();

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Search, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(Parameter.RecipeName, recipeName);
                        cmd.Parameters.AddWithValue(Parameter.Ingredients, ingredients);
                        //cmd.Parameters.AddWithValue(Parameter.Comment, comment);
                        //cmd.Parameters.AddWithValue(Parameter.ModifiedDate, modifiedDate);
                        //cmd.Parameters.AddWithValue(Parameter.ModifiedUserId, modifiedUserId);
                        cmd.Parameters.AddWithValue(Parameter.IsActive, isActive);

                        connection.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                retVal.Add(new Setting(reader));
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

        #endregion Search async



        #endregion Search async
    }

    /// <summary>
    /// Custom SQL
    /// </summary>
    internal static partial class SettingDBAsync
    {
        #region Custom stored proc names, parameters...

        private struct StoredProcCustom
        {
        }

        private struct ParameterCustom
        {
        }

        #endregion Custom stored proc names, parameters...
    }
}