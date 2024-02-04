using UnityEngine.UIElements;
using System.Collections.Generic;
using UniInject;

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
