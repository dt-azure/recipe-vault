using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVault.Model;
using System.Drawing;
using System.Diagnostics;

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

        public ImageSource? ConvertBase64ToImg(string base64)
        {
            //  Remove URI prefix if exists
            if (base64.Contains(","))
            {
                base64 = base64.Substring(base64.IndexOf(",") + 1);
            }

            try
            {
                byte[] bytes = Convert.FromBase64String(base64);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return ImageSource.FromStream(() => ms);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Image conversion error: {ex.Message}");
                return null;
            }
        }

        public List<ImageSource> GetRecipeImages(List<RecipeImage> images)
        {
            List<ImageSource> imageList = new List<ImageSource>();

            foreach (RecipeImage image in images)
            {
                ImageSource newImage = ConvertBase64ToImg(image.Source);
                imageList.Add(newImage);
            }

            return imageList;
        }
    }
}
