using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVault.Model;

namespace RecipeVault.Services
{
    public class DataService
    {
        public string FormatRecipeTime(int time)
        {
            TimeSpan ts = TimeSpan.FromSeconds(time);
            int hour = (int) ts.TotalHours;
            int minute = (int) ts.TotalMinutes - (hour * 60);
            string res = "";

            if (hour > 0)
            {
                res += $"{hour}h ";
            }

            if (minute > 0)
            {
                res += $"{minute}m";
            }

            return res;
        }
    }
}
