using System;
using System.Collections.Generic;
using UniInject;
using UnityEngine;
using UnityEngine.UIElements;
using UniRx;

public class ItemRumbleModSceneMod : IGameRoundMod
{

    [Inject]
    private ModObjectContext modObjectContext;

    public List<String> activeItems = new List<String>();

    [Inject]
    private ItemRumbleModModSettings modSettings;

    public string DisplayName => "Item Rumble";

    public double DisplayOrder => 0;

    public bool myBool = true;


    public GameRoundModifierControl CreateControl()
    {
        ItemRumbleGameRoundModifierControl control = GameObjectUtils.CreateGameObjectWithComponent<ItemRumbleGameRoundModifierControl>();
        control.modFolder = modObjectContext.ModFolder;
        control.activeItemNames = modSettings.activeItemList;
        return control;

    }

    public VisualElement CreateConfigurationVisualElement()
    {
        modSettings.myBool = !myBool;
        activeItems = new List<String>(modSettings.activeItemList.Split(','));

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

            var row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            var image = new VisualElement();
            image.name = item.VisualElementName;
            image.style.width = 25;
            image.style.height = 25;
            ImageManager.LoadSpriteFromUri($"{modObjectContext.ModFolder}/{item.ImagePath}")
                .Subscribe(sprite => image.style.backgroundImage = new StyleBackground(sprite));
            row.Add(image);
            // create a checkbox for each item
            IModSettingControl checkbox = new BoolModSettingControl(() => activeItems.Contains(item.Name), newValue =>
            {
                if (newValue)
                {
                    activeItems.Add(item.Name);
                }
                else
                {
                    activeItems.Remove(item.Name);
                }
                modSettings.activeItemList = string.Join(",", activeItems);
            })
            { Label = item.Name };
            row.Add(checkbox.CreateVisualElement());

            visualElement.Add(row);

            var itemLabel = new Label(item.Description);
            itemLabel.style.fontSize = 7;
            visualElement.Add(itemLabel);
            var itemDivider = new VisualElement();
            itemDivider.style.height = 1;
            itemDivider.style.backgroundColor = grey; //grey
            visualElement.Add(itemDivider);
        }


        return visualElement;


    }
}

