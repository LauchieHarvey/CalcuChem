using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Stoichiometry_Calculator_v2._0
{
    class EquationClass
    {
        public SpeciesClass UnknownSpecies;
        public SpeciesClass KnownSpecies;
        public string Equation;
        public string[] speciesArray;
        public List<double> MolarRatio = new List<double>();
        public bool isBalanced;
        public EquationClass(string equation, bool isBalancedInput)
        {
            this.isBalanced = isBalancedInput;
            this.Equation = equation;
        }

        public static bool EquationInputRegExCheck(string equation)
        {
            var EquationRegEx = new Regex("^[a-zA-Z0-9+\\s]+\\s=\\s[a-zA-Z0-9+\\s]+$");  //Perhaps expand so that it is less error prone
            return EquationRegEx.IsMatch(equation);
        }

        public void GenerateKnownUnknownSpecies(string Known, string Unknown)
        {
            KnownSpecies = new SpeciesClass(Known);
            UnknownSpecies = new SpeciesClass(Unknown);
        }

        public string[] MakeAndReturnSpeciesArray()
        {
            string[] halfEquations = this.Equation.Split(new string[] { " = " }, StringSplitOptions.None);
            string[] reactants = halfEquations[0].Split(new string[] { " + " }, StringSplitOptions.None);
            string[] products = halfEquations[1].Split(new string[] { " + " }, StringSplitOptions.None);
            this.speciesArray = reactants.Concat(products).ToArray();
            return this.speciesArray;
        }

        public void DetermineMolarRatio() // This is not really necessary. May be good for equation balancing but not yet.
        {
            foreach (string _species in speciesArray)
            {
                double MolarCoefficient;
                if (Char.GetNumericValue(_species[0]) == -1)
                {
                    MolarCoefficient = 1;
                }
                else if (Char.GetNumericValue(_species[1]) != -1)
                {
                    char[] MolarCoefficientCharArray = { _species[0], _species[1] };
                    string MolarCoefficientString = new string (MolarCoefficientCharArray);
                    MolarCoefficient = double.Parse(MolarCoefficientString);
                }
                else 
                {
                    MolarCoefficient = Char.GetNumericValue(_species[0]);
                }
                this.MolarRatio.Add(MolarCoefficient);
            }
        }
        public void StoichiometricCalculation(double MassOrMoleValue, bool MolesIsInput)
        {
            double conversionRatio = MolarRatio[Array.IndexOf(speciesArray, UnknownSpecies._Species)] / MolarRatio[Array.IndexOf(speciesArray, KnownSpecies._Species)];
            if (!MolesIsInput)
            {
                KnownSpecies.Mass = MassOrMoleValue;
                MassOrMoleValue /= KnownSpecies.MolarMass;
            }
            else if (MolesIsInput)
            {
                KnownSpecies.Mass = Math.Round(MassOrMoleValue * KnownSpecies.MolarMass, 3);
            }
            KnownSpecies.Moles = Math.Round(MassOrMoleValue, 3);
            UnknownSpecies.Moles = Math.Round(MassOrMoleValue * conversionRatio, 3);
            UnknownSpecies.Mass = Math.Round(UnknownSpecies.Moles * UnknownSpecies.MolarMass, 3);
        }
    }
}