using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        private string ConnectString = @"";

        public SqlConnection GetConnect()
        {
            return new SqlConnection(ConnectString);
        }

        public DataTable GetDataTable(string sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void ExecuteNonQuery(string sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlCommand.Clone();
        }

        public SqlDataReader ExecuteReader(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            return new SqlCommand(sql, con).ExecuteReader();
        }

        public List<T> GetEntities<T>()
        {
            List<T> entities = new List<T>();
            String name = Activator.CreateInstance<T>().GetType().Name;
            SqlDataReader read = this.ExecuteReader("SELECT * FROM " + name);
            while (read.Read())
            {
                T entity = Activator.CreateInstance<T>();
                for (int i = 0; i < read.FieldCount; i++)
                {
                    var colName = read.GetName(i);
                    var colval = read.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(colName);
                    if (propertyInfo != null && colval != DBNull.Value)
                    {
                        propertyInfo.SetValue(entity, colval);
                    }
                }
                entities.Add(entity);
            }
            return entities;
        }

        public List<T> GetEntities<T>(SqlDataReader read)
        {
            SqlConnection con = GetConnect();
            con.Open();
            List<T> entities = new List<T>();
            while (read.Read())
            {
                T entity = Activator.CreateInstance<T>();
                for (int i = 0; i < read.FieldCount; i++)
                {
                    var colName = read.GetName(i);
                    var colval = read.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(colName);
                    if (propertyInfo != null && colval != DBNull.Value)
                    {
                        propertyInfo.SetValue(entity, colval);
                    }
                }
                entities.Add(entity);
            }
            return entities;
        }

        public void DeleteEntity<T>(Guid keyValue)
        {
            SqlConnection con = GetConnect();
            con.Open();
            T entity = Activator.CreateInstance<T>();
            string entityName = entity.GetType().Name;
            string keyName = string.Empty;
            //
            Type keyType = new KeyAttribute().GetType();
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                if (prop.GetCustomAttributes(keyType, false).Length > 0)
                {
                    keyName = prop.GetType().Name;
                    break;
                }
            }
            //
            if (keyName.Equals(string.Empty))
            {
                keyName = entityName + "ID";
            }
            string sql = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", entityName, keyName, keyValue);
            ExecuteNonQuery(sql);

        }
    }
}
