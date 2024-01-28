using System;
using System.Collections.Generic;
using UnityEngine;
public static class Items
{
    // Get Dictionary from excel sheet
    private static readonly Dictionary<int, float> CoinSpawnProbabilities = new Dictionary<int, float> { { 0, 50 }, { 10, 100 }, { 200, 100 }, { 250, 100 }, { 300, 100 }, { 350, 100 }, { 400, 100 }, { 450, 100 }, { 500, 100 }, { 550, 100 }, { 600, 100 }, { 650, 100 }, { 700, 100 }, { 750, 100 }, { 800, 100 }, { 850, 100 }, { 900, 100 }, { 950, 100 }, { 1000, 100 }, { 1050, 100 }, { 1100, 100 }, { 1150, 100 }, { 1200, 100 }, { 1250, 100 }, { 1300, 100 }, { 1350, 100 }, { 1400, 100 }, { 1500, 100 }, { 1600, 100 }, { 1700, 100 }, { 1800, 100 }, { 1900, 100 }, { 2000, 100 }, { 2250, 100 }, { 2500, 100 }, { 2750, 100 }, { 3000, 100 }, { 3250, 100 } };
    private static readonly Dictionary<int, float> BananaSpawnProbabilities = new Dictionary<int, float> { { 0, 100 }, { 10, 100 }, { 200, 100 }, { 250, 100 }, { 300, 100 }, { 350, 100 }, { 400, 100 }, { 450, 100 }, { 500, 100 }, { 550, 40 }, { 600, 40 }, { 650, 40 }, { 700, 40 }, { 750, 40 }, { 800, 40 }, { 850, 40 }, { 900, 40 }, { 950, 40 }, { 1000, 40 }, { 1050, 40 }, { 1100, 40 }, { 1150, 40 }, { 1200, 40 }, { 1250, 40 }, { 1300, 40 }, { 1350, 40 }, { 1400, 40 }, { 1500, 40 }, { 1600, 40 }, { 1700, 40 }, { 1800, 40 }, { 1900, 40 }, { 2000, 40 }, { 2250, 40 }, { 2500, 40 }, { 2750, 40 }, { 3000, 40 }, { 3250, 40 } };
    private static readonly Dictionary<int, float> BlueShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 0 }, { 200, 25 }, { 250, 25 }, { 300, 25 }, { 350, 25 }, { 400, 25 }, { 450, 25 }, { 500, 25 }, { 550, 25 }, { 600, 25 }, { 650, 50 }, { 700, 100 }, { 750, 100 }, { 800, 100 }, { 850, 100 }, { 900, 100 }, { 950, 100 }, { 1000, 100 }, { 1050, 100 }, { 1100, 100 }, { 1150, 100 }, { 1200, 100 }, { 1250, 100 }, { 1300, 100 }, { 1350, 100 }, { 1400, 100 }, { 1500, 100 }, { 1600, 100 }, { 1700, 100 }, { 1800, 100 }, { 1900, 100 }, { 2000, 100 }, { 2250, 100 }, { 2500, 100 }, { 2750, 100 }, { 3000, 100 }, { 3250, 100 } };
    private static readonly Dictionary<int, float> GreenShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 100 }, { 10, 100 }, { 200, 100 }, { 250, 100 }, { 300, 100 }, { 350, 100 }, { 400, 100 }, { 450, 100 }, { 500, 100 }, { 550, 100 }, { 600, 100 }, { 650, 100 }, { 700, 100 }, { 750, 100 }, { 800, 100 }, { 850, 100 }, { 900, 100 }, { 950, 100 }, { 1000, 100 }, { 1050, 100 }, { 1100, 100 }, { 1150, 100 }, { 1200, 100 }, { 1250, 100 }, { 1300, 100 }, { 1350, 100 }, { 1400, 100 }, { 1500, 100 }, { 1600, 100 }, { 1700, 100 }, { 1800, 100 }, { 1900, 100 }, { 2000, 100 }, { 2250, 100 }, { 2500, 100 }, { 2750, 100 }, { 3000, 100 }, { 3250, 100 } };
    private static readonly Dictionary<int, float> RedShelliSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 20 }, { 200, 20 }, { 250, 20 }, { 300, 20 }, { 350, 20 }, { 400, 100 }, { 450, 100 }, { 500, 100 }, { 550, 100 }, { 600, 100 }, { 650, 100 }, { 700, 100 }, { 750, 100 }, { 800, 100 }, { 850, 100 }, { 900, 100 }, { 950, 100 }, { 1000, 100 }, { 1050, 100 }, { 1100, 100 }, { 1150, 100 }, { 1200, 100 }, { 1250, 100 }, { 1300, 100 }, { 1350, 100 }, { 1400, 100 }, { 1500, 100 }, { 1600, 100 }, { 1700, 100 }, { 1800, 100 }, { 1900, 100 }, { 2000, 100 }, { 2250, 100 }, { 2500, 100 }, { 2750, 100 }, { 3000, 100 }, { 3250, 100 } };
    private static readonly Dictionary<int, float> FlashiSpawnProbabilities = new Dictionary<int, float> { { 0, 1 }, { 10, 20 }, { 200, 20 }, { 250, 20 }, { 300, 20 }, { 350, 20 }, { 400, 20 }, { 450, 20 }, { 500, 20 }, { 550, 20 }, { 600, 20 }, { 650, 20 }, { 700, 20 }, { 750, 20 }, { 800, 20 }, { 850, 20 }, { 900, 20 }, { 950, 20 }, { 1000, 20 }, { 1050, 20 }, { 1100, 20 }, { 1150, 20 }, { 1200, 20 }, { 1250, 20 }, { 1300, 20 }, { 1350, 20 }, { 1400, 20 }, { 1500, 20 }, { 1600, 20 }, { 1700, 20 }, { 1800, 20 }, { 1900, 20 }, { 2000, 20 }, { 2250, 20 }, { 2500, 20 }, { 2750, 20 }, { 3000, 20 }, { 3250, 20 } };
    private static readonly Dictionary<int, float> GhostiSpawnProbabilities = new Dictionary<int, float> { { 0, 50 }, { 10, 50 }, { 200, 50 }, { 250, 50 }, { 300, 50 }, { 350, 50 }, { 400, 50 }, { 450, 50 }, { 500, 50 }, { 550, 50 }, { 600, 50 }, { 650, 50 }, { 700, 50 }, { 750, 50 }, { 800, 50 }, { 850, 50 }, { 900, 50 }, { 950, 50 }, { 1000, 50 }, { 1050, 50 }, { 1100, 50 }, { 1150, 50 }, { 1200, 50 }, { 1250, 50 }, { 1300, 50 }, { 1350, 50 }, { 1400, 50 }, { 1500, 50 }, { 1600, 50 }, { 1700, 50 }, { 1800, 50 }, { 1900, 50 }, { 2000, 50 }, { 2250, 50 }, { 2500, 50 }, { 2750, 50 }, { 3000, 50 }, { 3250, 50 } };
    private static readonly Dictionary<int, float> MushiSpawnProbabilities = new Dictionary<int, float> { { 0, 1 }, { 10, 1 }, { 200, 1 }, { 250, 1 }, { 300, 10 }, { 350, 10 }, { 400, 10 }, { 450, 10 }, { 500, 10 }, { 550, 10 }, { 600, 10 }, { 650, 10 }, { 700, 10 }, { 750, 10 }, { 800, 100 }, { 850, 100 }, { 900, 100 }, { 950, 100 }, { 1000, 100 }, { 1050, 100 }, { 1100, 100 }, { 1150, 100 }, { 1200, 100 }, { 1250, 100 }, { 1300, 100 }, { 1350, 200 }, { 1400, 200 }, { 1500, 200 }, { 1600, 200 }, { 1700, 200 }, { 1800, 200 }, { 1900, 200 }, { 2000, 200 }, { 2250, 200 }, { 2500, 200 }, { 2750, 200 }, { 3000, 200 }, { 3250, 200 } };
    private static readonly Dictionary<int, float> RockiSpawnProbabilities = new Dictionary<int, float> { { 0, 1 }, { 10, 1 }, { 200, 1 }, { 250, 1 }, { 300, 1 }, { 350, 1 }, { 400, 1 }, { 450, 1 }, { 500, 1 }, { 550, 50 }, { 600, 50 }, { 650, 50 }, { 700, 50 }, { 750, 100 }, { 800, 100 }, { 850, 100 }, { 900, 100 }, { 950, 100 }, { 1000, 100 }, { 1050, 100 }, { 1100, 100 }, { 1150, 100 }, { 1200, 100 }, { 1250, 100 }, { 1300, 100 }, { 1350, 100 }, { 1400, 100 }, { 1500, 100 }, { 1600, 100 }, { 1700, 100 }, { 1800, 100 }, { 1900, 100 }, { 2000, 100 }, { 2250, 100 }, { 2500, 100 }, { 2750, 100 }, { 3000, 100 }, { 3250, 100 } };
    private static readonly Dictionary<int, float> StariSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 20 }, { 200, 20 }, { 250, 20 }, { 300, 20 }, { 350, 20 }, { 400, 20 }, { 450, 20 }, { 500, 20 }, { 550, 20 }, { 600, 20 }, { 650, 20 }, { 700, 20 }, { 750, 20 }, { 800, 20 }, { 850, 20 }, { 900, 20 }, { 950, 20 }, { 1000, 20 }, { 1050, 20 }, { 1100, 20 }, { 1150, 20 }, { 1200, 20 }, { 1250, 20 }, { 1300, 20 }, { 1350, 20 }, { 1400, 20 }, { 1500, 20 }, { 1600, 20 }, { 1700, 20 }, { 1800, 20 }, { 1900, 20 }, { 2000, 20 }, { 2250, 20 }, { 2500, 20 }, { 2750, 20 }, { 3000, 20 }, { 3250, 20 } };
    private static readonly Dictionary<int, float> SnailiSpawnProbabilities = new Dictionary<int, float> { { 0, 0 }, { 10, 20 }, { 200, 20 }, { 250, 20 }, { 300, 20 }, { 350, 20 }, { 400, 20 }, { 450, 20 }, { 500, 20 }, { 550, 20 }, { 600, 20 }, { 650, 20 }, { 700, 20 }, { 750, 20 }, { 800, 20 }, { 850, 20 }, { 900, 20 }, { 950, 20 }, { 1000, 20 }, { 1050, 20 }, { 1100, 20 }, { 1150, 20 }, { 1200, 20 }, { 1250, 20 }, { 1300, 20 }, { 1350, 20 }, { 1400, 20 }, { 1500, 20 }, { 1600, 20 }, { 1700, 20 }, { 1800, 20 }, { 1900, 20 }, { 2000, 20 }, { 2250, 20 }, { 2500, 20 }, { 2750, 20 }, { 3000, 20 }, { 3250, 20 } };
    private static readonly Dictionary<int, float> EraserSpawnProbabilities = new Dictionary<int, float> { { 0, 100 }, { 10, 100 }, { 200, 100 }, { 250, 100 }, { 300, 100 }, { 350, 100 }, { 400, 100 }, { 450, 100 }, { 500, 100 }, { 550, 100 }, { 600, 100 }, { 650, 100 }, { 700, 100 }, { 750, 100 }, { 800, 100 }, { 850, 100 }, { 900, 100 }, { 950, 50 }, { 1000, 50 }, { 1050, 50 }, { 1100, 50 }, { 1150, 50 }, { 1200, 50 }, { 1250, 50 }, { 1300, 50 }, { 1350, 50 }, { 1400, 50 }, { 1500, 50 }, { 1600, 50 }, { 1700, 50 }, { 1800, 50 }, { 1900, 50 }, { 2000, 50 }, { 2250, 50 }, { 2500, 50 }, { 2750, 50 }, { 3000, 50 }, { 3250, 50 } };




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
            itemActions.MoveToCenterAndFadeOut(itemControl, targetPlayerControl, 0.8f, () =>
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
            itemActions.MoveToCenterAndFadeOut(itemControl, targetPlayerControl, 0.8f, () =>
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
            itemActions.MoveToCenterAndFadeOut(itemControl, targetPlayerControl, 0.8f, () =>
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
             itemActions.MoveToCenterAndFadeOut(itemControl, targetPlayerControl, 0.9f, () =>
              {
                  itemActions.ShowItemRating(targetPlayerControl, "Snaili Slow Down");
              });
         },
        // Get Dictionary from excel sheet
        SpawnProbabilities = SnailiSpawnProbabilities,
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
        SpawnProbabilities = EraserSpawnProbabilities,

    };

    public static readonly Item TinaTurner = new Item("Tina Turner")
    {
        Description = "Rotates the Screen 360°",
        ImagePath = "images/items/rotateScreen.png",
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
             itemActions.rotateScreen(2);
             itemActions.MoveToCenterAndFadeOut(itemControl, targetPlayerControl, 0.9f, () =>
                    {
                        itemActions.ShowItemRating(targetPlayerControl, "Tina Turner");
                    });
         },
        // Get Dictionary from excel sheet
        SpawnProbabilities = EraserSpawnProbabilities,

    };

    public static readonly Item Shaker = new Item("Shaker")
    {
        Description = "Shakes the Screen for 3 seconds",
        ImagePath = "images/items/shakescreen.png",
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
             itemActions.shakeScreen(2, 0.9f);
             itemActions.MoveToCenterAndFadeOut(itemControl, targetPlayerControl, 0.9f, () =>
                    {
                        itemActions.ShowItemRating(targetPlayerControl, "Shaker");
                    });
         },
        // Get Dictionary from excel sheet
        SpawnProbabilities = EraserSpawnProbabilities,

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
        Eraser,
        TinaTurner,
        Shaker
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
