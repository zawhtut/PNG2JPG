using System;
using System.IO;
using System.Threading;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace PNG2JPG5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check for command line arguments
            if (args.Length == 0 || args[0] == "-h" || args[0] == "--help")
            {
                ShowHelp();
                return;
            }

            // Custom large Braille Patterns for spinner
            //string[] spinner = new string[] { "⡿", "⣟", "⣯", "⣷", "⣾", "⣽", "⣻", "⢿" };
            char[] spinner = new char[] { '⡿', '⣟', '⣯', '⣷', '⣾', '⣽', '⣻', '⢿' };

            int spinIndex = 0;

            // Folder path from user
            var folder = args[0];
            bool deleteOriginals = args.Length > 1 && args[1] == "--delete";
            int count = 0;

            Console.WriteLine("Processing files in folder: " + folder);

            foreach (string file in Directory.GetFiles(folder))
            {
                string ext = Path.GetExtension(file).ToLower();
                if (ext == ".png")
                {
                    try
                    {
                        string name = Path.GetFileNameWithoutExtension(file);
                        string? path = Path.GetDirectoryName(file);

                        using (Image image = Image.Load(file))
                        {
                            image.Save(path + @"/" + name + ".jpg", new JpegEncoder());
                        }

                        count++;

                        // Update spinner.
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write($"Processing {spinner[spinIndex]}  {count} file(s) converted.");

                        // Move to next spinner index
                        spinIndex = (spinIndex + 1) % spinner.Length;

                        if (deleteOriginals)
                        {
                            File.Delete(file);
                        }
                    }
                    catch (SixLabors.ImageSharp.UnknownImageFormatException)
                    {
                        Console.WriteLine($"The file {file} is not a recognized image format.");
                    }
                    catch (IOException ioException)
                    {
                        Console.WriteLine($"An I/O error occurred while processing {file}: {ioException.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unknown error occurred while processing {file}: {ex.Message}");
                    }
                }
            }

            // Check if any files were processed
            if (count == 0)
            {
                Console.WriteLine("No PNG files found.");
            }
            else
            {
                Console.WriteLine($"\nTotal {count} file(s) converted.");
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("Usage: PNG2JPG5 <folder_path> [--delete]");
            Console.WriteLine();
            Console.WriteLine("Convert all PNG files in the specified folder to JPG format.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --delete  Delete original PNG files after conversion.");
            Console.WriteLine("  -h, --help  Show this help message and exit.");
        }
    }
}