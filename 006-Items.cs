using System;
using System.Collections.Generic;
public static class Items
{
    // Has to be object, because of loading order of cs files.
    public static readonly Item Coin = new Item("Coin", "Adds 100 Points", "images/items/coins/Gold_1.png", "itemCollectorItem", (object itemActionsObject, object itemControlObject) =>
    {
        // Cast the object to the correct type.
        var itemActions = (ItemActions)itemActionsObject;
        var itemControl = (ItemControl)itemControlObject;
        // Add Actions here.
        itemActions.AddScore(100);
        itemActions.BouncePlayerScoreLabel();
        itemActions.AnimateItemCollection(itemControl);
    });

    // Has to be object, because of loading order of cs files.
    public static readonly Item Banana = new Item("Banana", "Subtracts 50 Points", "images/items/banana/fruit_banana.png", "itemCollectorItem", (object itemActionsObject, object itemControlObject) =>
    {

        // Cast the object to the correct type.
        var itemActions = (ItemActions)itemActionsObject;
        var itemControl = (ItemControl)itemControlObject;
        // Add Actions here.
        itemActions.AddScore(-50);
        itemActions.BouncePlayerScoreLabel();
        itemActions.AnimateItemCollection(itemControl);
    });


    public static readonly List<Item> AllItems = new List<Item>()
    {
        Coin,
        Banana
    };

    /**
     * Returns a random item based on the pointsToFirstPlace.
     */
    public static Item SpawnItem(int pointsToFirstPlace)
    {
        return Banana;

        /* if (pointsToFirstPlace < 0)
        {
            return Banana;
        }
        else
        {
            return Banana;
        } */
        //return AllItems[UnityEngine.Random.Range(0, AllItems.Count)];
    }
}
