using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Base
{
    public override void interact(TouchExample touchExample)
    {
        if (touchExample.HasObjekDapur())
        {
            touchExample.GetObjekDapur().DestroySelf();
        }
    }
}
