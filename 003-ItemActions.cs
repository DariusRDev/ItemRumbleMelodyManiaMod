

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

    [Inject(Optional = true)]
    private MicProfile micProfile;

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

    public void DisableLyricsForSeconds(float seconds)
    {
        singSceneControl.FadeOutLyrics(playerControl.Voice, 0.8f);
        LeanTween.delayedCall(seconds + 1.6f, () =>
        {
            singSceneControl.FadeInLyrics(playerControl.Voice, .8f);
        });
    }

    public void MuteAudio(float seconds)
    {
        LeanTween.value(singSceneControl.gameObject, 1f, 0f, 0.5f).setOnUpdate((float val) =>
        {
            singSceneControl.songAudioPlayer.VolumeFactor = val;
        });

        LeanTween.delayedCall(seconds, () =>
        {
            LeanTween.value(singSceneControl.gameObject, 0f, 1f, 0.5f).setOnUpdate((float val) =>
            {
                singSceneControl.songAudioPlayer.VolumeFactor = val;
            });
        });
    }

    public void ChangePlaybackSpeed(float seconds, float speedFactor = 1.5f)
    {
        LeanTween.value(singSceneControl.gameObject, 1f, speedFactor, 0.5f).setOnUpdate((float val) =>
        {
            singSceneControl.songAudioPlayer.PlaybackSpeed = val;
            singSceneControl.songVideoPlayer.PlaybackSpeed = val;
        });

        LeanTween.delayedCall(seconds, () =>
        {
            LeanTween.value(singSceneControl.gameObject, speedFactor, 1f, 0.5f).setOnUpdate((float val) =>
            {
                singSceneControl.songAudioPlayer.PlaybackSpeed = val;
                singSceneControl.songVideoPlayer.PlaybackSpeed = val;
            });
        });
    }

    public void HideNotesForSeconds(float seconds)
    {
        LeanTween.delayedCall(seconds + 1.6f, () =>
        {
            playerControl.PlayerUiControl.NoteDisplayer.FadeIn(0.8f);
        });
        playerControl.PlayerUiControl.NoteDisplayer.FadeOut(0.8f);
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
                    FadeOut(itemControl.VisualElement, 0.2f, () =>
                    {
                        itemControl.VisualElement.RemoveFromHierarchy();
                        ShowItemRating(targetPlayerControl, onCollectText);
                    });
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

    public void rotateScreen(float seconds)
    {
        VisualElement visualElementToRotate = singSceneControl.background;
        float fromValue = 0;
        float untilValue = 360;

        LeanTween.value(singSceneControl.gameObject, fromValue, untilValue, seconds)
            .setEaseInSine()
           .setOnUpdate(interpolatedValue =>
        {
            visualElementToRotate.transform.rotation = Quaternion.Euler(0, 0, interpolatedValue);
        })
        .setOnComplete(() =>
        {
            visualElementToRotate.transform.rotation = Quaternion.Euler(0, 0, untilValue);
        });
    }

    public void shakeScreen(float seconds, float intensity)
    {
        // randomly shake screen for seconds between two values and randomly long
        VisualElement visualElementToShake = singSceneControl.background;
        Vector3 originalPosition = visualElementToShake.transform.position;
        Quaternion originalRotation = visualElementToShake.transform.rotation;
        // shake motion on x y and rotation
        float timeToShake = UnityEngine.Random.Range(0.1f, seconds > 0.4f ? 0.4f : seconds);
        LeanTween.value(singSceneControl.gameObject, 0, 1, timeToShake)
             .setOnUpdate((float val) =>
             {
                 // Randomly change position and rotation
                 float randomX = UnityEngine.Random.Range(-intensity, intensity);
                 float randomY = UnityEngine.Random.Range(-intensity, intensity);
                 float randomRotation = UnityEngine.Random.Range(-intensity, intensity);

                 visualElementToShake.transform.position = originalPosition + new Vector3(randomX, randomY, 0);
                 visualElementToShake.transform.rotation = Quaternion.Euler(0, 0, randomRotation);
             })
             .setOnComplete(() =>
             {
                 // Reset position and rotation
                 visualElementToShake.transform.position = originalPosition;
                 visualElementToShake.transform.rotation = Quaternion.Euler(0, 0, 0);
                 if (seconds - timeToShake > 0)
                 {

                     shakeScreen(seconds - timeToShake, intensity);
                 }
             });


    }




    // Ripped from ShowSentenceRating
    // Displays at the Same Position as the SentenceRating ("great", "good", "bad", "perfect")
    public VisualElement ShowItemRating(PlayerControl targetPlayerControll, string text)
    {
        VisualElement label = new Label(text);

        label.style.position = Position.Absolute;
        if (micProfile != null)
        {
            label.style.backgroundColor = new StyleColor(micProfile.Color);
        }
        label.style.marginLeft = 19;
        label.style.paddingBottom = 5;
        label.style.paddingTop = 5;
        label.style.paddingLeft = 5;
        label.style.paddingRight = 5;
        label.style.borderTopLeftRadius = 8;
        label.style.borderTopRightRadius = 8;
        label.style.borderBottomLeftRadius = 8;
        label.style.borderBottomRightRadius = 8;
        VisualElement targetPlayerScoreLabel = getPlayerScoreLabel(targetPlayerControll);
        Vector2 positionOfScore = targetPlayerScoreLabel.worldBound.position;
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
    public void MoveToCenterAndFadeOut(ItemControl itemControl, PlayerControl targetPlayerControl, float durationInS, Action callback)
    {


        VisualElement visualElementToAnimate = itemControl.VisualElement;
        Vector2 startPosition = visualElementToAnimate.worldBound.position;
        Vector2 endPosition = new Vector2(singSceneControl.background.layout.width / 2, singSceneControl.background.layout.height / 2);

        // Move the visual element to the background so that it is not affected by Parents layouting.
        visualElementToAnimate.RemoveFromHierarchy();
        singSceneControl.background.Add(visualElementToAnimate);
        Vector2 parentPosition = singSceneControl.background.worldBound.position;
        startPosition -= parentPosition;
        endPosition -= parentPosition;

        // Set the initial position
        visualElementToAnimate.style.left = startPosition.x;
        visualElementToAnimate.style.top = startPosition.y;

        LeanTween.delayedCall(durationInS / 2, () =>
        {
            if (micProfile != null)
            {
                itemControl.fadeInBackground(micProfile.Color, 0.18f + durationInS / 2.1f, singSceneControl.gameObject);
            }
        });

        // Start the tween
        LeanTween.value(singSceneControl.gameObject, startPosition.x, endPosition.x, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.left = val;

        }).setEaseInSine().setOnComplete(() =>
        {
            visualElementToAnimate.style.left = endPosition.x;
        });

        int widthAndHeight = 400;
        LeanTween.value(singSceneControl.gameObject, visualElementToAnimate.style.width.value.value, widthAndHeight, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.width = val;
            visualElementToAnimate.style.marginLeft = val / -2;
            visualElementToAnimate.style.height = val;
            visualElementToAnimate.style.marginTop = val / -2;

        }).setEaseOutSine().setOnComplete(() =>
        {
            visualElementToAnimate.style.width = widthAndHeight;
            visualElementToAnimate.style.marginLeft = widthAndHeight / -2;
            visualElementToAnimate.style.height = widthAndHeight;
            visualElementToAnimate.style.marginTop = widthAndHeight / -2;
        });


        LeanTween.value(singSceneControl.gameObject, startPosition.y, endPosition.y, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.top = val;
        }).setEaseInSine().setOnComplete(() =>
        {
            visualElementToAnimate.style.top = endPosition.y;



            LeanTween.delayedCall(0.2f, () =>
            {
                FadeOut(visualElementToAnimate, 0.2f, () =>
                {
                    visualElementToAnimate.RemoveFromHierarchy();
                    callback?.Invoke();
                });
            });


        });
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
        visualElementToAnimate.style.left = startPosition.x + UnityEngine.Random.Range(0, 10);
        visualElementToAnimate.style.top = startPosition.y + UnityEngine.Random.Range(0, 10);

        // Start the tween
        LeanTween.value(singSceneControl.gameObject, startPosition.x, endPosition.x, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.left = val;

        }).setEaseInSine().setOnComplete(() =>
        {
            visualElementToAnimate.style.left = endPosition.x;
        });

        LeanTween.value(singSceneControl.gameObject, startPosition.y, endPosition.y, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.top = val;
        }).setEaseInSine().setOnComplete(() =>
        {
            visualElementToAnimate.style.top = endPosition.y;
            callback?.Invoke();
        });
    }

    private void FadeOut(VisualElement visualElementToAnimate, float durationInS, Action callback)
    {
        // Starten Sie den Tween, um die Opazität von 1 auf 0 zu ändern
        LeanTween.value(singSceneControl.gameObject, 1f, 0f, durationInS).setOnUpdate((float val) =>
        {
            visualElementToAnimate.style.opacity = val;
        }).setOnComplete(() =>
        {
            visualElementToAnimate.style.opacity = 0f;
            callback?.Invoke();
        });
    }
}
