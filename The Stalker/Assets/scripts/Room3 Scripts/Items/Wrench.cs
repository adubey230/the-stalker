using UnityEngine;

public class Wrench : Item
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
