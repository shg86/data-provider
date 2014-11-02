using CustomDiagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repository
{
    public abstract class Repository<T> where T : new()
    {
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
                Log.Message(Log.GetCurrentMethod(), string.Format("An error occured during data retrieval: {0}", ex.Message), MessageType.Error);
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
                Log.Message(Log.GetCurrentMethod(), string.Format("An error occured during data retrieval: {0}", ex.Message), MessageType.Error);
            }

            return item;
        }

        private void _Test()
        {
            for (int i = 0; i < 10; i++)
            {
                
            }
        }

        protected void ExecuteCommand(IDbCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.Message(Log.GetCurrentMethod(), string.Format("An error occured during command executing: {0}", ex.Message), MessageType.Error);
            }
        }

        protected abstract void Map(IDataRecord record, T entity);
        protected abstract T CreateEntity();
    }
}
