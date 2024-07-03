using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Base
{
    public static event EventHandler onObjectThrown;
    public override void interact(TouchExample touchExample)
    {
        if (touchExample.HasObjekDapur())
        {
            onObjectThrown?.Invoke(this, EventArgs.Empty);
            touchExample.GetObjekDapur().DestroySelf();
        }
    }
}
