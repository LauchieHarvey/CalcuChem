using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stoichiometry_Calculator_v2._0
{
    public partial class CalculatorPage : Page
    {
        private EquationClass Reaction;

        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void EquationFieldsClickEventListener(object sender, RoutedEventArgs e)
        {
            if (CheckEquationFieldsForErrorsReturnIfFound())
            {
                return;
            }
            Reaction = new EquationClass(equationTextBox.Text, isBalancedCheckBox.IsChecked.Value);
            Reaction.speciesArray = Reaction.MakeAndReturnSpeciesArray();
            UpdateUIAfterSubmittedEquationFields();
        }
        public void MolesMassSpeciesFieldsClickEventListener(object sender, RoutedEventArgs e) // this bad boy needs cleaning.
        {
            Reaction.GenerateKnownUnknownSpecies(Reaction.speciesArray[knownSpeciesComboBox.SelectedIndex], Reaction.speciesArray[unknownSpeciesComboBox.SelectedIndex]);
            Reaction.KnownSpecies.DefineSpeciesElements();
            Reaction.UnknownSpecies.DefineSpeciesElements();
            Reaction.KnownSpecies.DeterminePolyatomicIndices();
            Reaction.UnknownSpecies.DeterminePolyatomicIndices();
            Reaction.KnownSpecies.DetermineMolarMass();
            Reaction.UnknownSpecies.DetermineMolarMass();
            Reaction.DetermineMolarRatio();
            Reaction.StoichiometricCalculation(Convert.ToDouble(massMolesInput.Text), (bool)Moles.IsChecked);
            DisplayCalculationResult();
        }
        private void UpdateUIAfterSubmittedEquationFields()
        {
            equationFieldsPanel.IsEnabled = false;
            SpeciesMassFieldsGrid.IsEnabled = true;
            SetComboBoxFields(Reaction.speciesArray);
        }
        private bool CheckEquationFieldsForErrorsReturnIfFound()
        {
            if (!isBalancedCheckBox.IsChecked.Value)
            {
                MessageBox.Show("Unfortunately I don't have the\nability to balance equations yet.\nPlease enter a balanced equation.");
                return true;
            }
            if (!EquationClass.EquationInputRegExCheck(equationTextBox.Text)) //Check regular expression of inputted equation
            {
                MessageBox.Show("It looks like you entered the equation in the wrong format.\nIt must be like: X + Y = Z");
                return true;
            }
            return false;
        }

        private void SetComboBoxFields(string[] species)
        {
            knownSpeciesComboBox.ItemsSource = species;
            unknownSpeciesComboBox.ItemsSource = species;
        }

        private void DisplayCalculationResult() // Static?
        {
            MessageBox.Show($"Known species: {Reaction.KnownSpecies._Species} Mass = {Reaction.KnownSpecies.Mass}g, Moles = {Reaction.KnownSpecies.Moles}mol\n" +
                $"Unknown species: {Reaction.UnknownSpecies._Species} has a mass of {Reaction.UnknownSpecies.Mass}g, Moles = {Reaction.UnknownSpecies.Moles}mol");
        }
    }
}
