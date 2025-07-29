using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public class InstructionIngredient
    {
        public string Name { get; set; }
        public MeasuringUnit MeasuringUnit { get; }
        public double Quantity { get; set; }

        public InstructionIngredient(string name, MeasuringUnit measuringUnit, double quantity)
        {
            Name = name;
            MeasuringUnit = measuringUnit;
            Quantity = quantity;
        }

        public InstructionIngredient() { }
    }
}
