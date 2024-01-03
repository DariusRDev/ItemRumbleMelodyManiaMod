using System;
using System.Collections.Generic;
using UnityEngine;
public static class Items
{
    private static readonly Dictionary<int, float> CoinSpawnProbabilities = new Dictionary<int, float> { { 0, 10 }, { 10, 105 }, { 200, 110 }, { 250, 115 }, { 300, 120 }, { 350, 125 }, { 400, 130 }, { 450, 135 }, { 500, 140 }, { 550, 145 }, { 600, 150 }, { 650, 155 }, { 700, 160 }, { 750, 165 }, { 800, 170 }, { 850, 170 }, { 900, 171 }, { 950, 172 }, { 1000, 173 }, { 1050, 174 }, { 1100, 175 }, { 1150, 176 }, { 1200, 177 }, { 1250, 178 }, { 1300, 179 }, { 1350, 180 }, { 1400, 181 }, { 1500, 182 }, { 1600, 183 }, { 1700, 184 }, { 1800, 185 }, { 1900, 186 }, { 2000, 187 }, { 2250, 188 }, { 2500, 189 }, { 2750, 190 }, { 3000, 191 }, { 3250, 192 } };
    private static readonly Dictionary<int, float> BananaSpawnProbabilities = new Dictionary<int, float> { { 0, 190 }, { 10, 95 }, { 200, 90 }, { 250, 85 }, { 300, 80 }, { 350, 75 }, { 400, 70 }, { 450, 65 }, { 500, 60 }, { 550, 55 }, { 600, 50 }, { 650, 45 }, { 700, 40 }, { 750, 35 }, { 800, 30 }, { 850, 30 }, { 900, 30 }, { 950, 30 }, { 1000, 30 }, { 1050, 30 }, { 1100, 30 }, { 1150, 30 }, { 1200, 30 }, { 1250, 30 }, { 1300, 30 }, { 1350, 30 }, { 1400, 30 }, { 1500, 30 }, { 1600, 30 }, { 1700, 30 }, { 1800, 30 }, { 1900, 30 }, { 2000, 30 }, { 2250, 30 }, { 2500, 30 }, { 2750, 30 }, { 3000, 30 }, { 3250, 30 } };
    private static readonly Dictionary<int, float> BlueShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 0 }, { 200, 0 }, { 250, 0 }, { 300, 0 }, { 350, 0 }, { 400, 10 }, { 450, 12 }, { 500, 14 }, { 550, 16 }, { 600, 18 }, { 650, 20 }, { 700, 22 }, { 750, 24 }, { 800, 26 }, { 850, 28 }, { 900, 30 }, { 950, 32 }, { 1000, 34 }, { 1050, 36 }, { 1100, 38 }, { 1150, 40 }, { 1200, 42 }, { 1250, 44 }, { 1300, 46 }, { 1350, 50 }, { 1400, 54 }, { 1500, 58 }, { 1600, 62 }, { 1700, 66 }, { 1800, 70 }, { 1900, 74 }, { 2000, 78 }, { 2250, 82 }, { 2500, 86 }, { 2750, 90 }, { 3000, 94 }, { 3250, 98 } };
    private static readonly Dictionary<int, float> GreenShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 5 }, { 10, 5 }, { 200, 5 }, { 250, 10 }, { 300, 10 }, { 350, 10 }, { 400, 10 }, { 450, 20 }, { 500, 40 }, { 550, 40 }, { 600, 40 }, { 650, 20 }, { 700, 20 }, { 750, 20 }, { 800, 20 }, { 850, 20 }, { 900, 25 }, { 950, 30 }, { 1000, 35 }, { 1050, 40 }, { 1100, 45 }, { 1150, 50 }, { 1200, 55 }, { 1250, 60 }, { 1300, 65 }, { 1350, 70 }, { 1400, 75 }, { 1500, 80 }, { 1600, 85 }, { 1700, 90 }, { 1800, 95 }, { 1900, 100 }, { 2000, 105 }, { 2250, 110 }, { 2500, 115 }, { 2750, 120 }, { 3000, 125 }, { 3250, 130 } };
    private static readonly Dictionary<int, float> RedShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 1 }, { 200, 1 }, { 250, 18 }, { 300, 18 }, { 350, 18 }, { 400, 18 }, { 450, 18 }, { 500, 18 }, { 550, 18 }, { 600, 18 }, { 650, 18 }, { 700, 18 }, { 750, 18 }, { 800, 18 }, { 850, 18 }, { 900, 25 }, { 950, 32 }, { 1000, 39 }, { 1050, 46 }, { 1100, 53 }, { 1150, 60 }, { 1200, 67 }, { 1250, 74 }, { 1300, 81 }, { 1350, 88 }, { 1400, 95 }, { 1500, 102 }, { 1600, 109 }, { 1700, 116 }, { 1800, 123 }, { 1900, 130 }, { 2000, 137 }, { 2250, 144 }, { 2500, 151 }, { 2750, 158 }, { 3000, 165 }, { 3250, 172 } };

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
        SpawnProbabilities = CoinSpawnProbabilities
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
        SpawnProbabilities = BananaSpawnProbabilities
    };

    public static readonly Item BlueShelli = new Item("BlueShelli")
    {
        Description = "Deducts 500 Points from the player in first place",
        ImagePath = "images/items/shells/blue_shell.png",
        VisualElementName = "shellCollectorItem",
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
        SpawnProbabilities = BlueShelliSpawnProbabilities
    };
    public static readonly Item GreenShelli = new Item("GreenShelli")
    {
        Description = "Deducts 50 points from a random player",
        ImagePath = "images/items/shells/green_shell.png",
        VisualElementName = "shellCollectorItem",
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
        SpawnProbabilities = GreenShelliSpawnProbabilities
    };
    public static readonly Item RedShelli = new Item("RedShelli")
    {
        Description = "Deducts 50 points the player in front of you",
        ImagePath = "images/items/shells/red_shell.png",
        VisualElementName = "shellCollectorItem",
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
        SpawnProbabilities = RedShelliSpawnProbabilities
    };


    public static readonly List<Item> AllItems = new List<Item>()
    {
        Coin,
        Banana,
        BlueShelli,
        GreenShelli,
        RedShelli
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
