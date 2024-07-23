using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CDPlayer : MonoBehaviour
{
    public AudioSource audioSourceLeft;
    public AudioSource audioSourceRight;


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
        CD cd = args.interactableObject.transform.GetComponent<CD>();
        if (cd != null)
        {
            PlaySong(cd);
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        CD cd = args.interactableObject.transform.GetComponent<CD>();
        if (cd != null)
        {
            StopSong();
        }
    }

    private void PlaySong(CD cd)
    {
        if (cd.song != null)
        {
            audioSourceLeft.clip = cd.song;
            audioSourceRight.clip = cd.song;
            audioSourceLeft.Play();
            audioSourceRight.Play();
        }
        else
        {
            Debug.LogWarning("No song assigned to this CD.");
        }
    }

    private void StopSong()
    {
        audioSourceLeft.Stop();
        audioSourceRight.Stop();
    }
}