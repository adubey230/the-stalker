using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    //edit max time in the inspector of gameobject that holds the script
    public float time = 5f;
    public bool running = false;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Slider healthBar;
    [SerializeField] private EventSystem input;

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
            if (time > 0)
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
