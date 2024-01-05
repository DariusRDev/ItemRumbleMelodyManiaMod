

using System;
using System.Collections;
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

    [Inject(UxmlName = R.UxmlNames.commonScoreSentenceRatingContainer)]
    private VisualElement commonScoreSentenceRatingContainer;

    public void AddScore(int points)
    {
        if (points < 0 && playerControl.PlayerScoreControl.ModTotalScore < Mathf.Abs(points))
        {
            return;
        }
        playerControl.PlayerScoreControl.ModTotalScore += points;
        playerControl.PlayerUiControl.ShowTotalScore(playerControl.PlayerScoreControl.TotalScore);

        Debug.Log($"Added {points} points to score of player '{playerControl.PlayerProfile?.Name}'");
    }

    public void BouncePlayerScoreLabel(float scale = 1.5f)
    {
        AnimationUtils.BounceVisualElementSize(gameObject, playerScoreLabel, scale);

    }

    public void AnimateItemCollection(ItemControl itemControl)
    {

        singSceneControl.StartCoroutine(MoveToScore(itemControl.VisualElement, playerScoreLabel, 0.4f, () =>
        {
            singSceneControl.StartCoroutine(FadeOut(itemControl.VisualElement, 0.2f, () =>
            {
                itemControl.VisualElement.RemoveFromHierarchy();
                ShowItemRating("+100 COIN");
            }));
        }));


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

    private IEnumerator MoveToScore(VisualElement visualElementToAnimate, VisualElement targetElement, float durationInS, Action callback)
    {
        float elapsed = 0f;
        Vector2 startPosition = visualElementToAnimate.worldBound.position;
        Vector2 endPosition = targetElement.worldBound.position;
        // Move the visual element to the background so that it is not affected by Parents layouting.
        visualElementToAnimate.RemoveFromHierarchy();
        singSceneControl.background.Add(visualElementToAnimate);
        Vector2 parentPosition = singSceneControl.background.worldBound.position;
        startPosition -= parentPosition;
        endPosition -= parentPosition;

        while (elapsed < durationInS)
        {
            float t = elapsed / durationInS;
            Vector2 newPosition = Vector2.Lerp(startPosition, endPosition, t);
            visualElementToAnimate.style.left = newPosition.x;
            visualElementToAnimate.style.top = newPosition.y;
            elapsed += Time.deltaTime;
            yield return null;
        }
        visualElementToAnimate.style.left = endPosition.x;
        visualElementToAnimate.style.top = endPosition.y;

        callback?.Invoke();
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
