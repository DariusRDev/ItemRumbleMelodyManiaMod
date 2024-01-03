using UnityEngine;
using UnityEngine.UIElements;
using UniRx;
using System.Collections.Generic;
using System.Linq;
using UniInject;
using System;

public class ItemRumbleModPlayerControl : INeedInjection, IInjectionFinishedListener
{
    public string modFolder;

    private const int CollectedItemCountBonusThreshold = 10;

    [Inject]
    private GameObject gameObject;

    [Inject]
    private SingSceneControl singSceneControl;

    [Inject]
    private PlayerControl playerControl;

    [Inject]
    private Injector injector;

    [Inject(UxmlName = R.UxmlNames.playerImage)]
    private VisualElement playerImage;

    [Inject(UxmlName = R.UxmlNames.playerScoreLabel)]
    private VisualElement playerScoreLabel;

    private ItemActions itemActions;

    private List<ItemControl> itemControls = new List<ItemControl>();
    private List<RecordedNoteControl> recordedNoteControls = new List<RecordedNoteControl>();

    /*   private VisualElement itemCountContainer;
      private Label itemCountLabel; */
    /* 
        private int totalCollectedItemCount; */
    private int collectedItemCountSinceLastBonus;

    public void OnInjectionFinished()
    {

        playerControl.PlayerUiControl.NoteDisplayer.TargetNoteControlCreatedEventStream
            .Subscribe(evt => OnCreatedTargetNoteControl(evt.TargetNoteControl, playerControl))
            .AddTo(gameObject);

        playerControl.PlayerUiControl.NoteDisplayer.RecordedNoteControlCreatedEventStream
            .Subscribe(evt => OnCreatedRecordedNoteControl(evt.RecordedNoteControl, playerControl))
            .AddTo(gameObject);

        itemActions = new ItemActions();
        injector.Inject(itemActions);

    }


    public void Update()
    {
        List<RecordedNoteControl> recordedNoteControlsCopy = recordedNoteControls.ToList();
        foreach (RecordedNoteControl recordedNoteControl in recordedNoteControlsCopy)
        {
            UpdateRecordedNoteControl(recordedNoteControl);
        }
    }

    private void UpdateRecordedNoteControl(RecordedNoteControl recordedNoteControl)
    {
        double EndBeat = recordedNoteControl.EndBeat;
        int targetEndBeat = recordedNoteControl.RecordedNote.TargetNote.EndBeat;
        int targetStartBeat = recordedNoteControl.RecordedNote.TargetNote.StartBeat;
        int targetCenterBeat = targetStartBeat + (targetEndBeat - targetStartBeat) / 2;
        if (Math.Abs(targetCenterBeat - EndBeat) < 1)
        {
            CollectItem(recordedNoteControl);
        }
    }

    private void CollectItem(RecordedNoteControl recordedNoteControl)
    {
        if (recordedNoteControl == null)
        {
            return;
        }
        recordedNoteControls.Remove(recordedNoteControl);

        ItemControl itemControl = itemControls
            .FirstOrDefault(it => it.TargetNoteControl.Note.StartBeat == recordedNoteControl.RecordedNote.TargetNote.StartBeat
                                  && it.TargetNoteControl.Note.EndBeat == recordedNoteControl.RecordedNote.TargetNote.EndBeat);
        if (itemControl == null)
        {
            return;
        }


        itemControls.Remove(itemControl);


        itemControl.Item.OnCollect(itemActions, itemControl);

        /* UpdateItemsLabel(); */
    }



    private void OnCreatedTargetNoteControl(TargetNoteControl targetNoteControl, PlayerControl playerControl)
    {
        int pointsOfPlayer = playerControl.PlayerScoreControl.ModTotalScore;
        int pointsOfPlayerInFirst = singSceneControl.PlayerControls.Max(it => it.PlayerScoreControl.ModTotalScore);
        int pointsToFirstPlace = pointsOfPlayerInFirst - pointsOfPlayer;
        Debug.Log($"Point to First Place: {pointsToFirstPlace}");
        Item item = Items.SpawnItem(pointsToFirstPlace);
        ItemControl itemControl = new ItemControl(modFolder, targetNoteControl, item);
        itemControls.Add(itemControl);
    }

    private void OnCreatedRecordedNoteControl(RecordedNoteControl recordedNoteControl, PlayerControl playerControl)
    {
        if (recordedNoteControl.RecordedNote.TargetNote == null
            || recordedNoteControl.RecordedNote.RoundedMidiNote != recordedNoteControl.RecordedNote.TargetNote.MidiNote)
        {
            return;
        }

        recordedNoteControls.Add(recordedNoteControl);
    }
}
