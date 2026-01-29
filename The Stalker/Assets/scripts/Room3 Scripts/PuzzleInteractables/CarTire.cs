using UnityEngine;

public class CarTire : PuzzleInteractable
{
    [SerializeField] private GameObject _tireCanvas;
    [SerializeField] private GameObject _trunkCanvas;
    
    private TireState _currentState = TireState.TireMissing;

    // item id needed on parent script is the same as the tire id    
    public enum TireState // state machine
    {
        TireMissing, // tire not installed
        TirePlaced, // tire installed, but no bolts
        BoltsPlaced, // bolts placed, but not tightened
        BoltsTightened // bolts tightened - puzzle solved
    }

    
    public override bool Interact()
    {
        switch (_currentState)
        {
            case TireState.TireMissing:
                Debug.Log("Tire is missing");
                player.ToggleInventory();
                break;

            case TireState.TirePlaced:
                case TireState.BoltsPlaced:
                OpenTireCanvas();
                break;
        }

        return true;
    }

    public override void UseItem(Item item)
    {
        switch (_currentState)
        {
            case TireState.TireMissing:
                TryPlaceTire(item);
                break;
            case TireState.TirePlaced:
                Debug.Log("I need something to attach the tire");
                break;
            case TireState.BoltsPlaced:
                Debug.Log("I need something to tighten these");
                break;
        }

        CloseUI();
    }

    private void TryPlaceTire(Item item)
    {
        if (item.id != itemIDNeeded)
        {
            Debug.Log("wrong item");
            return;
        }

        Debug.Log("tire placed");
        _currentState = TireState.TirePlaced;

        OpenTireCanvas();
    }

    private void OpenTireCanvas()
    {
        _tireCanvas.SetActive(true);

        // update the tire canvas
    }

    public void AllBoltsPlaced()
    {
        _currentState = TireState.BoltsPlaced;
    }

    public void AllBoltsTightened()
    {
        _currentState = TireState.BoltsTightened;
        isSolved = true;

        _tireCanvas.SetActive(false);
        _trunkCanvas.SetActive(true);
    }
}
