using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Spoon : MonoBehaviour
{
    [SerializeField] private GameObject spoonDialog;
    [SerializeField] private Button button;
    private bool touchingSpoon = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        touchingSpoon = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        touchingSpoon = false;
    }

    void Update()
    {
        if(touchingSpoon && Keyboard.current.eKey.wasPressedThisFrame)
        {
            spoonDialog.SetActive(true);
            button.onClick.AddListener(CloseDialog); 
        }
    }

    private void CloseDialog()
    {
        spoonDialog.SetActive(false);
    }
}
