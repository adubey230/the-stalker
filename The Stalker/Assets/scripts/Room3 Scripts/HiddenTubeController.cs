using UnityEngine;

public class HiddenTubeController : MonoBehaviour
{
    // placeholder condition booleans
    public bool conditionOneMet = false;
    public bool conditionTwoMet = false;

    // optional reference to the door object, lest we don't want to manipulate it directly
    public GameObject finalDoor;

    void Update()
    {
        // checking if both conditions are met
        if (conditionOneMet && conditionTwoMet)
        {
            UnlockDoor();
        }
    }

    void UnlockDoor()
    {
        Debug.Log("final door unlocked :)");

        // if there is a final door object referenced, it is set to inactive -- meant to be refined
        if (finalDoor != null)
        {
            finalDoor.SetActive(false); // or trigger an animation, yadda yadda
        }
    }
}