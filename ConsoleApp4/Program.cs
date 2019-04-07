using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApp4
{
    class Program
    {
        static Program program;

        readonly String path = "E:\\Bilder\\test2.png";
        String date;
        Bitmap img;
        
        Program()
        {
            date = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
            img = loadImage(path);

            Console.CursorVisible = false;

            Console.WriteLine("Path: " + path);
            
            changeImage(img);
        }

        void changeImage(Bitmap img)
        {
            Color pixel;
            Color newColor;
            Random rand = new Random();

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++) {
                    Console.Clear();

                    if (i%3 == 0 && j%3 == 0)
                    {
                        if (i != (img.Width - 1) && i != (img.Width - 2) && j != (img.Height - 1) && j != (img.Height - 2))
                        {
                            pixel = img.GetPixel(i, j); // color of pixel
                            newColor = Color.FromArgb(pixel.A, pixel.R ,pixel.G ,pixel.B); // change color stuff here                

                            img.SetPixel(i, j, newColor);
                            img.SetPixel(i + 1, j, newColor);
                            img.SetPixel(i + 2, j, newColor);

                            img.SetPixel(i, j + 1, newColor);
                            img.SetPixel(i + 1, j + 1, newColor);
                            img.SetPixel(i + 2, j + 1, newColor);

                            img.SetPixel(i, j + 2, newColor);
                            img.SetPixel(i + 1, j + 2, newColor);
                            img.SetPixel(i + 2, j + 2, newColor);
                        }

                    }

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("path: " + path);
                    Console.WriteLine("width: " + (i + 1) + " / " + img.Width + " height: " + (j + 1) + " / " + img.Height);
                }
            }

            saveImage(img, date);
        }

        Bitmap loadImage(String path)
        {
            try
            {
                return new Bitmap(path);
            }
            catch(Exception e)
            {
                Console.Error.Write(e);
                Console.ReadKey();

                return null;
            }
        }

        void saveImage(Bitmap img, String time)
        {
            String name = "image" + time + ".jpeg";

            try
            {
                Console.SetCursorPosition(0, 3);
                Console.Write("Saving Image as: " + name);
                img.Save(name);
            }
            catch(Exception e)
            {
                Console.Error.Write(e);
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            program = new Program();

            Console.ReadKey();
        }
    }
}
