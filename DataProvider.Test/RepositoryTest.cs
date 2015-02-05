using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataProvider.Test
{
    [TestClass]
    public class RepositoryTest
    {
        //TODO: add test methods.

        [TestMethod]
        public void TestMethod1()
        {
            var repository = new DataRepository();

            repository.LogErrors = true;

            var list = repository.Retrieve();
            
        }
    }

    class Data
    {
        public int ID { get; set; }
        public int Order { get; set; }
    }

    class DataRepository : Repository<Data>
    {
        public IEnumerable<Data> Retrieve()
        {
            return ToList(new SqlCommand());
        }

        protected override void Map(System.Data.IDataRecord record, Data entity)
        {
            entity.ID = (int)record["id"];
            entity.Order = (int)record["order"];
        }

        protected override Data CreateEntity()
        {
            return new Data();
        }
    }

}
