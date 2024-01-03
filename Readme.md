# Item Rumble Mod

## Disclaimer

Please note that this mod is currently under development and is not intended for gameplay yet. The `item spawn probabilities based on player rank` have not been balanced, and the gameplay experience may not be enjoyable at this stage.
The Shells *dont work as expected*
The deactivation of Items has to be implemented  

## Features
The Item Rumble Mod adds items to the game that appear on notes with different effects and can be collected. It is designed to be easily extendable, allowing you to add new items by adding PNG images to the images folder and adding the item details in the Items.cs file (name, imagePath, onCollect method). Custom behaviors can be implemented in the ItemActions.cs file, such as adding points.
![image](https://github.com/DerDorius/ItemRumbleMelodyManiaMod/assets/77979816/b4b50ee4-8263-4a2d-a3ef-f8cc22a68c57)
![image](https://github.com/DerDorius/ItemRumbleMelodyManiaMod/assets/77979816/da948896-3f0a-4d5a-be74-50caffa31efa)


Contributions are welcome, especially for animations, as I am not proficient in that area.

## Planned Features

The items could be similar to those in the popular game Mario Kart:

- **Rocket (Bullet Bill)**: Automatically hits all notes for a short period of time.
- **Mushroom**: Grants an instant 300 point bonus.
- **Banana**: Deducts 40 points from the player who collected the item.
- **Star**: Plays the song at 1.3x speed for a short period of time.
- **Golden Mushroom**: Grants a points multiplier for a short period of time.
- **Blooper**: Covers the screen with ink, making it difficult to see the lyrics and notes. This benefits players who know the song by heart.
- **Lightning**: Mutes the music for a short period of time.

This mode will add a fun and competitive element to MelodyMania, making it more enjoyable for players who want a more dynamic experience.

At the moment coins and bananas are implemented, with coins giving 100 points and bananas deducting 50 points.
The Shells dont have their functionality Yet

# Documentation

## Installation
1. Download the latest release `Source code (zip)` of the Skip Seconds Melody Mania Mod mod from the Releases page.
2. Extract the downloaded ZIP file to a location of your choice.
3. Mod folders are searched in a specific folder called the mods root folder.
4. The mods root folder can be found by executing the command `mod.path` in the game's console (open via `F7`).
5. To install a mod folder, copy it to the mods root folder
6. An app restart may be required afterwards.
7. Activate the Mod in the Game settings
## Usage
1. Launch Melody Mania.
2. Activate Mod
3. Activate Modifier Item Rumble in Modifier Settings (Top Right in Song Select Scene)
4. Start a song in the singing scene.
5. Collect Items by hiting the center of the note

## ItemActions Class

The `ItemActions` class is responsible for handling the actions related to game items. It is injected with various dependencies such as `GameObject`, `PlayerControl`, and `VisualElement` for the player's score label.

### Key Methods

- `AddScore(int points)`: This method is used to add points to the player's score. If the points are negative and the absolute value is greater than the player's total score, the method will return without making any changes. Otherwise, it adds the points to the player's total score and updates the UI.

- `BouncePlayerScoreLabel(float scale)`: This method is used to create a bounce animation on the player's score label. The scale parameter determines the size of the bounce.

- `AnimateItemCollection(ItemControl itemControl)`: This method is used to animate the collection of an item. It removes the item from the hierarchy and logs the name of the GameObject and the item.

- *More Actions and Animations can be implemented here*


## Items.cs Class

The `Items.cs` class is responsible for defining the items that can be collected in the game. Each item is an instance of the `Item` class, which has properties for the item's name, image path, visual element name, and a custom action that is executed when the item is collected.

### Adding New Items

To add a new item to the game, follow these steps:

1. Define a new `Item` instance in the `Items.cs` class. The `Item` constructor takes four parameters:
   - `name`: A string that defines the name of the item.
   - `imagePath`: A string that defines the path to the image that represents the item.
   - `visualElementName`: A string that defines the name of the visual element associated with the item.
   - `customAction`: An action that is executed when the item is collected. This action takes two parameters: an `itemActionsObject` and an `itemControlObject`. These should be cast to the `ItemActions` and `ItemControl` types, respectively, and used to define the behavior of the item when it is collected.

```csharp
public static readonly Item NewItem = new Item("NewItem", "images/items/newItem/newItem.png", "itemCollectorItem", (object itemActionsObject, object itemControlObject) =>
{
    // Cast the object to the correct type.
    var itemActions = (ItemActions)itemActionsObject;
    var itemControl = (ItemControl)itemControlObject;
    // Add Actions here.
    itemActions.AddScore(100);
    itemActions.BouncePlayerScoreLabel();
    itemActions.AnimateItemCollection(itemControl);
});
```

2. Add the new item to the AllItems list:
```csharp
public static readonly List<Item> AllItems = new List<Item>()
{
    Coin,
    Banana,
    NewItem
};
```
3. Ensure that the image for the new item is placed in the specified imagePath and that the visualElementName corresponds to a valid visual element in the game.

4. Implement the desired behavior for the item in the customAction delegate. This could involve adding or subtracting from the player's score, triggering animations, or any other game effects.
5. If `itemActions` does not have the desired Effect implement it in `ItemActions.cs`


# Acknowledgements

This project is based on the Coin Collect mod by [Andreas Achimmihca](https://github.com/achimmihca). 
