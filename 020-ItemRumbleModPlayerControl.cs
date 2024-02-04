using UniRx;
using System.Collections.Generic;
using System.Linq;
using UniInject;
using System;

public class ItemRumbleModPlayerControl : INeedInjection, IInjectionFinishedListener
{
    [Inject]
    private SingSceneControl singSceneControl;

    [Inject]
    private PlayerControl playerControl;

    [Inject]
    private Injector injector;

    [Inject]
    private PlayerScoreControl playerScoreControl;
    private ItemActions itemActions;

    private List<ItemControl> itemControls = new List<ItemControl>();
    private List<RecordedNoteControl> recordedNoteControls = new List<RecordedNoteControl>();

    private List<Item> activeItems = new List<Item>();

    public ModObjectContext modContext;

    public ItemRumbleModModSettings modSettings;
    private List<IDisposable> subscriptions = new List<IDisposable>();

    private Items items;

    public void OnInjectionFinished()
    {
        var subscription1 = playerControl.PlayerUiControl.NoteDisplayer.TargetNoteControlCreatedEventStream
            .Subscribe(evt => OnCreatedTargetNoteControl(evt.TargetNoteControl, playerControl));
        subscriptions.Add(subscription1);

        var subscription2 = playerControl.PlayerUiControl.NoteDisplayer.RecordedNoteControlCreatedEventStream
            .Subscribe(evt => OnCreatedRecordedNoteControl(evt.RecordedNoteControl, playerControl));
        subscriptions.Add(subscription2);

        var subscription3 = playerScoreControl.NoteScoreEventStream.Subscribe(noteScoreEvent =>
        {
            if (noteScoreEvent.NoteScore.IsPerfect)
            {
                CollectItem(noteScoreEvent.NoteScore.Note.StartBeat, noteScoreEvent.NoteScore.Note.EndBeat);
            }
        });


        itemActions = new ItemActions();
        injector.Inject(itemActions);
        activeItems = Items.AllItems.Where(it => modSettings.activeItemList.Contains(it.Name)).ToList();
        items = new Items(modContext, modSettings);
    }

    public void OnObsolete()
    {
        foreach (var subscription in subscriptions)
        {
            subscription.Dispose();
        }

        itemControls.ForEach(it => it.OnObsolete());
    }


    public void Update()
    {
        if (modSettings.collectOnPerfectNote)
        {
            return;
        }
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
        if (Math.Abs(targetCenterBeat - EndBeat) < 1 && false)
        {
            CollectItem(recordedNoteControl);
        }

        if (EndBeat < (double)recordedNoteControl.TargetEndBeat && recordedNoteControl.RecordedNote != null && recordedNoteControl.RecordedNote.TargetNote != null && recordedNoteControl.MidiNote == recordedNoteControl.RecordedNote.TargetNote.MidiNote)
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


        CollectItem(recordedNoteControl.RecordedNote.TargetNote.StartBeat, recordedNoteControl.RecordedNote.TargetNote.EndBeat);
    }

    private void CollectItem(int StartBeat, int EndBeat)
    {


        ItemControl itemControl = itemControls
            .FirstOrDefault(it => it.TargetNoteControl.Note.StartBeat == StartBeat
                                  && it.TargetNoteControl.Note.EndBeat == EndBeat);
        if (itemControl == null)
        {
            return;
        }


        itemControls.Remove(itemControl);


        itemControl.Item.OnCollect(itemActions, itemControl);

    }



    private void OnCreatedTargetNoteControl(TargetNoteControl targetNoteControl, PlayerControl playerControl)
    {
        int pointsOfPlayer = playerControl.PlayerScoreControl.scoreData.TotalScore;
        int pointsOfPlayerInFirst = singSceneControl.PlayerControls.Max(it => it.PlayerScoreControl.scoreData.TotalScore);
        int pointsToFirstPlace = Math.Abs(pointsOfPlayerInFirst - pointsOfPlayer);


        int noteLengthInMilliseconds = (int)(targetNoteControl.Note.Length * 60000 / singSceneControl.SongMeta.BeatsPerMinute);
        if (noteLengthInMilliseconds < 150) // Don't spawn items if the note is too short
        {
            return;
        }
        double percentageToSpawnItem = modSettings.percentChanceToSpawnItem;
        bool spawnItem = UnityEngine.Random.Range(0, 100) < percentageToSpawnItem;

        if (!spawnItem) // Only spawn items in 25% of the cases
        {
            return;
        }
        Item item = items.SpawnItem(pointsToFirstPlace, activeItems);
        ItemControl itemControl = new ItemControl(modContext.ModFolder, targetNoteControl, item);
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
