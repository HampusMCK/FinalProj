using System;



public class Shitems
{
    
    public List<shitemInfo> shims = new List<shitemInfo>();

        public Shitems(){
            shims.Add(new shitemInfo {name = "hand", price = 0, power = 1, wep = Raylib.LoadTexture("hand.png")});
            shims.Add(new shitemInfo {name = "Shovel", price = 50, power = 2, wep = Raylib.LoadTexture("shovel.png")});
            shims.Add(new shitemInfo {name = "Pickaxe", price = 100, power = 4, wep = Raylib.LoadTexture("pick.png")});
            shims.Add(new shitemInfo {name = "Drill", price = 200, power = 8, wep = Raylib.LoadTexture("drill.png")});
        }
}
