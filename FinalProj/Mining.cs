using Raylib_cs;
using System.Numerics;
using System;



public class Mining
{
    public int time = 0;

    public int axePosx = 400;
    public int axePosy = 300;
    public void StartMining()
    {
        time = 120;
        axePosx = 300;
        axePosy = 200;
    }
    public Texture2D pick;

    public void Min()
    {
        if (time > 0)
        {
            Raylib.DrawTexture(pick, axePosx, axePosy, Color.WHITE);
            time -= 1;
            Console.WriteLine(time);
            if (time == 1 || time == 20 || time == 30 || time == 40 || time == 50 || time == 60 || time == 70 || time == 80 || time == 90 || time == 100 || time == 110 || time == 119)
            {
                axePosx += 3;
                axePosy += 18;
            }
        }
    }
}
