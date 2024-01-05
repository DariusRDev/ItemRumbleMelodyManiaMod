using System;
using System.Collections.Generic;
using UnityEngine;
public static class Items
{
    // Get Dictionary from excel sheet
    private static readonly Dictionary<int, float> CoinSpawnProbabilities = new Dictionary<int, float> { { 0, 80 }, { 10, 105 }, { 200, 110 }, { 250, 115 }, { 300, 120 }, { 350, 125 }, { 400, 130 }, { 450, 135 }, { 500, 140 }, { 550, 145 }, { 600, 150 }, { 650, 155 }, { 700, 160 }, { 750, 165 }, { 800, 170 }, { 850, 170 }, { 900, 171 }, { 950, 172 }, { 1000, 173 }, { 1050, 174 }, { 1100, 175 }, { 1150, 176 }, { 1200, 177 }, { 1250, 178 }, { 1300, 179 }, { 1350, 180 }, { 1400, 181 }, { 1500, 182 }, { 1600, 183 }, { 1700, 184 }, { 1800, 185 }, { 1900, 186 }, { 2000, 187 }, { 2250, 188 }, { 2500, 189 }, { 2750, 190 }, { 3000, 191 }, { 3250, 192 } };
    private static readonly Dictionary<int, float> BananaSpawnProbabilities = new Dictionary<int, float> { { 0, 90 }, { 10, 95 }, { 200, 90 }, { 250, 85 }, { 300, 80 }, { 350, 75 }, { 400, 70 }, { 450, 65 }, { 500, 60 }, { 550, 55 }, { 600, 50 }, { 650, 45 }, { 700, 45 }, { 750, 45 }, { 800, 45 }, { 850, 45 }, { 900, 45 }, { 950, 45 }, { 1000, 45 }, { 1050, 45 }, { 1100, 45 }, { 1150, 45 }, { 1200, 45 }, { 1250, 45 }, { 1300, 45 }, { 1350, 45 }, { 1400, 45 }, { 1500, 45 }, { 1600, 45 }, { 1700, 45 }, { 1800, 45 }, { 1900, 45 }, { 2000, 45 }, { 2250, 45 }, { 2500, 45 }, { 2750, 45 }, { 3000, 45 }, { 3250, 45 } };
    private static readonly Dictionary<int, float> BlueShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 0 }, { 200, 0 }, { 250, 0 }, { 300, 0 }, { 350, 0 }, { 400, 10 }, { 450, 12 }, { 500, 14 }, { 550, 16 }, { 600, 18 }, { 650, 20 }, { 700, 22 }, { 750, 24 }, { 800, 26 }, { 850, 28 }, { 900, 30 }, { 950, 32 }, { 1000, 34 }, { 1050, 36 }, { 1100, 38 }, { 1150, 40 }, { 1200, 42 }, { 1250, 44 }, { 1300, 46 }, { 1350, 50 }, { 1400, 54 }, { 1500, 58 }, { 1600, 62 }, { 1700, 66 }, { 1800, 70 }, { 1900, 74 }, { 2000, 78 }, { 2250, 82 }, { 2500, 86 }, { 2750, 90 }, { 3000, 94 }, { 3250, 98 } };
    private static readonly Dictionary<int, float> GreenShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 5 }, { 10, 5 }, { 200, 5 }, { 250, 10 }, { 300, 10 }, { 350, 10 }, { 400, 10 }, { 450, 20 }, { 500, 40 }, { 550, 40 }, { 600, 40 }, { 650, 20 }, { 700, 20 }, { 750, 20 }, { 800, 20 }, { 850, 20 }, { 900, 25 }, { 950, 30 }, { 1000, 35 }, { 1050, 40 }, { 1100, 45 }, { 1150, 50 }, { 1200, 55 }, { 1250, 60 }, { 1300, 65 }, { 1350, 70 }, { 1400, 75 }, { 1500, 80 }, { 1600, 85 }, { 1700, 90 }, { 1800, 95 }, { 1900, 100 }, { 2000, 105 }, { 2250, 110 }, { 2500, 115 }, { 2750, 120 }, { 3000, 125 }, { 3250, 130 } };
    private static readonly Dictionary<int, float> RedShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 1 }, { 200, 1 }, { 250, 18 }, { 300, 18 }, { 350, 18 }, { 400, 18 }, { 450, 18 }, { 500, 18 }, { 550, 18 }, { 600, 18 }, { 650, 50 }, { 700, 50 }, { 750, 50 }, { 800, 50 }, { 850, 50 }, { 900, 50 }, { 950, 50 }, { 1000, 50 }, { 1050, 50 }, { 1100, 53 }, { 1150, 60 }, { 1200, 67 }, { 1250, 74 }, { 1300, 81 }, { 1350, 88 }, { 1400, 95 }, { 1500, 102 }, { 1600, 109 }, { 1700, 116 }, { 1800, 123 }, { 1900, 130 }, { 2000, 137 }, { 2250, 144 }, { 2500, 151 }, { 2750, 158 }, { 3000, 165 }, { 3250, 172 } };
    private static readonly Dictionary<int, float> FlashiSpawnProbabilities = new Dictionary<int, float> { { 0, 20 }, { 10, 10 }, { 200, 10 }, { 250, 10 }, { 300, 10 }, { 350, 80 }, { 400, 10 }, { 450, 50 }, { 500, 10 }, { 550, 100 }, { 600, 100 }, { 650, 100 }, { 700, 100 }, { 750, 100 }, { 800, 20 }, { 850, 20 } };
    private static readonly Dictionary<int, float> GhostiSpawnProbabilities = new Dictionary<int, float> { { 0, 20 }, { 10, 10 }, { 200, 18 }, { 250, 26 }, { 300, 26 }, { 350, 26 }, { 400, 26 }, { 450, 26 }, { 500, 26 }, { 550, 26 }, { 600, 26 }, { 650, 26 }, { 700, 26 }, { 750, 26 }, { 800, 26 }, { 850, 26 } };
    private static readonly Dictionary<int, float> MushiSpawnProbabilities = new Dictionary<int, float> { { 0, 1 }, { 10, 20 }, { 200, 39 }, { 250, 58 }, { 300, 58 }, { 350, 58 }, { 400, 58 }, { 450, 58 }, { 500, 58 }, { 550, 58 }, { 600, 58 }, { 650, 58 }, { 700, 58 }, { 750, 58 }, { 800, 77 }, { 850, 77 } };
    private static readonly Dictionary<int, float> RockiSpawnProbabilities = new Dictionary<int, float> { { 0, 5 }, { 10, 10 }, { 200, 10 }, { 250, 10 }, { 300, 10 }, { 350, 10 }, { 400, 10 }, { 450, 10 }, { 500, 25 }, { 550, 25 }, { 600, 25 }, { 650, 25 }, { 700, 25 }, { 750, 25 }, { 800, 25 }, { 850, 25 } };
    private static readonly Dictionary<int, float> StariSpawnProbabilities = new Dictionary<int, float> { { 0, 5 }, { 10, 10 }, { 200, 10 }, { 250, 10 }, { 300, 10 }, { 350, 10 }, { 400, 10 }, { 450, 10 }, { 500, 25 }, { 550, 25 }, { 600, 25 }, { 650, 25 }, { 700, 25 }, { 750, 25 }, { 800, 25 }, { 850, 25 } };


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

           // Get the PlayerControl of the affected player.
           PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();

           // Add Actions here.
           itemActions.AddScore(targetPlayerControl, 100);
           itemActions.BouncePlayerScoreLabel(targetPlayerControl);
           itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "+100 Coin");
       },
        // Get Dictionary from excel sheet
        SpawnProbabilities = CoinSpawnProbabilities
    };

    public static readonly Item Banana = new Item("Banana")
    {
        Description = "Subtracts 75 Points",
        ImagePath = "images/items/banana/fruit_banana.png",
        VisualElementName = "itemCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
            // Add Actions here.
            itemActions.AddScore(targetPlayerControl, -75);
            itemActions.BouncePlayerScoreLabel(targetPlayerControl);
            itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "-75 Banana");
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = BananaSpawnProbabilities
    };

    public static readonly Item BlueShelli = new Item("Blue Shelli")
    {
        Description = "Deducts 250 Points from the player in first place",
        ImagePath = "images/items/shells/blue_shell.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetFirstPlacePlayerControl();
            // Add Actions here.
            itemActions.AddScore(targetPlayerControl, -250);
            itemActions.BouncePlayerScoreLabel(targetPlayerControl);
            itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "-250 Blue Shell");
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = BlueShelliSpawnProbabilities
    };

    public static readonly Item GreenShelli = new Item("Green Shelli")
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
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetRandomPlayerControl();
            // Add Actions here.
            itemActions.AddScore(targetPlayerControl, -50);
            itemActions.BouncePlayerScoreLabel(targetPlayerControl);
            itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "-50 Green Shell");
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = GreenShelliSpawnProbabilities
    };

    public static readonly Item RedShelli = new Item("Red Shelli")
    {
        Description = "Deducts 75 points the player in front of you",
        ImagePath = "images/items/shells/red_shell.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetInFrontOfMePlayerControl();
            // Add Actions here.
            itemActions.AddScore(targetPlayerControl, -75);
            itemActions.BouncePlayerScoreLabel(targetPlayerControl);
            itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "-75 Red Shell");
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = RedShelliSpawnProbabilities
    };

    public static readonly Item Flashi = new Item("Flashi")
    {
        Description = "Mutes audio for 2 seconds",
        ImagePath = "images/items/lightning.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
            // Add Actions here.
            itemActions.MuteAudio(2);
            itemActions.MoveToCenterAndFadeOut(itemControl.VisualElement, 0.8f, () =>
            {
                itemActions.ShowItemRating(targetPlayerControl, "Flashi");
            });
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = FlashiSpawnProbabilities,
    };

    public static readonly Item Ghosti = new Item("Ghosti")
    {
        Description = "Makes lyrics invisible for 5 seconds",
        ImagePath = "images/items/ghost.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
            // Add Actions here.
            itemActions.DisableLyricsForSeconds(5);
            itemActions.MoveToCenterAndFadeOut(itemControl.VisualElement, 0.8f, () =>
             {
                 itemActions.ShowItemRating(targetPlayerControl, "Ghosti");
             });
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = GhostiSpawnProbabilities,
    };

    public static readonly Item Mushi = new Item("Mushi Mushroom")
    {
        Description = "Gives you 250 points",
        ImagePath = "images/items/mushroom.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
            // Add Actions here.
            itemActions.AddScore(targetPlayerControl, 250);
            itemActions.BouncePlayerScoreLabel(targetPlayerControl);
            itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "+250 Mushi Mushroom");
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = MushiSpawnProbabilities,
    };

    public static readonly Item Rocki = new Item("Rocki Rocket")
    {
        Description = "Gives you 500 points",
        ImagePath = "images/items/rocket.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
            // Add Actions here.
            itemActions.AddScore(targetPlayerControl, 500);
            itemActions.BouncePlayerScoreLabel(targetPlayerControl);
            itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "+500 Rocki Rocket");
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = RockiSpawnProbabilities,
    };


    public static readonly Item Stari = new Item("Stari")
    {
        Description = "Speeds up the song for 3 seconds",
        ImagePath = "images/items/star.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
        {
            // Cast the object to the correct type.
            var itemActions = (ItemActions)itemActionsObject;
            var itemControl = (ItemControl)itemControlObject;
            // Get the PlayerControl of the affected player.
            PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
            // Add Actions here.
            itemActions.ChangePlaybackSpeed(3);
            itemActions.MoveToCenterAndFadeOut(itemControl.VisualElement, 0.8f, () =>
             {
                 itemActions.ShowItemRating(targetPlayerControl, "Stari Speed Up");
             });
        },
        // Get Dictionary from excel sheet
        SpawnProbabilities = StariSpawnProbabilities,
    };

    public static readonly Item Snaili = new Item("Snaili")
    {
        Description = "Slows down the song for 3 seconds",
        ImagePath = "images/items/snaili.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
         {
             // Cast the object to the correct type.
             var itemActions = (ItemActions)itemActionsObject;
             var itemControl = (ItemControl)itemControlObject;
             // Get the PlayerControl of the affected player.
             PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
             // Add Actions here.
             itemActions.ChangePlaybackSpeed(3, 0.5f);
             itemActions.MoveToCenterAndFadeOut(itemControl.VisualElement, 0.8f, () =>
              {
                  itemActions.ShowItemRating(targetPlayerControl, "Snaili Slow Down");
              });
         },
        // Get Dictionary from excel sheet
        SpawnProbabilities = StariSpawnProbabilities,
    };

    public static readonly Item Eraser = new Item("Note Eraseri")
    {
        Description = "Hides the Notes of the Collecting Player for 5 seconds",
        ImagePath = "images/items/eraser.png",
        VisualElementName = "shellCollectorItem",
        // Has to be object, because of loading order of cs files.
        OnCollectAction = (object itemActionsObject, object itemControlObject) =>
         {
             // Cast the object to the correct type.
             var itemActions = (ItemActions)itemActionsObject;
             var itemControl = (ItemControl)itemControlObject;
             // Get the PlayerControl of the affected player.
             PlayerControl targetPlayerControl = itemActions.GetMyPlayerControll();
             // Add Actions here.
             itemActions.HideNotesForSeconds(5);
             itemActions.AnimateItemCollection(targetPlayerControl, itemControl, "Note Eraser");
         },
        // Get Dictionary from excel sheet
        SpawnProbabilities = StariSpawnProbabilities,

    };



    public static readonly List<Item> AllItems = new List<Item>()
    {
        Coin,
        Banana,
        BlueShelli,
        GreenShelli,
        RedShelli,
        Flashi,
        Ghosti,
        Mushi,
        Rocki,
        Stari,
        Snaili,
        Eraser
    };

    /**
     * Returns a random item based on the pointsToFirstPlace.
     */
    public static Item SpawnItem(int pointsToFirstPlace, List<Item> activeItems)
    {

        try
        {
            Dictionary<Item, int> itemProbabilities = new Dictionary<Item, int>();
            foreach (Item item in activeItems)
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
