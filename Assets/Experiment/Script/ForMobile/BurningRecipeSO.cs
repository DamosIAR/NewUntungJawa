using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    public ObjekDapurSO input;
    public ObjekDapurSO output;
    public float burningTimerMax;
}
