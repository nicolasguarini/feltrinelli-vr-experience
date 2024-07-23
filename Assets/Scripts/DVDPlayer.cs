using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class DVDPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assicurati di assegnare questo nell'Inspector
    public PlayVideo playVideoScript; // Assicurati di assegnare questo nell'Inspector

    private XRSocketInteractor socketInteractor;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socketInteractor.selectEntered.AddListener(OnSelectEntered);
        socketInteractor.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
        socketInteractor.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        DVD dvd = args.interactableObject.transform.GetComponent<DVD>();
        if (dvd != null)
        {
            PlayVideo(dvd);
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        StopVideo();
    }

    private void PlayVideo(DVD dvd)
    {
        if (dvd.video != null)
        {
            videoPlayer.clip = dvd.video;
            videoPlayer.Prepare();
            videoPlayer.prepareCompleted += OnVideoPrepared;
        }
        else
        {
            Debug.LogWarning("No video assigned to this DVD.");
        }
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        playVideoScript.videoClips.Clear();
        playVideoScript.videoClips.Add(source.clip);
        playVideoScript.PlayAtIndex(0);
        videoPlayer.prepareCompleted -= OnVideoPrepared;
    }

    private void StopVideo()
    {
        playVideoScript.Stop();
    }
}