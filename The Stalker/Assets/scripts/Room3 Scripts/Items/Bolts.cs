using UnityEngine;

public class Bolts : Item
{
    protected override void Start()
    {
        base.Start();
        RemoveOnUse = false;
    }

    public override bool UseItem()
    {
        return RemoveOnUse;
    }
}
