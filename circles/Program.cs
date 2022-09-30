// Grant Shirley
class Director 
{
    static void Main(string[] args)
    {
        System.Console.Write("How many Circles do you want? ");
        string val = System.Console.ReadLine();
        int num = Convert.ToInt32(val);
        Circles[] circleArray = new Circles[num];

        for (int i = 0; i < num; i++) 
        {
            Circles circles = new Circles();
            circleArray[i] = circles;
        }

        for (int i = 0; i < num; i++)
        {
            System.Console.WriteLine("Circle " + (i + 1) + ":");
            circleArray[i].displayCircle();
        }

        if (circleArray.Length > 1)
        {
            System.Console.Write("Would you like to see how many circles you can fit in another circle (Y, N)? ");
            string choice = System.Console.ReadLine();
            while (choice == "Y")
            {
                System.Console.Write("\nWhich Circle would you like to look at? ");
                string val1 = System.Console.ReadLine();
                int circle1 = Convert.ToInt32(val1) - 1;

                System.Console.Write("Which Circle would you like to look at next? ");
                string val2 = System.Console.ReadLine();
                int circle2 = Convert.ToInt32(val2) - 1;

                System.Console.WriteLine("\nArea:");
                Circles.howManyInside(circleArray[circle1].getArea(), circleArray[circle2].getArea());

                System.Console.WriteLine("\nVolume:");
                Circles.howManyInside(circleArray[circle1].getVolume(), circleArray[circle2].getVolume());
    
                System.Console.Write("\nWould you like to do it again with different circles (Y, N)? ");
                choice = System.Console.ReadLine();
            }
        }
    }
}

class Circles
{
    private double radius;
    private double area;
     private double volume;

    public Circles()
    {
        System.Console.Write("Enter the Circle's radius: ");
        string val = System.Console.ReadLine();
        radius = Convert.ToDouble(val);
        area = findArea();
        volume = findVolume();
    }
    public void setRadius(double new_radius)
    {
        radius = new_radius;
    }
    public double findArea()
    {
        area = Math.Pow(radius, 2) * Math.PI;
        return area;
    }
    public double findVolume()
    {
        return Math.PI * Math.Pow(radius, 3) * 4/3;
    }
    public double getArea()
    {
        return area;
    }
    public double getVolume()
    {
        return volume;
    }
    public void displayCircle()
    {
        System.Console.WriteLine("Radius: " + radius);
        System.Console.WriteLine("Area: " + area);
        System.Console.WriteLine("Volume: " + volume + "\n");
    }

    public static void howManyInside(double area1, double area2)
    {
        int howMany = 0;
        if (area1 > area2)
        {
            howMany = Convert.ToInt32(Math.Floor(area1 / area2));
            System.Console.WriteLine("You can fit circle2 inside circle1 " + howMany + " time(s).");
        }
        else if (area2 > area1)
        {
            howMany = Convert.ToInt32(Math.Floor(area2 / area1));
            System.Console.WriteLine("You can fit circle1 inside circle2 " + howMany + " time(s).");
        }
        else
        {
            // This should only be entered if both areas are the smae value.
            howMany = 1;
            System.Console.WriteLine("You can fit circle1 inside circle2 " + howMany + " time.");
        }


    }

    // I should add one for Volume. Aka a howManyInsideVolume.
    // I might be able to do this with my old function.
}

/*
 Resources:
- https://www.w3schools.com/cs/index.php - W3School guide to C#
- https://visualstudio.microsoft.com/vs/community/ - VS Code community download
 
 */