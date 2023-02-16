using Microsoft.Extensions.Options;
using WebApplication_MongoDb_Example.Data;
using WebApplication_MongoDb_Example.Models;

namespace WebApplication_MongoDb_Example.Service
{
    public interface ITodoService : IRepository<TodoItem, string>
    {

    }
    public class TodoService : MongoDbRepositoryBase<TodoItem>, ITodoService
    {
        public TodoService(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
