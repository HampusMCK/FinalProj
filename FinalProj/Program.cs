global using Raylib_cs;
using System.Numerics;

string playerPos = "out";
string CuIt = "hand";
int mon = 0;
int digUp;
int power = 1;
int lastBought = 0;
bool toexp = false;

Raylib.InitWindow(800, 800, "Miners");
Raylib.SetTargetFPS(60);
Random gen = new Random();

Mining min = new Mining();
Shitems store = new Shitems();

    min.pick = store.shims[0].wep;
while (!Raylib.WindowShouldClose())
{
    /*
    Namn givning



    Mining animering (3 frames)

    Walking animering (3 frames repeat)



    */
    Raylib.BeginDrawing();
    Raylib.DrawText($"Money: ${mon}", 50, 50, 24, Color.GREEN);
    if (playerPos == "out")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText("Press 'M' to enter the mine!", 600, 50, 12, Color.BLACK);
        Raylib.DrawText("Press 'S' to enter the shop!", 600, 75, 12, Color.BLACK);
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_M)) { playerPos = "mine"; }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_S)) { playerPos = "shop"; }
        toexp = false;
    }
    else if (playerPos == "mine")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText("Press 'BACKSPACE' to enter the start!", 550, 50, 12, Color.BLACK);
        Raylib.DrawText("Press 'S' to enter the shop!", 600, 75, 12, Color.BLACK);
        min.Min();
        Raylib.DrawRectangle(436, 515, 100, 100, Color.BLUE);
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_M))
        {
            min.StartMining();
        }
        if (min.axePosy == 416)
        {
            digUp = gen.Next(16);
            if (digUp == 0)
            {
                digUp = gen.Next(16);
            }
            mon += digUp * power;
            min.axePosy = 200;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_S)) { playerPos = "shop"; }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE)) { playerPos = "out"; }
        toexp = false;
    }
    else if (playerPos == "shop")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText("Press 'M' to enter the mine!", 600, 50, 12, Color.BLACK);
        Raylib.DrawText("Press 'BACKSPACE' to enter the start!", 550, 75, 12, Color.BLACK);
        for (int i = 1; i < 4; i++)
        {
            Raylib.DrawText($"{i}.{store.shims[i].name}, price = ${store.shims[i].price}, power = {store.shims[i].power}", 50, 500 + i * 25, 24, Color.BLACK);
        }
        Raylib.DrawText("Press the number of the item you want to buy! (1, 2, or 3)", 50, 475, 24, Color.BLACK);
        char BIT = (char)Raylib.GetKeyPressed();
        int t = 0;
        int.TryParse(BIT.ToString(), out t);
        if (t != 0)
        {
            for (int i = 1; i < 4; i++)
            {
                if (t == i)
                {
                    CuIt = store.shims[i].name;
                    power = store.shims[i].power;
                    lastBought = store.shims[i].price;
                    mon -= lastBought;
                    min.pick = store.shims[i].wep;
                }
            }
            t = 0;
        }
        if (mon < 0)
        {
            mon += lastBought;
            CuIt = "hand";
            power = 2;
            toexp = true;
        }
        if (toexp == true)
        {
            Raylib.DrawText("That item is too expensive for you, try again!", 200, 400, 24, Color.BLACK);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_M)) { playerPos = "mine"; }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE)) { playerPos = "out"; }
    }

    Raylib.EndDrawing();
}
