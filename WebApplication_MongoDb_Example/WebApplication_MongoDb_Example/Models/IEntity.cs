using System.Security.Principal;

namespace WebApplication_MongoDb_Example.Models
{
    public interface IEntity{}
    public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
        DateTime CreatedAt { get; set; }
    }
}
