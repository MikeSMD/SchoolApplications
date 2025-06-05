using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ORMLibrary
{
    public static class MyORM
    {
        public static void Insert<T>(this SqliteConnection dbConnection, T insertObject)
        {
            Type insertingType = typeof(T);
            StringBuilder commandText = new StringBuilder();
            commandText.Append("INSERT INTO [" + insertingType.Name + "](");

            StringBuilder values = new StringBuilder();
            SqliteCommand insertCommand = dbConnection.CreateCommand();

            foreach (PropertyInfo column in insertingType.GetProperties())
            {
                if (column.GetValue(insertObject, new object[] { }) == null) continue;
                if (values.Length > 0)
                {
                    commandText.Append(", ");
                    values.Append(", ");
                }

                commandText.Append(column.Name);
                values.Append("@" + column.Name);

                insertCommand.Parameters.AddWithValue(column.Name, column.GetValue(insertObject, new object[] { }));
            }
            insertCommand.CommandText = commandText.ToString() + ") VALUES(" + values.ToString() + ")";

            insertCommand.ExecuteNonQuery();
        }

        public static long Count<T>(this SqliteConnection dbConnection)
        {
            SqliteCommand sqliteCommand=dbConnection.CreateCommand();
            sqliteCommand.CommandText = "SELECT COUNT(*) FROM [" + typeof(T).Name + "]";
            return (long)sqliteCommand.ExecuteScalar();
        }

        public static void Update<T>(this SqliteConnection dbConnection, T updateObject)
        {

            StringBuilder commandText = new StringBuilder();

            Type updatingClass = typeof(T);

            commandText.Append("UPDATE [" + updatingClass.Name + "] SET ");

            SqliteCommand updateCommand = dbConnection.CreateCommand();

            PropertyInfo key = updatingClass.GetProperties().FirstOrDefault(x => x.Name.Contains("id"));

            foreach (PropertyInfo column in updatingClass.GetProperties())
            {
                if (column.Name == key.Name) continue;
                if (commandText.Length > 14 + updatingClass.Name.Length) commandText.Append(",");

                commandText.Append(column.Name + "=" + "@" + column.Name);
                updateCommand.Parameters.AddWithValue(column.Name, column.GetValue(updateObject, new object[] { }));
            }

            
            commandText.Append(" WHERE " + key.Name + " = @" + key.Name);
            updateCommand.Parameters.AddWithValue(key.Name, key.GetValue(updateObject));

            updateCommand.CommandText = commandText.ToString();

            updateCommand.ExecuteNonQuery();
        }

        public static void Delete<T>(this SqliteConnection dbConnection, T deletingObject)
        {

            Type deletingType = typeof(T);
            PropertyInfo key = deletingType.GetProperties().FirstOrDefault(x => x.Name.Contains("id"));

            SqliteCommand deleteCommand = dbConnection.CreateCommand();
            deleteCommand.CommandText = "DELETE FROM [" + deletingType.Name + "] WHERE " + key.Name + " =@" + key.Name;
            deleteCommand.Parameters.AddWithValue(key.Name, key.GetValue(deletingObject));

            deleteCommand.ExecuteNonQuery();
        }

        public static T Get<T>(this SqliteConnection sqliteConnection, object idValue)
        {
            Type getType = typeof(T);

            PropertyInfo key = getType.GetProperties().FirstOrDefault(x=>x.Name.Contains("id"));

            SqliteCommand sqliteCommand = sqliteConnection.CreateCommand();

            sqliteCommand.CommandText = "SELECT * FROM [" + getType.Name + "] WHERE " + key.Name + " = @" + key.Name;
            sqliteCommand.Parameters.AddWithValue(key.Name, idValue);

            using SqliteDataReader dataReader = sqliteCommand.ExecuteReader();

            T result = Activator.CreateInstance<T>();
            dataReader.Read();

            foreach(PropertyInfo property in getType.GetRuntimeProperties())
            {
                    if (!dataReader.IsDBNull(dataReader.GetOrdinal(property.Name)))
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(result, dataReader.GetString(dataReader.GetOrdinal(property.Name)));
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {
                            property.SetValue(result, dataReader.GetDateTime(dataReader.GetOrdinal(property.Name)));
                        }
                        else if (property.PropertyType == typeof(int))
                        {
                            property.SetValue(result, dataReader.GetInt32(dataReader.GetOrdinal(property.Name)));
                        }
                        else if (property.PropertyType == typeof(long))
                        {
                            property.SetValue(result, dataReader.GetInt64(dataReader.GetOrdinal(property.Name)));
                        }
                        else if (property.PropertyType == typeof(double))
                        {
                            property.SetValue(result, dataReader.GetDouble(dataReader.GetOrdinal(property.Name)));
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
            }

            return result;
        }

        public static async Task<List<T>> Select<T>(this SqliteConnection dbConnection, string? nazevAtributu = null, object? hodnota = null)
        {
            Type selectingType = typeof(T);

            SqliteCommand selectCommand = dbConnection.CreateCommand();
            selectCommand.CommandText = "SELECT * FROM [" + selectingType.Name + "]";

        
            if (nazevAtributu != null) {
                selectCommand.CommandText += " WHERE " + nazevAtributu + " = @" + nazevAtributu;
                selectCommand.Parameters.AddWithValue(nazevAtributu, hodnota);
            }

            using SqliteDataReader selectedData = await selectCommand.ExecuteReaderAsync();

            List<T> items = new List<T>();


            while (selectedData.Read())
            {
                T item = Activator.CreateInstance<T>();

                foreach (PropertyInfo column in selectingType.GetProperties())
                {
                    if (!selectedData.IsDBNull(selectedData.GetOrdinal(column.Name)))
                    {
                        if (column.PropertyType == typeof(string))
                        {
                            column.SetValue(item, selectedData.GetString(selectedData.GetOrdinal(column.Name)));
                        }
                        else if (column.PropertyType == typeof(DateTime))
                        {
                            column.SetValue(item, selectedData.GetDateTime(selectedData.GetOrdinal(column.Name)));
                        }
                        else if (column.PropertyType == typeof(int))
                        {
                            column.SetValue(item, selectedData.GetInt32(selectedData.GetOrdinal(column.Name)));
                        }
                        else if (column.PropertyType == typeof(long))
                        {
                            column.SetValue(item,selectedData.GetInt64(selectedData.GetOrdinal(column.Name)));
                        }
                        else if (column.PropertyType == typeof(double))
                        {
                            column.SetValue(item,selectedData.GetDouble(selectedData.GetOrdinal(column.Name)));
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }

                items.Add(item);

            }
            return items;
        }
    }
}
