using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public static bool ItemPickup = false;

    private void Update()
    {
        if (ItemPickup)
        {
            Debug.Log("OBJ COMPLETE");
        }
    }
}
