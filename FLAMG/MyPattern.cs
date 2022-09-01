// Include namespace system
using System;
// Csharp Program
// Program For Sine-Wave Pattern Set-B
public class MyPattern
{
    // include space
    public void space(int size)
    {
        for (int i = 0; i < size; ++i)
        {
            Console.Write(" ");
        }
    }
    public void showPattern(int hight, int width)
    {
        if (hight <= 2)
        {
            return;
        }
        // Display given Height Width
        Console.Write("Height : " + hight + " Width : " + width + "\n\n");
        //First layer of sine wave
        for (int j = 0; j <= width; ++j)
        {
            if (j == 0)
            {
                Console.Write(" * *");
            }
            else
            {
                this.space(9);
                Console.Write("* *");
            }
        }
        Console.Write("\n");
        // Intermediate layer of sine wave
        for (int i = 0; i < hight - 2; ++i)
        {
            for (int j = 0; j < width; ++j)
            {
                this.space(5);
                Console.Write("*");
                this.space(5);
                Console.Write("*");
            }
            Console.Write("\n");
        }
        //Last layer of sine wave
        for (int j = 0; j < width; ++j)
        {
            if (j == 0)
            {
                this.space(7);
            }
            else
            {
                this.space(9);
            }
            Console.Write("* *");
        }
        Console.Write("\n\n");
    }
    public static void Main(String[] args)
    {
        MyPattern obj = new MyPattern();
        //Test Case
        obj.showPattern(6, 1);
        obj.showPattern(7, 3);
        obj.showPattern(3, 4);
    }
}
