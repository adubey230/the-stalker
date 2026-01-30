using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    private static PersistentCanvas Instance;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    

    
}
