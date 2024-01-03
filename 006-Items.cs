using System;
using System.Collections.Generic;
public static class Items
{
    // Has to be object, because of loading order of cs files.
    public static readonly Item Coin = new Item("Coin")
    {
        Description = "Adds 100 Points",
        ImagePath = "images/items/coins/Gold_1.png",
        VisualElementName = "itemCollectorItem",

        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Add Actions here.
            itemActions.AddScore(100);
            itemActions.BouncePlayerScoreLabel();
            itemActions.AnimateItemCollection(itemControl);
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = { { 100, 100 }, { 150, 105 }, { 200, 110 }, { 250, 115 }, { 300, 120 }, { 350, 125 }, { 400, 130 }, { 450, 135 }, { 500, 140 }, { 550, 145 }, { 600, 150 }, { 650, 155 }, { 700, 160 }, { 750, 165 }, { 800, 170 }, { 1000, 200 } }
    };

    public static readonly Item Banana = new Item("Banana")
    {
        Description = "Subtracts 50 Points",
        ImagePath = "images/items/banana/fruit_banana.png",
        VisualElementName = "itemCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Add Actions here.
            itemActions.AddScore(-50);
            itemActions.BouncePlayerScoreLabel();
            itemActions.AnimateItemCollection(itemControl);
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = { { 100, 100 }, { 150, 95 }, { 200, 90 }, { 250, 85 }, { 300, 80 }, { 350, 75 }, { 400, 70 }, { 450, 65 }, { 500, 60 }, { 550, 55 }, { 600, 50 }, { 650, 45 }, { 700, 40 }, { 750, 35 }, { 800, 30 }, { 1000, 0 } }
    };


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
    }
}
