using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.DAL
{
    public class liteDbEntity
    {
        private string ConnectionString { get; set; }

        public liteDbEntity(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Отсутствует строка подключения");
            else
                ConnectionString = connectionString;
        }

        public List<T> GetCollection<T>()
        {
            try
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    return db.GetCollection<T>(typeof(T).Name)
                        .FindAll()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        public bool Create<T>(T data, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collecection = db.GetCollection<T>(typeof(T).Name);
                    collecection.Insert(data);
                }
                message = "success";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }                
        }

        public bool UpDate<T>(T data, out string message)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(ConnectionString))
                {
                    var collecection = db.GetCollection<T>(typeof(T).Name);
                    collecection.Update(data);
                }
                message = "success";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;                
            }
        }
    }
}
