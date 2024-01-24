using UniInject;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemControl
{

    [Inject]
    private SingSceneControl singSceneControl;
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
        visualElement.name = "CollectorItemContainer";

        VisualElement itemVE = new VisualElement();
        itemVE.name = item.VisualElementName;
        ImageManager.LoadSpriteFromUri($"{modFolder}/{item.ImagePath}")
            .Subscribe(sprite => itemVE.style.backgroundImage = new StyleBackground(sprite));
        visualElement.Add(itemVE);
        targetNoteControl.VisualElement.Add(visualElement);
    }

    public void fadeInBackground(Color32 color, float duration, GameObject gameObject)
    {
        // use a of color to make the background visible
        color.a = 0;

        visualElement.style.backgroundColor = new StyleColor(color);

        LeanTween.value(gameObject, 0, 255, duration)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnUpdate((float value) =>
            {
                color.a = (byte)value;
                visualElement.style.backgroundColor = new StyleColor(color);
            });


    }

    public void OnObsolete()
    {
        targetNoteControl.VisualElement.Remove(visualElement);
    }
}

