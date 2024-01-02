

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

    public void AddScore(int points)
    {
        playerControl.PlayerScoreControl.ModTotalScore += points;
        playerControl.PlayerUiControl.ShowTotalScore(playerControl.PlayerScoreControl.TotalScore);

        Debug.Log($"Added {points} points to score of player '{playerControl.PlayerProfile?.Name}'");

        // Highlight with Animation

        /*         AnimationUtils.BounceVisualElementSize(gameObject, itemCountContainer, 1.5f);
         */
        AnimationUtils.BounceVisualElementSize(gameObject, playerScoreLabel, 1.5f);
    }
}
