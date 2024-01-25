using OpenCvSharp;
using System;
using System.Text;
using System.Threading.Tasks;

public class AsciiArtCamApp
{
    private VideoCapture? capture;
    private const string chars = " .,-:;=+*#&$";

    public Task Run(int frameRate = 60)
    {
        capture = new VideoCapture(0);

        if (!capture.IsOpened())
        {
            Console.WriteLine("Error opening webcam!");
            return Task.CompletedTask;
        }

        int frameWidth = 280;
        int frameHeight = 70;

        // Calculate resize ratio for clarity (experiment with different values)
        double resizeRatio = Math.Min(0.5, Math.Sqrt(frameWidth * frameHeight / (80 * 60)));

        while (true)
        {
            Mat frame = new Mat();
            capture.Read(frame);

            if (frame.Empty())
            {
                break;
            }

            // Resize for efficiency and clarity
            frame = frame.Resize(new Size((int)(frameWidth * resizeRatio), (int)(frameHeight * resizeRatio)));

            string asciiArt = ImageToAscii(frame);
            Console.Clear();
            Console.WriteLine(asciiArt);
            Task.Delay(1000 / frameRate).Wait();
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                break;
            }
        }

        capture.Release();
        return Task.CompletedTask;
    }

    string ImageToAscii(Mat frame)
    {
        StringBuilder ascii = new StringBuilder();

        for (int y = 0; y < frame.Height; y++)
        {
            for (int x = 0; x < frame.Width; x++)
            {
                byte pixelValue = frame.Get<byte>(y, x);
                char asciiChar = GetAsciiChar(pixelValue);
                ascii.Append(asciiChar);
            }
            ascii.AppendLine();
        }

        return ascii.ToString();
    }

    char GetAsciiChar(byte pixelValue)
    {
        int index = (int)Math.Floor(pixelValue / 255.0 * chars.Length);
        return chars[Math.Clamp(index, 0, chars.Length - 1)];
    }

    public static void Main(string[] args)
    {
        var app = new AsciiArtCamApp();
        app.Run().Wait();
    }
}
