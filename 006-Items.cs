using System;
using System.Collections.Generic;
public static class Items
{
    public static readonly Item Coin = new Item("Coin", "images/items/coins/Gold_1.png", "itemCollectorItem", (ItemActions itemActions) =>
    {
        itemActions.AddScore(100);
    });

    public static readonly Item Banana = new Item("Banana", "images/items/banana/fruit_banana.png", "itemCollectorItem", (ItemActions itemActions) =>
    {
        itemActions.AddScore(-50);

    });


    public static readonly List<Item> AllItems = new List<Item>()
    {
        Coin,
        Banana
    };
}
