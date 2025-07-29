using RecipeVault.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Services
{
    public class MeasuringUnitHelper
    {
        public string GetUnitSymbol(MeasuringUnit unit, double quantiy)
        {
            switch (unit)
            {
                case MeasuringUnit.None:
                    return string.Empty;
                case MeasuringUnit.Teaspoon:
                    return "tsp";
                case MeasuringUnit.Tablespoon:
                    return "tbsp";
                case MeasuringUnit.Cup:
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
                    return "lb";
                case MeasuringUnit.Inch:
                    return "in";
                case MeasuringUnit.Centimeter:
                    return "cm";
                case MeasuringUnit.Pinch:
                    if (quantiy > 1)
                    {
                        return "pinch";
                    }
                    return "pinches";
                case MeasuringUnit.Dash:
                    if (quantiy > 1)
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
    }
}
