using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetButton: MonoBehaviour
{
    //inventory is not being reset
    public void OnButtonClick()
    {
        Debug.Log("Restart");
        InventoryManager.loadInventory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }
    public void Quit(){

        Application.Quit();
    }
}
