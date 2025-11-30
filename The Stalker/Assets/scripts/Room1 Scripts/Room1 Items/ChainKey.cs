using UnityEngine;

public class ChainKey : MonoBehaviour, Iinteractable
{

    public ChainConstraint chainConstraint;
    public TargetJoint2D chainConnector;
    [SerializeField] private LightController _light;
    public bool Interact() 
    {
        Debug.Log("using chain key");

        chainConstraint.BreakChain();
        LocatorDialogue.Instance.DialogueScript.PlayStalkerEndLines();
        chainConnector.enabled = false;

        _light.turnLightsOff();
        _light.enabled = false;

        gameObject.SetActive(false);
        return true; // item is consumed on use
    }
}
