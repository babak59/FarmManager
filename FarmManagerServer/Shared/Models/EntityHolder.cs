
namespace Shared.Models
{
    public class EntityHolder<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }
        public string BaseUrl { get; set; }
    }
}
