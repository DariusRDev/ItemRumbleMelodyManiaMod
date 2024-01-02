using UniRx;
using UnityEngine.UIElements;

public class ItemControl
{
    public Item Item { get; private set; }
    private readonly TargetNoteControl targetNoteControl;
    public TargetNoteControl TargetNoteControl => targetNoteControl;

    private readonly VisualElement visualElement;
    public VisualElement VisualElement => visualElement;

    public ItemControl(string modFolder, TargetNoteControl targetNoteControl, Item item)
    {
        this.targetNoteControl = targetNoteControl;
        this.Item = item;
        this.visualElement = new VisualElement();
        visualElement.name = item.VisualElementName;
        ImageManager.LoadSpriteFromUri($"{modFolder}/{item.ImagePath}")
            .Subscribe(sprite => visualElement.style.backgroundImage = new StyleBackground(sprite));

        targetNoteControl.VisualElement.Add(visualElement);
    }
}
