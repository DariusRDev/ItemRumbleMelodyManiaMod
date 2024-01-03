

using System.Collections;
using SceneChangeAnimations;
using UniInject;
using UnityEngine;
using UnityEngine.Playables;
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
        if (points < 0 && playerControl.PlayerScoreControl.ModTotalScore < Mathf.Abs(points))
        {
            points = -playerControl.PlayerScoreControl.ModTotalScore;
            return;
        }
        else
        {

            playerControl.PlayerScoreControl.ModTotalScore += points;
        }

        playerControl.PlayerUiControl.ShowTotalScore(playerControl.PlayerScoreControl.TotalScore);

        Debug.Log($"Added {points} points to score of player '{playerControl.PlayerProfile?.Name}'");

        // Highlight with Animation

        /*         AnimationUtils.BounceVisualElementSize(gameObject, itemCountContainer, 1.5f);
         */
    }

    public void BouncePlayerScoreLabel(float scale = 1.5f)
    {
        AnimationUtils.BounceVisualElementSize(gameObject, playerScoreLabel, scale);

    }

    public void AnimateItemCollection(ItemControl itemControl)
    {
        Debug.Log($"GameObject: {gameObject.name}, ItemControl: {itemControl.Item.Name}");
        // TriggerSparklyExplosion(itemControl.VisualElement.transform.position);
        // TODO: Help Wanted
        itemControl.VisualElement.RemoveFromHierarchy();
        //AnimationUtils.FadeOutThenRemoveVisualElementCoroutine(itemControl.VisualElement, 0, 0.5f);
    }


}
