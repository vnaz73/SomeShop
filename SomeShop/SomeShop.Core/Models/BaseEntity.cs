using System;

namespace SomeShop.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}
