using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollToggle : MonoBehaviour
{
    [SerializeField] private bool isKinematic = true;

    void Start()
    {
        SetKinematic(isKinematic);
    }

    /*
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) SetKinematic(isKinematic);
    }
    */

    public void SetKinematic(bool value)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = value;
        }
    }
}
