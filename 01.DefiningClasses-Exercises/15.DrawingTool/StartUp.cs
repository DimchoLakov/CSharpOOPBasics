using System;

class StartUp
{
    static void Main()
    {
        string figure = Console.ReadLine();

        if (figure == "Square")
        {
            int n = int.Parse(Console.ReadLine());
            DrawingTool drawingTool = new DrawingTool(new Square(n));
            drawingTool.Sqaure.Draw();
        }
        else if (figure == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            DrawingTool drawingTool = new DrawingTool(new Rectangle(width, height));
            drawingTool.Rectangle.Draw();
        }
    }
}