using RecipeVault.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class Ingredient : AppObject
    {
        public MeasuringUnitCategory MeasuringUnitCategory { get; set; }
        public MeasuringUnit MeasuringUnit { get; set; }
        public double Quantity { get; set; }
        public string Note { get; set; }
         public string Symbol
        {
            get
            {
                MeasuringUnitHelper helper = new MeasuringUnitHelper();
                return helper.GetUnitSymbol(MeasuringUnit, Quantity);
            }
        }


        public Ingredient(string name, string desc, MeasuringUnitCategory measuringUnitCategory, MeasuringUnit measuringUnit, string note) : base(name, desc)
        {
            MeasuringUnitCategory = measuringUnitCategory;
            MeasuringUnit = measuringUnit;
            Note = note;
        }

        public Ingredient(string name, MeasuringUnitCategory measuringUnitCategory, MeasuringUnit measuringUnit, string note) : this(name, string.Empty, measuringUnitCategory, measuringUnit, note) { }

        public Ingredient(string name, MeasuringUnitCategory measuringUnitCategory, MeasuringUnit measuringUnit) : this(name, string.Empty, measuringUnitCategory, measuringUnit, string.Empty) { }

        public Ingredient() { }
    }
}
