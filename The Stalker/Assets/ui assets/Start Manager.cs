using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject reply;
    [SerializeField] private GameObject replyHigh;
    [SerializeField] private StartButton reply1;
    [SerializeField] private StartButton replyHigh2;
    [SerializeField] private List<GameObject> frames = new List<GameObject>();
    [SerializeField] private GameObject notif;
    [SerializeField] private AudioSource _audioS;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource email;
    [SerializeField] private AudioClip ping;

    private float timer = 0f;
    private float timer2 = 0f;
    private float timer3 = 0f;
    private bool highlight = true;
    private int i = 0;
    private bool notification = false;

    void Start()
    {
        _audioS.clip = clip;
        _audioS.Play();
    }
    void Update()
    {
        timer3 += Time.deltaTime;
        if(timer3 >= 1f && !notification)
        {
            email.clip = ping;
            email.Play();
            
            notif.SetActive(true);
            reply.SetActive(true);
            notification = true;
        }
        
        if(notification)
        {
            timer += Time.deltaTime;
            if(timer >= 1f && !reply1.off && !replyHigh2.off)
            {
                if(highlight)
                {
                    replyHigh.SetActive(true);
                    reply.SetActive(false);
                    highlight = false;
                }
                else
                {
                    reply.SetActive(true);
                    replyHigh.SetActive(false);
                    highlight = true;
                }

                timer = 0f;
            }
        }

        if(reply1.off || replyHigh2.off)
        {
            notif.SetActive(false);
            timer2 += Time.deltaTime;
            if(timer2 >= 2f)
            {
                i++;
                if(i < frames.Count)
                {
                    frames[i].SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }

                timer2 = 0f;
            }
        }
    }
}
