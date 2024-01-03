using UnityEngine.UIElements;
using System.Collections.Generic;
using UniInject;

class ItemRumbleGameRoundModifierControl : GameRoundModifierControl
{
    public string modFolder;

    [Inject]
    private SingSceneControl singSceneControl;

    [Inject]
    private UIDocument uiDocument;

    private List<ItemRumbleModPlayerControl> itemRumblePlayerControls = new List<ItemRumbleModPlayerControl>();

    private void Start()
    {
        AddStyleSheet();

        foreach (PlayerControl playerControl in singSceneControl.PlayerControls)
        {
            CreateItemCollectorControl(playerControl);
        }
    }

    private void AddStyleSheet()
    {
        string styleSheetPath = $"{modFolder}/stylesheets/ItemRumbleStyles.uss";
        StyleSheet styleSheet = StyleSheetUtils.CreateStyleSheetFromFile(styleSheetPath);
        uiDocument.rootVisualElement.styleSheets.Add(styleSheet);
    }

    /*     private void Update()
        {
            itemRumblePlayerControls.ForEach(it => it.Update());
        }
     */


    private void CreateItemCollectorControl(PlayerControl playerControl)
    {
        ItemRumbleModPlayerControl itemCollectorGameModifierPlayerControl = new ItemRumbleModPlayerControl();
        itemCollectorGameModifierPlayerControl.modFolder = modFolder;
        playerControl.PlayerUiControl.Injector.Inject(itemCollectorGameModifierPlayerControl);
        itemRumblePlayerControls.Add(itemCollectorGameModifierPlayerControl);
    }
}
