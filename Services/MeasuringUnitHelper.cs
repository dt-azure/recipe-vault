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
    public class MeasuringUnitHelper
    {
        public string GetUnitSymbol(MeasuringUnit unit, double quantity)
        {
            switch (unit)
            {
                case MeasuringUnit.None:
                    return string.Empty;
                case MeasuringUnit.Teaspoon:
                    if (quantity > 1)
                    {
                        return "tbsps";
                    }
                    return "tsp";
                case MeasuringUnit.Tablespoon:
                    if (quantity > 1)
                    {
                        return "tbsps";
                    }
                    return "tbsp";
                case MeasuringUnit.Cup:
                    if (quantity > 1)
                    {
                        return "cups";
                    }
                    return "cup";
                case MeasuringUnit.Milliliter:
                    return "ml";
                case MeasuringUnit.Liter:
                    return "l";
                case MeasuringUnit.FluidOunce:
                    return "fl oz";
                case MeasuringUnit.Gram:
                    return "g";
                case MeasuringUnit.Kilogram:
                    return "kg";
                case MeasuringUnit.Ounce:
                    return "oz";
                case MeasuringUnit.Pound:
                    if (quantity > 1)
                    {
                        return "lbs";
                    }
                    return "lb";
                case MeasuringUnit.Inch:
                    return "in";
                case MeasuringUnit.Centimeter:
                    return "cm";
                case MeasuringUnit.Pinch:
                    if (quantity > 1)
                    {
                        return "pinch";
                    }
                    return "pinches";
                case MeasuringUnit.Dash:
                    if (quantity > 1)
                    {
                        return "dash";
                    }
                    return "dashes";
                case MeasuringUnit.ToTaste:
                    return "to taste";
                case MeasuringUnit.Pint:
                    return "pt";
                case MeasuringUnit.Quart:
                    return "qt";
                case MeasuringUnit.Gallon:
                    return "gal";
                default:
                    return string.Empty;
            }
        }

        public Color GetMeasurementGroupColor(MeasuringUnitCategory category)
        {
            int argb;
            switch (category)
            {
                case MeasuringUnitCategory.Weight:
                    return Color.FromArgb("#E1AA36");
                case MeasuringUnitCategory.Volume:
                    return Color.FromArgb("#B2B0E8");
                case MeasuringUnitCategory.Imprecise:
                    return Color.FromArgb("#A2AF9B");
                case MeasuringUnitCategory.Count:
                    return Color.FromArgb("#93DA97");
                default:
                    return Color.FromArgb("#7D8D86");
            }
        }
    }
}
