using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using static System.Net.Mime.MediaTypeNames;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region testes positivos
        [Fact(DisplayName = "Create Product with valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Televisão", "60 polegadas", 10000, 50, "https://tev60p.jpg");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion


        #region testes negativos
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidParemetersId_ResultException()
        {
            Action action = () => new Product(-1, "Televisão", "60 polegadas", 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Name Null Parameter")]
        public void CreateProduct_WithNameNullParameter_ResultException()
        {
            Action action = () => new Product(1, null, "60 polegadas", 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Name Empty Parameter")]
        public void CreateProduct_WithNameEmptyParameter_ResultException()
        {
            Action action = () => new Product(1, "", "60 polegadas", 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Name too short Parameter")]
        public void CreateProduct_WithNameTooShortParameter_ResultException()
        {
            Action action = () => new Product(1, "te", "60 polegadas", 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Image Too Long Parameter")]
        public void CreateProduct_WithImageTooLongParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", "60 polegadas", 10000, 50, "https://example.com/images/this-is-a-very-long-url-forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Image URL Null Parameter")]
        public void CreateProduct_WithImageNullParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", "60 polegadas", 10000, 50, null);
            action.Should().Throw<System.NullReferenceException>();      
        }

        [Fact(DisplayName = "Create Product With Image URL Empty Parameter")]
        public void CreateProduct_WithImageEmptyParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", "60 polegadas", 10000, 50, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, image URL is required!");
        }

        [Fact(DisplayName = "Create Product With stock negative Parameter")]
        public void CreateProduct_WithNegativeStockParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", "60 polegadas", 10000, -1, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With price negative Parameter")]
        public void CreateProduct_WithNegativePriceParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", "60 polegadas", -1, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price, price negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Name Too Long Parameter")]
        public void CreateProduct_WithNameTooLongParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisãoooooooooooooooooooooooooo" +
                "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                "ooooooooooooooooooooooooooooooooooooooooooo", "60 polegadas", 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too long. maximum 200 characters!");
        }

        [Fact(DisplayName = "Create Product With Description Null Parameter")]
        public void CreateProduct_WithDescriptionNullParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", null, 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
             .WithMessage("Invalid description, description is required!");
        }

        [Fact(DisplayName = "Create Product With Description Empty Parameter")]
        public void CreateProduct_WithDescriptionEmptyParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", "", 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
             .WithMessage("Invalid description, description is required!");
        }

        [Fact(DisplayName = "Create Product With Description too short Parameter")]
        public void CreateProduct_WithDescriptionTooShortParameter_ResultException()
        {
            Action action = () => new Product(1, "Televisão", "60po", 10000, 50, "https://tev60p.jpg");
            action.Should().Throw<DomainExceptionValidation>()
             .WithMessage("Invalid description, too short. minimum 5 characters!");
        }

        #endregion

    }
}