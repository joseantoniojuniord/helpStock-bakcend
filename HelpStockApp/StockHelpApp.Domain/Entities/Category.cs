using StockHelpApp.Domain.Entities;
using StockHelpApp.Domain.Validation;
using System;
using System.Collections;
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
            validateDomain(name); 
        }

        public Category(int id,string name) 
        { 
            Id = id;
            validateDomain(name);
        }

        public ICollection<Product> Products { get; set; }
    
        private void validateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),"Invalid name, name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. minimum 3 characteres!");

            Name = name;
        }
    }

}
