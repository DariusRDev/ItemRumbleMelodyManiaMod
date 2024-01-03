using System;
using System.Collections.Generic;
using UnityEngine;
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
        SpawnProbabilities = { { 0, 100 }, { 150, 105 }, { 200, 110 }, { 250, 115 }, { 300, 120 }, { 350, 125 }, { 400, 130 }, { 450, 135 }, { 500, 140 }, { 550, 145 }, { 600, 150 }, { 650, 155 }, { 700, 160 }, { 750, 165 }, { 800, 170 }, { 1000, 200 } }

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
        SpawnProbabilities = { { 0, 100 }, { 150, 95 }, { 200, 90 }, { 250, 85 }, { 300, 80 }, { 350, 75 }, { 400, 70 }, { 450, 65 }, { 500, 60 }, { 550, 55 }, { 600, 50 }, { 650, 45 }, { 700, 40 }, { 750, 35 }, { 800, 30 }, { 1000, 0 } }

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

        try
        {
            Dictionary<Item, int> itemProbabilities = new Dictionary<Item, int>();
            foreach (Item item in AllItems)
            {
                // find nearest key in dictionary
                int nearestKey = 0;
                foreach (int key in item.SpawnProbabilities.Keys)
                {
                    if (Math.Abs(key - pointsToFirstPlace) < Math.Abs(nearestKey - pointsToFirstPlace))
                    {
                        nearestKey = key;
                    }
                }


                int probability = (int)item.SpawnProbabilities[nearestKey];
                itemProbabilities.Add(item, probability);

            }

            // monte carlo method
            int sum = 0;
            foreach (int probability in itemProbabilities.Values)
            {
                sum += probability;
            }
            int randomValue = UnityEngine.Random.Range(0, sum);
            int currentSum = 0;
            foreach (Item item in itemProbabilities.Keys)
            {

                currentSum += itemProbabilities[item];
                if (randomValue <= currentSum)
                {
                    Debug.Log($"MonteCarlo Workded Pointdif  {pointsToFirstPlace} Item: {item.Name} RandomValue: {randomValue} CurrentSum: {currentSum} ");
                    return item;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        return Coin;

    }
}
