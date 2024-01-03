using System;
using System.Collections.Generic;
public static class Items
{
    // Has to be object, because of loading order of cs files.
    public static readonly Item Coin = new Item("Coin", "images/items/coins/Gold_1.png", "itemCollectorItem", (object itemActionsObject, object itemControlObject) =>
    {
        // Cast the object to the correct type.
        var itemActions = (ItemActions)itemActionsObject;
        var itemControl = (ItemControl)itemControlObject;
        itemActions.AddScore(100);
        itemActions.BouncePlayerScoreLabel();
        itemActions.AnimateItemCollection(itemControl);

    });

    // Has to be object, because of loading order of cs files.
    public static readonly Item Banana = new Item("Banana", "images/items/banana/fruit_banana.png", "itemCollectorItem", (object itemActionsObject, object itemControlObject) =>
    {
        // Cast the object to the correct type.
        var itemActions = (ItemActions)itemActionsObject;
        var itemControl = (ItemControl)itemControlObject;
        itemActions.AddScore(-50);
        itemActions.BouncePlayerScoreLabel();
        itemActions.AnimateItemCollection(itemControl);
    });


    public static readonly List<Item> AllItems = new List<Item>()
    {
        Coin,
        Banana
    };
}
