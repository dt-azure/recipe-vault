using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVault.Model
{
    public enum Difficulty
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public enum MeasuringUnitCategory
    {
        Volume,
        Weight,
        Temperature,
        Count,
        Imprecise  // For things such as pinch, dash, to taste,...
        //Other
    }

    public enum MeasuringUnit
    {
        None,
        Teaspoon,
        Tablespoon,
        Cup,
        Milliliter,
        Liter,
        FluidOunce,
        Gram,
        Kilogram,
        Ounce,
        Pound,
        Inch,
        Centimeter,
        Pinch,
        Dash,
        ToTaste,
        Pint,
        Quart,
        Gallon,
        Clove
    }

    public enum FoodType
    {
        Appetizer,
        Soup,
        Salad,
        MainCourse,
        Dessert,
        HorsDoeuvres,
        Amusebouche,
        CheeseCourse,
        Mignardises
    }

    public enum CuisineType
    {
        Italian,
        Chinese,
        Indian,
        Japanese,
        Mexican,
        Thai,
        French,
        Korean,
        Vietnamese,
        Greek,
        Mediterranean,
        Spanish,
        Turkish,
        Lebanese,
        MiddleEastern,
        None
    }

    public enum DrinkType
    {
        Juice,
        Tea,
        Coffee,
        Smoothie,
        Cocktail,
        Mocktail,
        Other
    }

    public enum SpiceLevel
    {
        None,
        Mild,
        Moderate,
        VerySpicy
    }
}
