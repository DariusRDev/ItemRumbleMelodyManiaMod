using System;
using System.Collections.Generic;
using UniInject;
using UnityEngine;
using UnityEngine.UIElements;

// Mod interface to do something when a scene is loaded.
// Available scenes are found in the EScene enum.
public class ItemRumbleModSceneMod : IGameRoundMod
{
    // Get common objects from the app environment via Inject attribute.
    [Inject]
    private UIDocument uiDocument;

    [Inject]
    private SceneNavigator sceneNavigator;

    // Mod settings implement IAutoBoundMod, which makes an instance available via Inject attribute
    [Inject]
    private ItemRumbleModModSettings modSettings;

    [Inject]
    private ModObjectContext modObjectContext;

    public List<Item> activeItems = new List<Item>();

    private readonly List<IDisposable> disposables = new List<IDisposable>();

    public string DisplayName => "Item Rumble";

    public double DisplayOrder => 0;

    public bool myBool = true;


    public GameRoundModifierControl CreateControl()
    {
        ItemRumbleGameRoundModifierControl control = GameObjectUtils.CreateGameObjectWithComponent<ItemRumbleGameRoundModifierControl>();
        control.modFolder = modObjectContext.ModFolder;
        return control;

    }

    public VisualElement CreateConfigurationVisualElement()
    {


        var visualElement = new VisualElement();
        visualElement.Add(new Label("Active Items Rumble"));


        foreach (Item item in Items.AllItems)
        {
            // create a checkbox for each item
            IModSettingControl checkbox = new BoolModSettingControl(() => activeItems.Contains(item), newValue =>
            {
                if (newValue)
                {
                    activeItems.Add(item);
                }
                else
                {
                    activeItems.Remove(item);
                }
            })
            { Label = item.Name };
            visualElement.Add(checkbox.CreateVisualElement());
        }


        return visualElement;


    }
}

