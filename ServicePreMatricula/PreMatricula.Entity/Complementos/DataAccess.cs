using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace PreMatricula.Entity.Complementos
{
  [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
  [SuppressMessage("ReSharper", "RedundantAssignment")]
  [SuppressMessage("ReSharper", "RedundantNameQualifier")]
  public class DataAccess
  {
    internal string ConexionSql = "Data Source=L0003416\\PROYECTO_SOFWARE;Initial Catalog=PreMatrcicula;Connection Timeout=900; Persist Security Info=True;User ID=sa;Password=@grupoUNI";

    public List<TSource> ExecuteSqlProcedure<TSource, TParam>(string procedureName, TParam parameters) where TSource : new()
    {
      if (string.IsNullOrEmpty(ConexionSql))
        return null;

      var sqlDb = new SqlDatabase(ConexionSql);

      SqlParameter[] sqlParameters = GetParametersSqlQuery(parameters);
      DbCommand dbCmd = sqlDb.GetStoredProcCommand(procedureName);
      dbCmd.CommandTimeout = 900;
      dbCmd.Parameters.AddRange(sqlParameters);

      List<TSource> listaDatos = new List<TSource>();
      const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
      var propiedadesObjeto = (from PropertyInfo propiedad in typeof(TSource).GetProperties(flags)
                               select new
                               {
                                 CampoBD = propiedad.GetCustomAttributes(true).Any() ? (propiedad.GetCustomAttributes(true).ElementAt(0) as DbField).Name ?? string.Empty : string.Empty,
                                 NombreProp = propiedad.Name,
                                 TipoDato = Nullable.GetUnderlyingType(propiedad.PropertyType) ?? propiedad.PropertyType
                               }).ToList();

      using (IDataReader reader = sqlDb.ExecuteReader(dbCmd))
      {
        TSource entidad = default(TSource);
        while (reader.Read())
        {
          entidad = Activator.CreateInstance<TSource>();
          foreach (var propiedad in propiedadesObjeto)
          {
            if (propiedad.CampoBD != string.Empty)
            {
              PropertyInfo infoPropiedad = entidad.GetType().GetProperty(propiedad.NombreProp);
              if (!object.Equals(reader[propiedad.CampoBD], DBNull.Value))
              {
                infoPropiedad.SetValue(entidad, reader[propiedad.CampoBD], null);
              }
            }
          }
          listaDatos.Add(entidad);
        }
      }
      return listaDatos;
    }
    private static SqlParameter[] GetParametersSqlQuery<TSource>(TSource parameters)
    {
      List<SqlParameter> listaParametro = new List<SqlParameter>();

      if (parameters == null)
      {
        return listaParametro.ToArray();
      }

      const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
      var propiedadesObjeto = (from PropertyInfo propiedad in typeof(TSource).GetProperties(flags)
                               select new
                               {
                                 CampoBD = propiedad.GetCustomAttributes(true).Any() ? (propiedad.GetCustomAttributes(true).ElementAt(0) as DbField).Name ?? string.Empty : string.Empty,
                                 NombreProp = propiedad.Name,
                                 TipoDato = Nullable.GetUnderlyingType(propiedad.PropertyType) ?? propiedad.PropertyType,
                               }).ToList();



      foreach (var propiedad in propiedadesObjeto)
      {
        if (propiedad.CampoBD != string.Empty)
        {
          PropertyInfo infoPropiedad = parameters.GetType().GetProperty(propiedad.NombreProp);
          dynamic valor = infoPropiedad.GetValue(parameters, null);
          Type type = Nullable.GetUnderlyingType(infoPropiedad.PropertyType);
          type = type ?? infoPropiedad.PropertyType;
          var param = new SqlParameter();
          if (type == typeof(DataTable))
          {
            param = new SqlParameter
            {
              ParameterName = "@" + propiedad.CampoBD,
              Value = valor,
              SqlDbType = SqlDbType.Structured
            };
          }
          else
          {
            if (propiedad.CampoBD != string.Empty)
            {
              param = new SqlParameter
              {
                ParameterName = $"@{propiedad.CampoBD}",
                Value = valor
              };
            }
          }
          listaParametro.Add(param);



        }
      }
      return listaParametro.ToArray();
    }
    public TSource ExecuteSqlProcedureSingle<TSource, TParam>(string procedureName, TParam parameters) where TSource : new()
    {
      TSource entidad = default(TSource);

      if (string.IsNullOrEmpty(ConexionSql))
        return entidad;

      var sqlDb = new SqlDatabase(ConexionSql);

      SqlParameter[] sqlParameters = GetParametersSqlQuery(parameters);
      DbCommand dbCmd = sqlDb.GetStoredProcCommand(procedureName);
      dbCmd.CommandTimeout = 900;
      dbCmd.Parameters.AddRange(sqlParameters);


      const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
      var propiedadesObjeto = (from PropertyInfo propiedad in typeof(TSource).GetProperties(flags)
                               select new
                               {
                                 CampoBD = propiedad.GetCustomAttributes(true).Any() ? (propiedad.GetCustomAttributes(true).ElementAt(0) as DbField).Name ?? string.Empty : string.Empty,
                                 NombreProp = propiedad.Name,
                                 TipoDato = Nullable.GetUnderlyingType(propiedad.PropertyType) ?? propiedad.PropertyType
                               }).ToList();

      IDataReader reader = sqlDb.ExecuteReader(dbCmd);

      while (reader.Read())
      {
        entidad = Activator.CreateInstance<TSource>();
        foreach (var propiedad in propiedadesObjeto)
        {
          if (propiedad.CampoBD != string.Empty)
          {
            PropertyInfo infoPropiedad = entidad.GetType().GetProperty(propiedad.NombreProp);
            if (!object.Equals(reader[propiedad.CampoBD], DBNull.Value))
            {
              infoPropiedad.SetValue(entidad, reader[propiedad.CampoBD], null);
            }
          }
        }
      }

      return entidad;
    }



  }
}
