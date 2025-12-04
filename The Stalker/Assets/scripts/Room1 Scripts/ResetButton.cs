using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetButton: MonoBehaviour
{
    //inventory is not being reset
    public void OnButtonClick()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }
    public void Quit(){

        Application.Quit();
    }
}
