using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stoichiometry_Calculator_v2._0
{
    public class SpeciesClass
    {
        public string _Species;
        private static readonly double[] elementMolarMassArray = { 1.01, 4, 6.94, 9.01, 10.81, 12.01, 14.01, 16, 19,
                      20.18, 22.99, 24.31, 26.98, 28.09, 30.97, 32.07, 35.45, 39.48, 39.1, 40.08, 44.96, 47.87, 50.94,
                      52, 54.94, 55.85, 58.93, 58.69, 63.55, 65.39, 69.72, 72.64, 74.92, 78.96, 79.9, 83.8, 85.47, 87.62, 88.91,
                      91.22, 92.91, 95.94, 98, 101.07, 102.01, 106.42, 107.87, 112.41, 114.82, 119.71, 121.76, 127.6,
                      126.91, 131.29, 132.01, 137.33, 138.91, 140.12, 140.91, 144.24, 145, 150.36, 151.96, 157.25, 158.93,
                      162.5, 164.93, 167.259, 168.93, 173.04, 174.97, 178.49, 180.95, 183.84, 186.21, 190.23, 192.22,
                      195.08, 196.97, 200.59, 204.38, 207.2, 208.98, 209, 237, 244, 243, 247, 247, 251, 252, 257, 258, 259,
                      262, 261, 262, 266, 264, 277};
        private static readonly object[] elementSymbolArray = { 'H', "He", "Li", "Be", 'B', 'C', 'N', 'O', 'F', "Ne",
                  "Na", "Mg", "Al", "Si", 'P', 'S', "Cl", "Ar", 'K', "Ca", "Sc", "Ti", 'V', "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn",
                  "Ga", "Ge", "As", "Se", "Br", "Kr", "Rb", "Sr", 'Y', "Zr", "Nb", "Mo", "Tc", "Ru", "Rh", "Pd", "Ag", "Cd", "In", "Sn",
                  "Sb", "Te", 'I', "Xe", "Cs", "Ba", "La", "Ce", "Pr", "Nd", "Pm", "Sm", "Eu", "Gd", "Tb", "Dy", "Ho", "Er", "Tm", "Yb",
                  "Lu", "Hf", "Ta", 'W', "Re", "Os", "Ir", "Pt", "Au", "Hg", "Tl", "Pb", "Bi", "Po", "At", "Rn", "Fr", "Ra", "Ac", "Th",
                  "Pa", 'U', "Np", "Pu", "Am", "Cm", "Bk", "Cf", "Es", "Fm", "Md", "No", "Lr", "Rf", "Db", "Sg", "Bh", "Hs"};
        public double MolarMass = 0;
        public List<object> Elements = new List<object>();
        private List<int> openBracketArray = new List<int>();
        private List<int> closeBracketArray = new List<int>();
        public double Moles;
        public double Mass;

        public SpeciesClass(string IndividualSpecies)
        {
            this._Species = IndividualSpecies;
        }

        public void DefineSpeciesElements()
        {
            for (int i = 0; i < _Species.Length; i++)
            {
                if (Char.IsUpper(_Species[i]) && CheckIndexNotOutOfRange(_Species, i + 1) && Char.IsLower(_Species[i + 1]))
                {
                    Elements.Add(_Species[i] + _Species[i + 1]);
                    continue;
                }
                else if (Char.IsUpper(_Species[i]))
                {
                    Elements.Add(_Species[i]);
                    continue;
                }
            }
        }
        private bool CheckIndexNotOutOfRange(string stringToCheck, int indexInString)
        {
            try
            {
                Console.WriteLine(stringToCheck[indexInString]);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        public void DeterminePolyatomicIndices()
        {
            for (int i = 0; i < _Species.Length; i++)
            {
                if (_Species[i] == '(')
                {
                    openBracketArray.Add(i);
                }
                else if (_Species[i] == ')')
                {
                    closeBracketArray.Add(i);
                }
            }
        }
        //Doesn't work with repeated elements in a species because of elementIndex var.
        public void DetermineMolarMass() 
        {
            foreach (var element in Elements)
            {
                double elementCoefficient = 1;
                int elementIndex;
                try
                {
                    Convert.ToChar(element);
                    elementIndex = _Species.IndexOf((char)element);
                }
                catch (InvalidCastException)
                {
                    Convert.ToString(element);
                    elementIndex = _Species.IndexOf((string)element);
                }

                int elementSymbolIndex = System.Array.IndexOf(elementSymbolArray, element);
                elementCoefficient = DetermineElementCoefficient(elementIndex);

                this.MolarMass += elementMolarMassArray[elementSymbolIndex] * elementCoefficient;
            }
        }
        private double DetermineElementCoefficient(int elementIndex) //could make static if you need to repeat this for balancing (Just parse the _Species variable as a param))
        {
            double elementCoefficient = 1;
            if (CheckIndexNotOutOfRange(_Species, elementIndex + 2) && Char.GetNumericValue(_Species[elementIndex + 2]) != -1 && Char.GetNumericValue(_Species[elementIndex + 1]) != -1)
            {
                elementCoefficient = Char.GetNumericValue(_Species[elementIndex + 2]);
            }
            else if (CheckIndexNotOutOfRange(_Species, elementIndex + 1) && Char.GetNumericValue(_Species[elementIndex + 1]) != -1)
            {
                elementCoefficient = Char.GetNumericValue(_Species[elementIndex + 1]);
            }

            for (int i = 0; i < openBracketArray.Count; i++)
            {
                if (elementIndex > openBracketArray[i] && elementIndex < closeBracketArray[i])
                {
                    elementCoefficient *= (double)Char.GetNumericValue(_Species[closeBracketArray[i] + 1]); //index error risk?
                }
            }
            return elementCoefficient;
        }
    }
}
