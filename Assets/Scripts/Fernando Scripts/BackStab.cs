using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStab : MonoBehaviour
{
    [Header("Backstab")]
    public bool canBackStab = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            canBackStab = true;
        }
    }
}
