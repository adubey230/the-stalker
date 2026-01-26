using UnityEngine;

public class TireCanvasController : MonoBehaviour
{
    private CarTire carTire;
    private CarTire.TireState state;

    private int totalBolts = 5;
    private int boltsPlaced = 0;
    private int[] boltTightenCounts;


    public void Initialize(CarTire tire, CarTire.TireState currentState)
    {
        carTire = tire;
        state = currentState;

        boltTightenCounts = new int[totalBolts];
    }

    public void OnTireClicked()
    {
        if (state != CarTire.TireState.TireMissing) return;

        state = CarTire.TireState.TirePlaced;
    }
    
    public void OnBoltHoleClicked(int index, bool playerHasBolts)
    {
        if (!playerHasBolts) return;

        boltsPlaced++;

        if (boltsPlaced >= totalBolts)
        {
            state = CarTire.TireState.BoltsPlaced;
            carTire.AllBoltsPlaced();
        }
    }

    public void OnBoltClicked(int index, bool playerHasWrench)
    {
        if (!playerHasWrench) return;

        boltTightenCounts[index]++;

        if (boltTightenCounts[index] >= 3)
        {
            // this bolt is fully tightened
        }

        if (CheckAllBoltsTightened())
        {
            carTire.AllBoltsTightened();
        }
    }

    private bool CheckAllBoltsTightened()
    {
        foreach (int count in boltTightenCounts)
        {
            if (count < 3) return false;
        }
        return true;
    }
}
