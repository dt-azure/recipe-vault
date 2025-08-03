using RecipeVault.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Color = Microsoft.Maui.Graphics.Color;

namespace RecipeVault.Model
{
    public class InstructionIngredient
    {
        public string Name { get; set; }
        public MeasuringUnitCategory MeasuringUnitCategory { get; set; }
        public MeasuringUnit MeasuringUnit { get; set; }
        public double Quantity { get; set; }

        public string Symbol
        {
            get
            {
                MeasuringUnitHelper helper = new MeasuringUnitHelper();
                return helper.GetUnitSymbol(MeasuringUnit, Quantity);
            }
        }

        public string FormattedIngredientInfo
        {
            get
            {
                string symbol = Symbol == "" ? Symbol : $" {Symbol}";
                string quantity = Quantity == 0 ? "to taste" : $"{Quantity}";

                return $"{System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Name)}: {Quantity}{symbol}";
            }
        }

        public Color MeasurementUnitColor
        {
            get
            {
                MeasuringUnitHelper helper = new MeasuringUnitHelper();
                return helper.GetMeasurementGroupColor(MeasuringUnitCategory);
            }
        }

        public InstructionIngredient(string name, MeasuringUnitCategory category, MeasuringUnit measuringUnit, double quantity)
        {
            Name = name;
            MeasuringUnitCategory = category;
            MeasuringUnit = measuringUnit;
            Quantity = quantity;
        }

        public InstructionIngredient(Ingredient ingredient, double quantity)
        {
            Name = ingredient.Name;
            MeasuringUnitCategory = ingredient.MeasuringUnitCategory;
            MeasuringUnit = ingredient.MeasuringUnit;
            Quantity = quantity;
        }

        public InstructionIngredient(Ingredient ingredient) : this(ingredient, ingredient.Quantity)
        {
        }

        public InstructionIngredient() { }
    }
}
