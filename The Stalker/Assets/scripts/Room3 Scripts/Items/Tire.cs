using UnityEngine;

public class Tire : Item
{
    protected override void Start()
    {
        base.Start();
        RemoveOnUse = true;
    }

    public override bool UseItem()
    {
        return RemoveOnUse;
    }
}
