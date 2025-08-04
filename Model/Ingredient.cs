using CommunityToolkit.Mvvm.ComponentModel;
using RecipeVault.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public partial class Ingredient : AppObject
    {
        public MeasurementUnitCategory MeasurementUnitCategory { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Symbol))]
        [NotifyPropertyChangedFor(nameof(FormattedIngredientInfo))]
        private MeasurementUnit measurementUnit;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Symbol))]
        [NotifyPropertyChangedFor(nameof(FormattedIngredientInfo))]
        private double quantity;

        public double OriginalQuantity { get; set; }
        public MeasurementUnit OriginalMeasurementUnit { get; set; }

        public string Note { get; set; }
        public string Symbol
        {
            get
            {
                MeasurementUnitHelper helper = new MeasurementUnitHelper();
                return helper.GetUnitSymbol((MeasurementUnit)MeasurementUnit, Quantity);
            }
        }

        public virtual string FormattedIngredientInfo
        {
            get
            {
                string note = Note == "" ? "" : $" - {Note}";

                string symbol = Symbol == "" ? Symbol : $" {Symbol}";

                string quantity = Quantity == 0 ? "" : Math.Round(Quantity, 3).ToString();

                return $"{System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Name)}: {quantity}{symbol}{note}";
            }
        }


        public Ingredient(string name, string desc, MeasurementUnitCategory measurementUnitCategory, MeasurementUnit measurementUnit, string note) : base(name, desc)
        {
            MeasurementUnitCategory = measurementUnitCategory;
            MeasurementUnit = measurementUnit;
            Note = note;
        }

        public Ingredient(string name, MeasurementUnitCategory measurementUnitCategory, MeasurementUnit measurementUnit, string note) : this(name, string.Empty, measurementUnitCategory, measurementUnit, note) { }

        public Ingredient(string name, MeasurementUnitCategory measurementUnitCategory, MeasurementUnit measurementUnit) : this(name, string.Empty, measurementUnitCategory, measurementUnit, string.Empty) { }

        public Ingredient() { }
    }
}
