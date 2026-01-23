using UnityEngine;

public class CarTire : PuzzleInteractable
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] public bool _in_tire;

    private bool _tireOnCar = false;

    // this function is two steps
    // first, we check if player has tire and tire is not yet equipped
    // in that control, we update the visuals so the tire is on, and set _tireOnCar to true
    // then, a second control for the bolts. copy the vent from room 2, but reverse the animation
    public override void UseItem(Item item)
    {
        if (itemIDNeeded == item.id && !_tireOnCar)
        {
            // update tire visuals (close _canvas, open a new canvas with a new script)
            // disable this script?
            _tireOnCar = true;
            // start while loop (maybe update bool in a script attached to the canvas)
        }
        else
        {
            Debug.Log(item.name + " is the incorrect item");
        }
        CloseUI();
    }
}
