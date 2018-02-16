using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] rectanglesAndChecks = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int nRectangles = rectanglesAndChecks[0];
        int checks = rectanglesAndChecks[1];

        Dictionary<string, Rectangle> rectanglesDict = new Dictionary<string, Rectangle>();

        for (int i = 0; i < nRectangles; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string id = tokens[0];
            double width = double.Parse(tokens[1]);
            double height = double.Parse(tokens[2]);
            double leftTopX = double.Parse(tokens[3]);
            double leftTopY = double.Parse(tokens[4]);

            Rectangle rectangle = new Rectangle(id, width, height, leftTopX, leftTopY);

            if (!rectanglesDict.ContainsKey(id))
            {
                rectanglesDict.Add(id, rectangle);
            }
            else
            {
                rectanglesDict[id] = rectangle;
            }
        }

        for (int i = 0; i < checks; i++)
        {
            string[] rectangleIDs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (rectangleIDs.Length >= 2)
            {
                string first = rectangleIDs[0];
                string second = rectangleIDs[1];
                if (rectanglesDict.ContainsKey(first) && rectanglesDict.ContainsKey(second))
                {
                    Rectangle firstRectangle = rectanglesDict[first];
                    Rectangle secondRectangle = rectanglesDict[second];
                    Console.WriteLine(firstRectangle.Intersects(secondRectangle) ? "true" : "false");
                }
            }
        }
    }
}
