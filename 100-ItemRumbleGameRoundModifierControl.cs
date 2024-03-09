using UnityEngine.UIElements;
using System.Collections.Generic;
using UniInject;
using UnityEngine;
using System;

class ItemRumbleGameRoundModifierControl : GameRoundModifierControl
{

    [Inject]
    private SingSceneControl singSceneControl;

    [Inject]
    private UIDocument uiDocument;

    public ModObjectContext modContext;

    public ItemRumbleModModSettings itemRumbleModModSettings;

    private List<ItemRumbleModPlayerControl> itemRumblePlayerControls = new List<ItemRumbleModPlayerControl>();

    private void Start()
    {
        AddStyleSheet();

        foreach (PlayerControl playerControl in singSceneControl.PlayerControls)
        {
            CreateItemCollectorControl(playerControl);
        }
        StartAnimation();
    }

    private void StartAnimation()
    {
        VisualElement modalBackground = new VisualElement();
        modalBackground.style.position = Position.Absolute;
        modalBackground.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0.7f));
        modalBackground.style.left = 0f;
        modalBackground.style.right = 0f;
        modalBackground.style.top = 0f;
        modalBackground.style.bottom = 0f;
        modalBackground.style.height = singSceneControl.background.layout.height;
        modalBackground.style.width = singSceneControl.background.layout.width;
        modalBackground.style.opacity = 0f;
        uiDocument.rootVisualElement.Add(modalBackground);
        Fade(modalBackground, 0.7f, null, true);


        LeanTween.delayedCall(0.2f, () =>
        {

            float centerPosition = singSceneControl.background.layout.width / 2;

            Label rumbleLabel = new Label("Rumbles");
            rumbleLabel.style.fontSize = 100;
            rumbleLabel.style.position = Position.Absolute;
            rumbleLabel.style.left = -singSceneControl.background.layout.width; // Start from the left
            rumbleLabel.style.bottom = new Length(20f, LengthUnit.Percent);
            rumbleLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            // make it comic sans
            rumbleLabel.style.unityFont = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 80);

            rumbleLabel.style.color = new StyleColor(Color.yellow);

            Label itemLabel = new Label("Item");
            itemLabel.style.fontSize = 130;
            itemLabel.style.position = Position.Absolute;
            itemLabel.style.right = -singSceneControl.background.layout.width; // Start from the left
            itemLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            itemLabel.style.unityFont = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 80);
            itemLabel.style.top = new Length(20f, LengthUnit.Percent);
            itemLabel.style.color = new StyleColor(Color.blue);




            uiDocument.rootVisualElement.Add(rumbleLabel);
            uiDocument.rootVisualElement.Add(itemLabel);

            // Move the labels to the center
            LeanTween.value(singSceneControl.gameObject, rumbleLabel.layout.x, centerPosition, 1f).setOnUpdate((float val) =>
            {
                rumbleLabel.style.left = val;
            }).setEaseSpring().setOnComplete(() =>
            {
                LeanTween.delayedCall(0.2f, () =>
                {
                    Fade(rumbleLabel, 0.2f, () =>
                    {
                        rumbleLabel.RemoveFromHierarchy();
                    });
                });
            });

            LeanTween.value(singSceneControl.gameObject, itemLabel.layout.x, centerPosition, 1f).setOnUpdate((float val) =>
            {
                itemLabel.style.right = val + 25;
            }).setEaseSpring().setOnComplete(() =>
            {
                LeanTween.delayedCall(0.2f, () =>
                {
                    Fade(itemLabel, 0.2f, () =>
                    {
                        itemLabel.RemoveFromHierarchy();
                    });
                    Fade(modalBackground, 0.5f, () =>
                    {
                        modalBackground.RemoveFromHierarchy();
                    });
                });

            });
        });
    }

    private void Fade(VisualElement visualElementToAnimate, float durationInS, Action callback, bool fadeIn = false)
    {
        // Starten Sie den Tween, um die Opazität von 1 auf 0 zu ändern
        LeanTween.value(singSceneControl.gameObject, fadeIn ? 0f : 1f, fadeIn ? 1f : 0f, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.opacity = val;
        }).setOnComplete(() =>
        {
            visualElementToAnimate.style.opacity = fadeIn ? 1f : 0f;
            callback?.Invoke();
        });
    }

    private void AddStyleSheet()
    {
        string styleSheetPath = $"{modContext.ModFolder}/stylesheets/ItemRumbleStyles.uss";
        StyleSheet styleSheet = StyleSheetUtils.CreateStyleSheetFromFile(styleSheetPath);
        uiDocument.rootVisualElement.styleSheets.Add(styleSheet);
    }

    private void Update()
    {
        itemRumblePlayerControls.ForEach(it => it.Update());
    }

    public void OnObsolete()
    {
        itemRumblePlayerControls.ForEach(it => it.OnObsolete());
    }

    private void CreateItemCollectorControl(PlayerControl playerControl)
    {
        ItemRumbleModPlayerControl itemCollectorGameModifierPlayerControl = new ItemRumbleModPlayerControl();
        itemCollectorGameModifierPlayerControl.modContext = modContext;
        itemCollectorGameModifierPlayerControl.modSettings = itemRumbleModModSettings;
        playerControl.PlayerUiControl.Injector.Inject(itemCollectorGameModifierPlayerControl);
        itemRumblePlayerControls.Add(itemCollectorGameModifierPlayerControl);
    }
}
