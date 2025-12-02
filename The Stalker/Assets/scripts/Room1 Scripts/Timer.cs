using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    //edit max time in the inspector of gameobject that holds the script
    public float time = 5f;
    public bool running = false;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Player player;
    [SerializeField] private GameObject canvas;
    private bool notActive = false;
    private bool once = true;

    private float maxTime;
    private void Start()
    {
        maxTime = time;
        running = true;

        if (healthBar != null)
        {
            healthBar.maxValue = maxTime;
            healthBar.value = maxTime;
        }
    }

    void Update()
    {
        if (running)
        {
            if(!canvas.activeSelf && once)
            {
                notActive = true;
                once = false;
            }
            
            if (time > 0 && notActive)
            {
                time -= Time.deltaTime;
                //Debug.Log(time);

                if (healthBar != null)
                    healthBar.value = time;
            }
            else
            {
                //Debug.Log("time ran out");
                time = 0;
                running = false;
                player.SetGameOver(true);
                gameOver.SetActive(true);
                LocatorDialogue.Instance.DialogueScript.PlayStalkerGameOverAudio();
            }
        }
    }

    public void PauseTimer()
    {
        running = false;
    }
    public void UnpauseTimer()
    {
        running = true;
    }
}
