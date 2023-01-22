using System.Drawing;
using System.Linq;

namespace AIColorPicker
{
    public static class ColorPicker
    {
        public static void Main(string[] args){

            Console.WriteLine("Image Path: ");
            string imagePath = Console.ReadLine();

            try
            {
                Bitmap image = new Bitmap(imagePath);

                IDictionary<Color, int> usedColors = new Dictionary<Color, int>();

                for (int wp = 0; wp < image.Width; wp++)
                {
                    for (int hp = 0; hp < image.Width; hp++)
                    {
                        if(usedColors.ContainsKey(image.GetPixel(wp, hp)))
                        {
                            usedColors[usedColors.FirstOrDefault(x => x.Key == (Color)image.GetPixel(wp, hp)).Key] += 1;
                        }
                        else
                        {
                            usedColors.Add(
                                image.GetPixel(wp, hp),
                                1
                            );
                        }
                    }
                }

                List<Color> top5 = new List<Color>();

                top5 = (from entry in usedColors orderby entry.Value descending select entry.Key).Take(5).ToList();

                foreach (Color i in top5)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong!");
            }
            // For app to not close
            Console.ReadKey();
        }
    }
}