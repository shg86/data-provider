using Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace DataProvider
{
    public abstract class Repository<T> where T : new()
    {
        /// <summary>
        /// Specifies if errors should be logged in a text file.
        /// </summary>
        [DefaultValue(false)]
        public bool LogErrors { get; set; }

        protected IEnumerable<T> ToList(IDbCommand command)
        {
            List<T> items = new List<T>();

            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = CreateEntity();
                        Map(reader, item);
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                if (LogErrors) { WriteMessageToLog(Log.GetCurrentMethod(), ex.Message, MessageType.Error); }
            }

            return items;
        }

        protected T ToSingle(IDbCommand command)
        {
            T item = new T();

            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Map(reader, item);
                    }
                }
            }
            catch (Exception ex)
            {
                if (LogErrors) { WriteMessageToLog(Log.GetCurrentMethod(), ex.Message, MessageType.Error); }
            }

            return item;
        }

        protected void ExecuteCommand(IDbCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (LogErrors) { WriteMessageToLog(Log.GetCurrentMethod(), ex.Message, MessageType.Error); }
            }
        }

        protected object ExecuteScalar(IDbCommand command)
        {
            object result = null;

            try
            {
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (LogErrors) { WriteMessageToLog(Log.GetCurrentMethod(), ex.Message, MessageType.Error); }
            }

            return result;
        }

        protected void WriteMessageToLog(string methodName, string message, MessageType type)
        {
            Log.Message(methodName, string.Format("An error occured during command executing: {0}", message), type);
        }

        protected abstract void Map(IDataRecord record, T entity);
        protected abstract T CreateEntity();
    }
}
