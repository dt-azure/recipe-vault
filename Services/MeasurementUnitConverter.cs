using RecipeVault.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Services
{
    class MeasurementUnitConverter
    {
        //  Canonical unit is the default unit
        //  Gram for weight, mililiter for volume
        public double Convert(double val, MeasurementUnitCategory category, MeasurementUnit sourceUnit, MeasurementUnit targetUnit)
        {
            double canonicalVal;

            if (category == MeasurementUnitCategory.Weight)
            {
                canonicalVal = ConvertToWeightCanonical(val, sourceUnit);
                return ConvertFromWeightCanonical(canonicalVal, targetUnit);
            }
            else if (category == MeasurementUnitCategory.Volume)
            {
                canonicalVal = ConvertToVolumeCanonical(val, sourceUnit);
                return ConvertFromVolumeCanonical(canonicalVal, targetUnit);
            }
            else
            {
                throw new InvalidDataException();
            }
        }

        private double ConvertToWeightCanonical(double val, MeasurementUnit sourceUnit)
        {
            switch (sourceUnit)
            {
                case MeasurementUnit.Gram:
                    return val;
                case MeasurementUnit.Kilogram:
                    return val * 1000;
                case MeasurementUnit.Ounce:
                    return val * 28.34895;
                case MeasurementUnit.Pound:
                    return val * 453.592;
                //  These calculations are approximations
                case MeasurementUnit.Teaspoon:
                    return val * 5;
                case MeasurementUnit.Tablespoon:
                    return val * 15;
                case MeasurementUnit.Cup:
                    return val * 240;
                default:
                    throw new InvalidDataException();
            }
        }

        private double ConvertFromWeightCanonical(double val, MeasurementUnit targetUnit)
        {
            switch (targetUnit)
            {
                case MeasurementUnit.Gram:
                    return val;
                case MeasurementUnit.Kilogram:
                    return val / 1000;
                case MeasurementUnit.Ounce:
                    return val / 28.34895;
                case MeasurementUnit.Pound:
                    return val / 453.592;
                //  These calculations are approximations
                case MeasurementUnit.Teaspoon:
                    return val / 5;
                case MeasurementUnit.Tablespoon:
                    return val / 15;
                case MeasurementUnit.Cup:
                    return val / 240;
                default:
                    throw new InvalidDataException();
            }
        }

        private double ConvertToVolumeCanonical(double val, MeasurementUnit sourceUnit)
        {
            switch (sourceUnit)
            {
                case MeasurementUnit.Milliliter:
                    return val;
                case MeasurementUnit.Liter:
                    return val * 1000;
                case MeasurementUnit.FluidOunce:
                    return val * 29.5735;
                case MeasurementUnit.Teaspoon:
                    return val * 4.92892;
                case MeasurementUnit.Tablespoon:
                    return val * 14.7868;
                case MeasurementUnit.Cup:
                    return val * 236.588;
                case MeasurementUnit.Pint:
                    return val * 473.176;
                case MeasurementUnit.Quart:
                    return val * 946.353;
                case MeasurementUnit.Gallon:
                    return val * 3785.41;
                default:
                    throw new InvalidDataException();
            }
        }

        private double ConvertFromVolumeCanonical(double val, MeasurementUnit targetUnit)
        {
            switch (targetUnit)
            {
                case MeasurementUnit.Milliliter:
                    return val;
                case MeasurementUnit.Liter:
                    return val / 1000;
                case MeasurementUnit.FluidOunce:
                    return val / 29.5735;
                case MeasurementUnit.Teaspoon:
                    return val / 4.92892;
                case MeasurementUnit.Tablespoon:
                    return val / 14.7868;
                case MeasurementUnit.Cup:
                    return val / 236.588;
                case MeasurementUnit.Pint:
                    return val / 473.176;
                case MeasurementUnit.Quart:
                    return val / 946.353;
                case MeasurementUnit.Gallon:
                    return val / 3785.41;
                default:
                    throw new InvalidDataException();
            }
        }
    }
}
