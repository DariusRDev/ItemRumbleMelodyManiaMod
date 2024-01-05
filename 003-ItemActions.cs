

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniInject;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemActions : INeedInjection
{


    [Inject]
    private GameObject gameObject;

    [Inject]
    private PlayerControl playerControl;

    [Inject(UxmlName = R.UxmlNames.playerScoreLabel)]
    private VisualElement playerScoreLabel;

    [Inject]
    private SingSceneControl singSceneControl;

    [Inject(Key = nameof(sentenceRatingUi))]
    private VisualTreeAsset sentenceRatingUi;


    public void AddScore(PlayerControl targetPlayerControl, int points)
    {
        if (points < 0 && targetPlayerControl.PlayerScoreControl.ModTotalScore < Mathf.Abs(points))
        {
            return;
        }
        targetPlayerControl.PlayerScoreControl.ModTotalScore += points;
        targetPlayerControl.PlayerUiControl.ShowTotalScore(targetPlayerControl.PlayerScoreControl.TotalScore);

        Debug.Log($"Added {points} points to score of player '{targetPlayerControl.PlayerProfile?.Name}'");
    }

    public void BouncePlayerScoreLabel(PlayerControl targetPlayerControl, float scale = 1.5f)
    {
        AnimationUtils.BounceVisualElementSize(gameObject, getPlayerScoreLabel(targetPlayerControl), scale);

    }

    public void AnimateItemCollection(PlayerControl targetPlayerControl, ItemControl itemControl, String onCollectText)
    {

        // find in tree VisualElement == "playerScoreLabel"
        MoveToScore(itemControl.VisualElement, getPlayerScoreLabel(targetPlayerControl), 0.4f, () =>
                {
                    singSceneControl.StartCoroutine(FadeOut(itemControl.VisualElement, 0.2f, () =>
                    {
                        itemControl.VisualElement.RemoveFromHierarchy();
                        ShowItemRating(onCollectText);
                    }));
                });


    }

    public PlayerControl GetRandomPlayerControl()
    {
        List<PlayerControl> playerControls = singSceneControl.PlayerControls;
        return playerControls[UnityEngine.Random.Range(0, playerControls.Count)];
    }

    public PlayerControl GetFirstPlacePlayerControl()
    {
        List<PlayerControl> playerControls = singSceneControl.PlayerControls;
        return playerControls.OrderByDescending(pc => pc.PlayerScoreControl.TotalScore).First();
    }

    public PlayerControl GetInFrontOfMePlayerControl()
    {
        List<PlayerControl> playerControls = singSceneControl.PlayerControls;
        int myPoints = playerControl.PlayerScoreControl.TotalScore;
        return playerControls
                .Where(pc => pc.PlayerScoreControl.TotalScore > myPoints)
                .OrderBy(pc => pc.PlayerScoreControl.TotalScore).First();
    }

    public PlayerControl GetMyPlayerControll()
    {
        return playerControl;
    }

    private VisualElement getPlayerScoreLabel(PlayerControl targetPlayerControl)
    {
        String playerName = targetPlayerControl.PlayerProfile.Name;

        List<VisualElement> playerInfoContainer = singSceneControl.background.Query<VisualElement>().Where(ve => ve.name == "playerNameContainer").ToList();
        foreach (VisualElement ve in playerInfoContainer)
        {
            Label playerNameLabel = ve.Query<Label>().Where(label => label.name == "playerNameLabel").First();

            if (playerNameLabel.text == playerName)
            {
                return ve.Query<VisualElement>().Where(ves => ves.name == "playerScoreLabel").First();
            }
        }

        return playerScoreLabel;

    }




    // Ripped from ShowSentenceRating
    // Displays at the Same Position as the SentenceRating ("great", "good", "bad", "perfect")
    public VisualElement ShowItemRating(String text)
    {
        VisualElement label = new Label("      " + text);

        label.style.position = Position.Absolute;
        // visualElement.style.unityBackgroundImageTintColor = new StyleColor(sentenceRatingColors[sentenceRating.EnumValue]);

        Vector2 positionOfScore = playerScoreLabel.worldBound.position;
        // Move the visual element to the background so that it is not affected by Parents layouting.

        singSceneControl.background.Add(label);
        Vector2 parentPosition = singSceneControl.background.worldBound.position;
        positionOfScore -= parentPosition;
        label.style.left = positionOfScore.x + 20;
        label.style.top = positionOfScore.y;


        float fromValue = 0;
        float untilValue = 20;

        LeanTween.value(singSceneControl.gameObject, fromValue, untilValue, 1f)
            .setEaseInSine()
            .setOnUpdate(interpolatedValue =>
            {
                // Set Position so it goes upwards
                label.style.top = positionOfScore.y - interpolatedValue;

            })
            .setOnComplete(label.RemoveFromHierarchy);
        return label;
    }

    private void MoveToScore(VisualElement visualElementToAnimate, VisualElement targetElement, float durationInS, Action callback)
    {
        Vector2 startPosition = visualElementToAnimate.worldBound.position;
        Vector2 endPosition = targetElement.worldBound.position;

        // Move the visual element to the background so that it is not affected by Parents layouting.
        visualElementToAnimate.RemoveFromHierarchy();
        singSceneControl.background.Add(visualElementToAnimate);
        Vector2 parentPosition = singSceneControl.background.worldBound.position;
        startPosition -= parentPosition;
        endPosition -= parentPosition;

        // Set the initial position
        visualElementToAnimate.style.left = startPosition.x;
        visualElementToAnimate.style.top = startPosition.y;

        // Start the tween
        LeanTween.value(singSceneControl.gameObject, startPosition.x, endPosition.x, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.left = val + UnityEngine.Random.Range(0, 10);

        }).setEaseInSine().setOnComplete(() =>
        {
            visualElementToAnimate.style.left = endPosition.x;
        });

        LeanTween.value(singSceneControl.gameObject, startPosition.y, endPosition.y, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.top = val + UnityEngine.Random.Range(0, 10);
        }).setEaseInSine().setOnComplete(() =>
        {
            visualElementToAnimate.style.top = endPosition.y;
            callback?.Invoke();
        });
    }

    private IEnumerator FadeOut(VisualElement visualElementToAnimate, float durationInS, Action callback)
    {
        float elapsed = 0f;
        while (elapsed < durationInS)
        {
            float t = elapsed / durationInS;
            visualElementToAnimate.style.opacity = Mathf.Lerp(1f, 0.0001f, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        visualElementToAnimate.style.opacity = 0f;

        callback?.Invoke();
    }
}
