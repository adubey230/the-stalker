using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private bool inventoryOpen;
    [SerializeField] private List<Item> inventoryList = new List<Item>();
    [SerializeField] private Canvas inventoryUI;
    public static InventoryManager Instance;

    public Animator animator;

    void Awake()
    {
        
       
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
        inventoryUI=GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        
    }
    void Start()
    {
        inventoryUI.gameObject.SetActive(false);
        inventoryOpen = false;
    }

    private void OnEnable()
    {
        GameManager.ItemPickedUp += AddItem;
    }
    private void OnDisable()
    {
        GameManager.ItemPickedUp += AddItem;
    }

    public void ToggleInventory()
    {
        if (inventoryOpen)
        {
            animator.SetBool("IsOpen", false);
            inventoryOpen = false;
        }
        else
        {
            inventoryUI.gameObject.SetActive(false);
            inventoryUI.gameObject.SetActive(true);
            animator.SetBool("IsOpen", true);
            inventoryOpen = true;
        }
    }

    public void AddItem(Item item)
    {
        inventoryList.Add(item);
        if (item.name == "PocketWatch")
        {
            LocatorDialogue.Instance.DialogueScript.SawClueBoard = true;
            LocatorDialogue.Instance.DialogueScript.ShowElisaText("Would this increase my time?", 6);
        }
        ToggleInventory();
    }
    public void RemoveItem(Item item)
    {
        inventoryList.Remove(item);
    }
    public Item GetItemFromInventory(int index)
    {
        if (index < 0 || index >= inventoryList.Count) return null;
        return inventoryList[index];
    }
    public void UseItem(Item item)
    {
        bool useditem = item.UseItem();
        if (useditem) {
            RemoveItem(item);
        }
        ToggleInventory();
        
       
    }
    public bool GetInventoryOpen(){
     return inventoryOpen;   
    }
    public List<Item> GetInventory()
    {
        return inventoryList;
    }
}
