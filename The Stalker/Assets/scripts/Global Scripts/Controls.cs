using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject center;
    [SerializeField] private Button button;


    void Update()
    {
        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            center.SetActive(true);
            button.onClick.AddListener(SetGameObjectFalse);
        }
    }
    public void SetGameObjectActive()
    {
        center.SetActive(true);
        button.onClick.AddListener(SetGameObjectFalse);
    }

    private void SetGameObjectFalse()
    {
        center.SetActive(false);
    }
}
