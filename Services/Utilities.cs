using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVault.Model;
using System.Drawing;
using System.Diagnostics;
using Color = Microsoft.Maui.Graphics.Color;

namespace RecipeVault.Services
{
    public class Utilities
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
            if (string.IsNullOrWhiteSpace(base64))
            {
                return null;
            }

            try
            {
                byte[] bytes = Convert.FromBase64String(base64);

                return ImageSource.FromStream(() => new MemoryStream(bytes));

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

        public List<string> ConvertEnumToStringList<T>() where T : Enum
        {
            return Enum.GetNames(typeof(T)).ToList();
        }

        public Color GetTagColor(TagColor color)
        {
            switch (color)
            {
                case TagColor.Orange:
                    return Color.FromArgb("#F08B51");
                case TagColor.Red:
                    return Color.FromArgb("#B9375D");
                case TagColor.Green:
                    return Color.FromArgb("#8ABB6C");
                case TagColor.Blue:
                    return Color.FromArgb("#00809D");
                case TagColor.Purple:
                    return Color.FromArgb("#640D5F");
                case TagColor.Grey:
                    return Color.FromArgb("#7A7A73");
                case TagColor.Brown:
                    return Color.FromArgb("#D3AF37");
                case TagColor.Yellow:
                    return Color.FromArgb("#FFD700");
                default:
                    return Color.FromArgb("#7A7A73");
            }
        }
    }
}
