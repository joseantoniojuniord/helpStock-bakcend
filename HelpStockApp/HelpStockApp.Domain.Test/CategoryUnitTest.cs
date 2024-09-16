using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockHelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using StockHelpApp.Domain.Endities;
using StockHelpApp.Domain.Validation;

namespace HelpStockApp.Domain.Test
{
  
    public class CategoryUnitTest
    {
        #region Testes positivos de Categoria
        [Fact(DisplayName = "Create category with valid State")]
        
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Eletronics");
            action.Should().NotThrow<DomainExceptionValidation>();

        }
        #endregion

        #region Testes negativos de Categoria 
        [Fact(DisplayName = "Create category whith Invalid Id")]
        public void CreateCategory_WithInvalidParameters_ResultException()
        {
            Action action = () => new Category(-1, "Eletronics");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        #endregion

     }
    /*
     *  Create Category With name too short parameter
     *  Create category with name null Parameter
     *  create category with name missing Parameter
     *  create category with id caracter Parameter
     *  create category with category name alone parameter
     */
}


