using UnityEngine;

public class InventoryCanvasSingleton : MonoBehaviour
{
    private static InventoryCanvasSingleton Instance;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
