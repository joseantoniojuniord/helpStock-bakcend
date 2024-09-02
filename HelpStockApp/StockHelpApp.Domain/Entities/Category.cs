using StockHelpApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockHelpApp.Domain.Endities
{
    public class Category: Entity
    {
        public string Name { get; set; }

        public Category(string name)
        { 
            this.Name = name; 
        }

        public Category(int id,string name) 
        { 
            Id = id;
            Name = name;
        }
    }

}
