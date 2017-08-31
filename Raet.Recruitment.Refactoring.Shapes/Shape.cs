using System;
using System.Collections.Generic;

namespace Refactoring.Shapes
{
    public class Shape
    {
        public const int SQUARE = 1;
        public const int CIRCLE = 2;
        public const int TRIANGLE = 3;

        private readonly double width;
        public int type = -1;

        public Shape(int type, double width)
        {
            this.type = type;
            this.width = width;
        }


        public static String Print(List<Shape> shapes)
        {
            String returnString = "";
            String squareString = "";
            String circlesString = "";
            String trianglesString = "";

            if (shapes.Count == 0)
            {
                returnString = "Empty list of shapes!";
            }
            else
            {
                int numberSquares = 0;
                int numberCircles = 0;
                int numberTriangles = 0;

                double areaSquares = 0;
                double areaCircles = 0;
                double areaTriangles = 0;

                double perimeterSquares = 0;
                double perimeterCircles = 0;
                double perimeterTriangles = 0;

                // Compute calculations
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].type == SQUARE)
                    {
                        numberSquares++;
                        areaSquares += shapes[i].getArea();
                        perimeterSquares += shapes[i].getPerimeter();
                    }
                    if (shapes[i].type == CIRCLE)
                    {
                        numberCircles++;
                        areaCircles += shapes[i].getArea();
                        perimeterCircles += shapes[i].getPerimeter();
                    }
                    if (shapes[i].type == TRIANGLE)
                    {
                        numberTriangles++;
                        areaTriangles += shapes[i].getArea();
                        perimeterTriangles += shapes[i].getPerimeter();
                    }
                }

                // Get texts to print.
                if (numberSquares > 0)
                {
                    squareString = "Squares: " + numberSquares + ", Area: " + areaSquares.ToString("#.##") + ", Perimeter: " + perimeterSquares.ToString("#.##") + ".";
                }

                if (numberCircles > 0)
                {
                    circlesString = "Circles: " + numberCircles + ", Area: " + areaCircles.ToString("#.##") + ", Perimeter: " + perimeterCircles.ToString("#.##") + ".";
                }

                if (numberTriangles > 0)
                {
                    trianglesString = "Triangles: " + numberTriangles + ", Area: " + areaTriangles.ToString("#.##") + ", Perimeter: " + perimeterTriangles.ToString("#.##") + ".";
                }

                //Order the printed results
                if (numberSquares >= numberCircles && numberSquares >= numberTriangles)
                {
                    if (numberCircles >= numberTriangles)
                    {
                        returnString = squareString + "\n" + circlesString + "\n" + trianglesString;
                    }
                    else
                    {
                        returnString = squareString + "\n" + trianglesString + "\n" + circlesString;
                    }
                }
                else if (numberTriangles >= numberCircles && numberTriangles >= numberSquares)
                {
                    if (numberCircles >= numberSquares)
                    {
                        returnString = trianglesString + "\n" + circlesString + "\n" + squareString;
                    }
                    else
                    {
                        returnString = trianglesString + "\n" + squareString + "\n" + circlesString;
                    }
                }
                else
                {
                    if (numberTriangles >= numberSquares)
                    {
                        returnString = circlesString + "\n" + trianglesString + "\n" + squareString;
                    }
                    else
                    {
                        returnString = circlesString + "\n" + squareString + "\n" + trianglesString;
                    }
                }
            }

            return returnString.Trim();
        }

        public double getWidth()
        {
            return width;
        }

        public double getArea()
        {
            switch (type)
            {
                case SQUARE:
                    return width * width;
                case CIRCLE:
                    return Math.PI * (width / 2) * (width / 2);
                case TRIANGLE:
                    return (Math.Sqrt(3) / 4) * width * width;
            }
            throw new SystemException("Can`t compute area of unknown shape");
        }

        public double getPerimeter()
        {
            switch (type)
            {
                case SQUARE:
                    return 4 * width;
                case CIRCLE:
                    return Math.PI * width;
                case TRIANGLE:
                    return 3 * width;
            }
            throw new SystemException("Can`t compute area of unknown shape");
        }
    }
}
