using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Models;

namespace TestEshop.Database
{
   public abstract class DatabaseHandler<TEntity, TDescriptor> : IDatabaseHandler<TEntity> //, IGenericHandler //, TDescriptor> 
      where TDescriptor : IDescriptor
      where TEntity : IEntity, new()
   {
      public abstract TDescriptor descriptor { get; }
   
      public virtual void Delete(TEntity entity)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Generic SELECT * method for an entity
      /// </summary>
      public virtual List<TEntity> GetAll()
      {
         List<TEntity> results = new List<TEntity>();
         Query qryGetAll = GetQuery("GetAll");
         if(qryGetAll!=null) { 
            using (SqlConnection connection = DBManager.instance.Connection)
            {
               SqlCommand command = GetCommand(connection, qryGetAll.SQLQuery, qryGetAll.QueryParameters);
               SqlDataReader reader = command.ExecuteReader();
            
               while(reader.Read())
               { 
                  var id = reader["Id"];
                  TEntity entity = new TEntity();
                  entity = PopulateRecord(reader, entity);
                  results.Add(entity);
               }
            };
         }

         return results;
      }

      /// <summary>
      /// Generic SELECT by Id method for an entity
      /// </summary>
      public virtual TEntity GetById(int Id)
      {
         TEntity result = new TEntity();
         Query qryGetById = GetQuery("GetById");

         if (qryGetById != null)
         {
            using (SqlConnection connection = DBManager.instance.Connection)
            {
               SqlCommand command = GetCommand(connection, qryGetById.SQLQuery, qryGetById.QueryParameters, Id);
               SqlDataReader reader = command.ExecuteReader();

               if (reader.Read())
               {
                  result = PopulateRecord(reader, result);
               }
            };
         }

         return result;
      }

      /// <summary>
      /// Generic INSERT method for an entity
      /// </summary>
      public virtual void Insert(TEntity entity)
      {
         Query qryInsert = GetQuery("Insert");
         if (qryInsert != null)
         {
            object[] parameterValues = GetParameterValuesFromObject(entity, qryInsert.QueryParameters);

            using (SqlConnection connection = DBManager.instance.Connection)
            {
               SqlCommand command = GetCommand(connection, qryInsert.SQLQuery, qryInsert.QueryParameters, parameterValues);
               command.ExecuteNonQuery();
            }
         }
      }

      public virtual void Update(TEntity entity)
      {
         throw new NotImplementedException();
      }

      private SqlCommand GetCommand(SqlConnection connection, string sqlQuery, List<QueryParameter> sqlParameters)
      {
         return GetCommand(connection, sqlQuery, sqlParameters, null);
      }

      /// <summary>
      /// This method gets the SqlCommand to be executed based on:
      ///   - The SQL query that is provided
      ///   - The list of parameters to be passed (optional)
      ///   - The list of parameter values (also optional)
      /// </summary>
      private SqlCommand GetCommand(SqlConnection connection, string sqlQuery, List<QueryParameter> sqlParameters, params object[] parameterValues) 
      {
         SqlCommand command = new SqlCommand(sqlQuery, connection);
         if(sqlParameters!=null)
         {
            for(int i = 0; i < sqlParameters.Count; i++ )
            {
               QueryParameter param = sqlParameters[i];
               switch(param.Type.ToLower())
               {
                  case "int":
                     command.Parameters.AddWithValue(param.Name, (int) parameterValues[i]);
                     break;
                  case "decimal":
                     command.Parameters.AddWithValue(param.Name, (decimal)parameterValues[i]);
                     break;
                  case "bool":
                     command.Parameters.AddWithValue(param.Name, (bool)parameterValues[i]);
                     break;
                  case "string":
                     command.Parameters.AddWithValue(param.Name, (string)parameterValues[i]);
                     break;
                  case "datetime":
                     command.Parameters.AddWithValue(param.Name, (DateTime)parameterValues[i]);
                     break;
               }
            }
         }

         return command;
      }

      /// <summary>
      /// This method compares an entity to an SqlDataReader and if it matches table columns with entity properties, it populates their values with reflection
      /// </summary>
      private TEntity PopulateRecord(SqlDataReader reader, TEntity entity)
      {
         var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();  // Enumerate columns of the table
         var objectProperties = entity.GetType().GetProperties();                               // Enumerate properties of the object
         foreach(var prop in objectProperties)
         {
            if (columns.Contains(prop.Name)) // If I find that an object property matches a column name, assign the column value to the property
            {
               if(!reader.IsDBNull(reader.GetOrdinal(prop.Name))) // Check if column is NULL
                  prop.SetValue(entity, reader[prop.Name]);
            }
         }

         return entity;
      }

      /// <summary>
      /// This method compares an entity with SQL Query parameters and returns an array of the object values if matched with the requested parameters
      /// </summary>
      private object[] GetParameterValuesFromObject(TEntity entity, List<QueryParameter> qryParams)
      {
         List<object> result = new List<object>();
         var objectProperties = entity.GetType().GetProperties().Select(x => x.Name).ToList();
         
         foreach (var q in qryParams.Select(x => x.Name.Replace("@","")))  // Query parameters start with @, we need to remove this to match with object properties
         {
            if (objectProperties.Contains(q))
            {
               var prop = entity.GetType().GetProperties().Where(x => x.Name == q).First();
               result.Add(prop.GetValue(entity));
            }
         }

         return result.ToArray();
      }

      private Query GetQuery(string QueryName)
      {
         return descriptor.QueryDef.Queries.Where(x => x.QueryName.Equals(QueryName)).First();
      }

   }
}
