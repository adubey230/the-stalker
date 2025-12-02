using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogueRoom2 : MonoBehaviour
{

    //temporary script since theres not much for room 2 rn
    public string[] SpoonStalkerLines;
    [SerializeField] private TimelineAsset SpoonStalker;
    [SerializeField] private TMP_Text stalker_text; 
    [SerializeField] private GameObject stalker_dialoguebox;
    private int i;
     public AudioClip[] elisaAudioClips;

     [SerializeField] private TMP_Text elisa_text; 
     [SerializeField] private GameObject elisa_dialoguebox;

     private PlayableDirector director; // for stalker audio
     private AudioSource elisaAudio;

     private string[] lines;

    //to toggle whether player can move or not
     public bool StalkerAudioPlaying {get; private set;}



     /*
        Ah, I'd been loocking for that. 
        Funny thing is...
        I was going to gift it to you along with the book I wrote about it, 
        but it looks like it found its owner 
        the same way I found you.
     */ 

    void Start()
    {
        
        elisa_dialoguebox.SetActive(false);
        elisaAudio = GetComponent<AudioSource>();

        StalkerAudioPlaying = false;
        stalker_dialoguebox.SetActive(false);
        director = GetComponent<PlayableDirector>();
        lines = SpoonStalkerLines;
    }
    void Update()
    {
        if (i < lines.Length)
        {
            stalker_text.text = lines[i];
            //StalkerAudioPlaying = true;
           // timer.PauseTimer();
            //player can't move
        }
        else
        {
            stalker_dialoguebox.SetActive(false);
            director.Stop();
            StalkerAudioPlaying = false;
            //timer.UnpauseTimer();
            //play can move again
        }
    }

    public void NextLine()
    {
        Debug.Log("Next line pls");
        i++;
    }


    public void PlayStalkerSpoonLines()
    {
        StalkerAudioPlaying = true;
        director.playableAsset = SpoonStalker; 
        director.time = 0;
        lines = SpoonStalkerLines;
        i = 0;
        stalker_dialoguebox.SetActive(true);
        director.Play();
    }

    public void SkipStalkerDialogue()
    {
        i = lines.Length + 1;
    }

    IEnumerator KeepBoxVisible(float sec)
    {
        
        yield return new WaitForSeconds(sec);
        elisa_dialoguebox.SetActive(false);
    }
    public void ShowElisaText(string dialogue, int audioIndex)
    {
        //if there's going to be audio/voice over, replace with audioclip length 
        //Audioclip = elisaAudioClips[audioIndex]

        //sets the audio to the corresponding audio
        elisaAudio.clip = elisaAudioClips[audioIndex];
        elisaAudio.Play();
        //sets the text to the corresponding text
        elisa_text.text = dialogue;

        //play elisa audio line
        
        //makes dialogue box with text appear
        elisa_dialoguebox.SetActive(true);
        //keeps textbox open for a while
        StartCoroutine(KeepBoxVisible(elisaAudio.clip.length));
        

    }
}
