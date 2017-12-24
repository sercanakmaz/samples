using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Boilerplate.Core.Entities
{
    public interface IGenericEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
    }
    public interface IEntity
    {
        DateTime CreatedDateTime { get; set; }
    }
    public class GenericEntity<TKey> : IGenericEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
