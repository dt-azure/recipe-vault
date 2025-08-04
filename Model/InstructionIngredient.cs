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
    public class InstructionIngredient : Ingredient
    {
        public override string FormattedIngredientInfo
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
                MeasurementUnitHelper helper = new MeasurementUnitHelper();
                return helper.GetMeasurementGroupColor(MeasurementUnitCategory);
            }
        }

        public InstructionIngredient(string name, MeasurementUnitCategory category, MeasurementUnit measurementUnit, double quantity) : base(name, category, measurementUnit)
        {
            Quantity = quantity;
        }

        public InstructionIngredient(Ingredient ingredient, double quantity) : this(ingredient.Name, ingredient.MeasurementUnitCategory, ingredient.MeasurementUnit, quantity)
        {
        }

        public InstructionIngredient(Ingredient ingredient) : this(ingredient, ingredient.Quantity)
        {
        }

        public InstructionIngredient() { }
    }
}
