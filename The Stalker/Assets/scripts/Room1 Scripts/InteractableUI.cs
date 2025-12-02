using System;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class InteractableUI : MonoBehaviour, Iinteractable
{   
    [Serializable] public struct CanvasUI{
        public string name;
        [Header("Actually doesn't have to be Canvas")]
        public GameObject theCanvas;
    };
    public CanvasUI interactable;
    private bool bCanvasActive;
    private bool CanInteract;
    IEnumerator Init()
    {
        yield return null;
    }

    private void Start()
    {
        StartCoroutine(Init());
        bCanvasActive = false;
        CanInteract = true;
        interactable.theCanvas.SetActive(bCanvasActive);
    }

    public bool Interact()
    {
        if(CanInteract){
            if (bCanvasActive)
            {
                CloseUI();
                bCanvasActive = false;
                return false;
            }
            else
            {
                bCanvasActive = true;
                OpenUI();
                return true;
            }
        }
        else
        {
            if (interactable.theCanvas.name == "CanvasClueBoard" && !LocatorDialogue.Instance.DialogueScript.ElisaAudioPlaying)
            {
                LocatorDialogue.Instance.DialogueScript.ShowElisaText("It’s too dark. I can’t see anything…", 5);
            }
        }
        return false;
}

    public void CloseUI()
    {
        interactable.theCanvas.SetActive(false);
    }

    public void OpenUI()
    {
        interactable.theCanvas.SetActive(true);

        // if (interactable.theCanvas.name == "CanvasClueBoard")
        // {
        //     LocatorDialogue.Instance.DialogueScript.SawClueBoard = true;
        // }

        if (interactable.theCanvas.name == "BigPocketWatchClue" && !LocatorDialogue.Instance.DialogueScript.ElisaAudioPlaying)
        {
            if (LocatorDialogue.Instance.DialogueScript.SawClueBoard)
            {
                LocatorDialogue.Instance.DialogueScript.ShowElisaText("A pocket watch? I remember seeing that somewhere…", 1);
            } 
            else
            {
                LocatorDialogue.Instance.DialogueScript.ShowElisaText("A pocket watch? I wonder what it does…", 2);
            }
        }
        
        
    }
     public bool GetCanvasActive(){
        return bCanvasActive;

    }
    public bool GetCanInteract(){
        return CanInteract;

    }
    public void SetCanInteract(bool boolean){
        CanInteract = boolean;
        
    }
}