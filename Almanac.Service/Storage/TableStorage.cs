using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Almanac.Service.Storage
{
    public class TableStorage<T> : ITableStorage<T> where T : TableEntity, new()
    {
        private CloudTable cloudTable;

        public TableStorage(string tableName,string connectionString)
        {
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            cloudTable = tableClient.GetTableReference(tableName);
            cloudTable.CreateIfNotExists();

        }
       

        public bool AddOrUpdate(T entity)
        {
            try
            {
                var addOrUpdateOperation = TableOperation.InsertOrReplace(entity);
                cloudTable.Execute(addOrUpdateOperation);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                var deleteOperation = TableOperation.Delete(entity);
                cloudTable.Execute(deleteOperation);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<T> Get(string query=null)
        {
            try
            {
                TableQuery<T> tableQuery = new TableQuery<T>();
                if (!string.IsNullOrEmpty(query))
                {
                    tableQuery = new TableQuery<T>().Where(query);
                }

                var results = cloudTable.ExecuteQuery(tableQuery);
                
               return  results.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
