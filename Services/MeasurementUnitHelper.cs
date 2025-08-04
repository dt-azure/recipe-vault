using Microsoft.Maui.Platform;
using RecipeVault.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace RecipeVault.Services
{
    public class MeasurementUnitHelper
    {
        public string GetUnitSymbol(MeasurementUnit unit, double quantity)
        {
            switch (unit)
            {
                case MeasurementUnit.None:
                    return string.Empty;
                case MeasurementUnit.Teaspoon:
                    if (quantity > 1)
                    {
                        return "tbsps";
                    }
                    return "tsp";
                case MeasurementUnit.Tablespoon:
                    if (quantity > 1)
                    {
                        return "tbsps";
                    }
                    return "tbsp";
                case MeasurementUnit.Cup:
                    if (quantity > 1)
                    {
                        return "cups";
                    }
                    return "cup";
                case MeasurementUnit.Milliliter:
                    return "ml";
                case MeasurementUnit.Liter:
                    return "l";
                case MeasurementUnit.FluidOunce:
                    return "fl oz";
                case MeasurementUnit.Gram:
                    return "g";
                case MeasurementUnit.Kilogram:
                    return "kg";
                case MeasurementUnit.Ounce:
                    return "oz";
                case MeasurementUnit.Pound:
                    if (quantity > 1)
                    {
                        return "lbs";
                    }
                    return "lb";
                case MeasurementUnit.Inch:
                    return "in";
                case MeasurementUnit.Centimeter:
                    return "cm";
                case MeasurementUnit.Pinch:
                    if (quantity > 1)
                    {
                        return "pinch";
                    }
                    return "pinches";
                case MeasurementUnit.Dash:
                    if (quantity > 1)
                    {
                        return "dash";
                    }
                    return "dashes";
                case MeasurementUnit.ToTaste:
                    return "to taste";
                case MeasurementUnit.Pint:
                    return "pt";
                case MeasurementUnit.Quart:
                    return "qt";
                case MeasurementUnit.Gallon:
                    return "gal";
                default:
                    return string.Empty;
            }
        }

        public Color GetMeasurementGroupColor(MeasurementUnitCategory category)
        {
            int argb;
            switch (category)
            {
                case MeasurementUnitCategory.Weight:
                    return Color.FromArgb("#E1AA36");
                case MeasurementUnitCategory.Volume:
                    return Color.FromArgb("#B2B0E8");
                case MeasurementUnitCategory.Imprecise:
                    return Color.FromArgb("#A2AF9B");
                case MeasurementUnitCategory.Count:
                    return Color.FromArgb("#93DA97");
                default:
                    return Color.FromArgb("#7D8D86");
            }
        }

        public MeasurementUnit GetUnitEnum(string unit)
        {
            unit = unit.ToLower();
            switch (unit)
            {
                case "teaspoon":
                    return MeasurementUnit.Teaspoon;
                case "tablespoon":
                    return MeasurementUnit.Tablespoon;
                case "cup":
                    return MeasurementUnit.Cup;
                case "milliliter":
                    return MeasurementUnit.Milliliter;
                case "liter":
                    return MeasurementUnit.Liter;
                case "fluidounce":
                    return MeasurementUnit.FluidOunce;
                case "gram":
                    return MeasurementUnit.Gram;
                case "kilogram":
                    return MeasurementUnit.Kilogram;
                case "ounce":
                    return MeasurementUnit.Ounce;
                case "pound":
                    return MeasurementUnit.Pound;
                case "pinch":
                    return MeasurementUnit.Pinch;
                case "pint":
                    return MeasurementUnit.Pint;
                case "quart":
                    return MeasurementUnit.Quart;
                case "gallon":
                    return MeasurementUnit.Gallon;
                default:
                    throw new InvalidDataException();
            }
        }
    }
}
