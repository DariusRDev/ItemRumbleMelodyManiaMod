using System;
using System.Collections.Generic;
using UniInject;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemRumbleModSceneMod : IGameRoundMod
{

    [Inject]
    private ModObjectContext modObjectContext;

    public List<Item> activeItems = new List<Item>();


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
        var label = new Label("Item Rumble Mod Settings");
        label.style.fontSize = 10;
        visualElement.Add(label);
        StyleColor grey = new StyleColor();
        grey.value = new Color(0.5f, 0.5f, 0.5f, 1f);
        var divider = new VisualElement();
        divider.style.height = 1;

        divider.style.backgroundColor = grey; //grey
        visualElement.Add(divider);

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
            var itemLabel = new Label(item.Description);
            itemLabel.style.fontSize = 7;
            visualElement.Add(itemLabel);
            var itemDivider = new VisualElement();
            itemDivider.style.height = 1;
            itemDivider.style.backgroundColor = grey; //grey
            visualElement.Add(itemDivider);
        }

        // divider:






        return visualElement;


    }
}

