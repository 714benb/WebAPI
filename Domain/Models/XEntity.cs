using System.Collections;
using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class XEntity
    {
        public int Id {get;set;}
        public string Name {get; set;}
        public IList<YEntity> YEntities {get; set;} = new List<YEntity>();

        public override string ToString()
        {
            return $"Id: {Id}  Name: {Name} YEntity Count: {YEntities?.Count}";
        }

    
    }

}