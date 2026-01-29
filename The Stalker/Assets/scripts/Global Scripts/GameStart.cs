using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject MainCutscene;
    public GameObject Frames;

    // Public method to be called by the UI Button
    public void StartMainCutscene()
    {
        MainCutscene.SetActive(true);
        Frames.SetActive(true);
    }
}
