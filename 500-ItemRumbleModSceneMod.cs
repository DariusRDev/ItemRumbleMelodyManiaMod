using System;
using System.Collections.Generic;
using UniInject;
using UnityEngine;
using UnityEngine.UIElements;
using UniRx;
using System.IO;

public class ItemRumbleModSceneMod : IGameRoundMod, IOnModInstanceBecomesObsolete
{

    [Inject]
    private ModObjectContext modContext;

    [Inject]
    private ItemRumbleModModSettings modSettings;

    [Inject]
    private UiManager uiManager;


    public List<String> activeItems = new List<String>();



    public string DisplayName => "Item Rumble";

    public double DisplayOrder => 0;


    private ItemRumbleGameRoundModifierControl control;
    public GameRoundModifierControl CreateControl()
    {
        control = GameObjectUtils.CreateGameObjectWithComponent<ItemRumbleGameRoundModifierControl>();
        control.modContext = modContext;
        control.itemRumbleModModSettings = modSettings;
        return control;

    }

    private void OnObsolete()
    {
        control.OnObsolete();
        GameObjectUtils.Destroy(control);
        // destroy this

    }


    public VisualElement CreateConfigurationVisualElement()
    {
        activeItems = new List<String>(modSettings.activeItemList.Split(','));

        var visualElement = new VisualElement();
        var label = new Label("Item Rumble Mod Settings");
        label.style.fontSize = 10;
        visualElement.Add(label);
        var label2 = new Label("Consider Contributing to the Mod on Github!");
        label2.style.fontSize = 7;
        visualElement.Add(label2);
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
            row.style.flexGrow = 1;
            row.style.justifyContent = Justify.SpaceBetween;

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
            var image = new VisualElement();
            image.name = item.VisualElementName;
            image.style.width = 25;
            image.style.height = 25;
            ImageManager.LoadSpriteFromUri($"{modContext.ModFolder}/{item.ImagePath}")
                .Subscribe(sprite => image.style.backgroundImage = new StyleBackground(sprite));
            row.Add(image);
            visualElement.Add(row);

            var itemLabel = new Label(item.Description);
            itemLabel.style.fontSize = 7;
            visualElement.Add(itemLabel);
            var itemDivider = new VisualElement();
            itemDivider.style.height = 1;
            itemDivider.style.backgroundColor = grey; //grey
            visualElement.Add(itemDivider);
        }

        Button probChangeHelpButton = new Button(() =>
        {
            uiManager.CreateInfoDialogControl("Editing Spawn Probabilities",
                "Spawn probabilities are stored in a CSV file. The first column is the distance to the leading player. After that each column represents the probability for the item at the corresponding distance. The file is located in the mod folder. You can open it with Excel or any text editor.");
        });
        probChangeHelpButton.text = "How to Edit Spawn Probabilities?";
        probChangeHelpButton.AddToClassList("my-2");
        visualElement.Add(probChangeHelpButton);

        Button openProbFileButton = new Button(() =>
        {
            Application.OpenURL(Path.Combine(modContext.ModPersistentDataFolder, "SpawnProbabilities.csv"));
        });
        openProbFileButton.text = "Edit Spawn Probabilities (Excel CSV)";

        visualElement.Add(openProbFileButton);

        return visualElement;
    }

    public void OnModInstanceBecomesObsolete()
    {
        try
        {
            OnObsolete();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}

