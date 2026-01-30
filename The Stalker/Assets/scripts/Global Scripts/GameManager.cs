using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject clock;
    [SerializeField] private AudioClip _bgClip;
    [SerializeField] private AudioClip _bgClipFast;
    [SerializeField] private AudioSource _firstTrack;
    [SerializeField] private AudioSource _secondTrack;

    [SerializeField] private LightController _lightControl;
    [SerializeField] private Timer _time;
    [SerializeField] private Controls control;

    //clueboard ui
    [SerializeField] private List<GameObject> clues;
    [SerializeField] private GameObject panel;
    private bool isActive = false;
    private bool hasChangedAudio = false; 
    private bool _track1isPlaying;
    private bool methodCalled = false;

    public static Action<Item> ItemPickedUp;

    private float time = 400f;
    public void TurnOffClockCanvas()
    {
        clock.SetActive(false);
    }

    void Start()
    {
        _track1isPlaying = true;
        ChangeAudio(_bgClip);
    }

    private void ChangeAudio(AudioClip newClip)
    {
        StopAllCoroutines();
        StartCoroutine(FadeTrack(newClip));

        _track1isPlaying = !_track1isPlaying;
    }

    //fades between the two audios
    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 10f;
        float timeElapsed = 0;

        if (_track1isPlaying)
        {
            _secondTrack.clip = newClip;
            _secondTrack.Play();

            while (timeElapsed < timeToFade)
                {
                    _secondTrack.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                    _firstTrack.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }

            _firstTrack.Stop();
        }
        else
        {
            _firstTrack.clip = newClip;
            _firstTrack.Play();

            while (timeElapsed < timeToFade)
                {
                    _firstTrack.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                    _secondTrack.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }

            _secondTrack.Stop();
        }
    }

    private bool CheckClues()
    {
        for(int i = 0; i < clues.Count; i++)
        {
            if(clues[i].activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    void Update()
    {
        if(_time.time <= time * 0.3f)
        {
            if (!hasChangedAudio)
            {
                hasChangedAudio = true;
                ChangeAudio(_bgClipFast);
            }
            
        }

        if(_time.time < time && !methodCalled)
        {
            methodCalled = true;
            control.SetGameObjectActive();
            Debug.Log("active");
        }

        if(CheckClues())
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
