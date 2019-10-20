using NUnit.Framework;

namespace StoichiometryCalculator.UnitTests
{
    public class EquationClassTest
    {
        [Test]
        public void MakeAndReturnSpeciesArray() //NameOfMethod_Scenario_ExpectedResult
        {
            // Arrange
            var Reaction = new EquationClass();
            Reaction.Equation = "H2 + O2 = 2H2O";
            // Act
            Assert.Pass(); // Assert
        }
    }
}