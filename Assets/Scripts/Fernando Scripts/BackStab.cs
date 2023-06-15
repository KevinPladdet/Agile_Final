using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStab : MonoBehaviour
{
    //[Header("Backstab")]
    //public bool canBackStab = false;


    public GameObject Player;
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
        if (other.gameObject == Player)
        {
            //Debug.Log("Yes");
            Player.GetComponentInChildren<MeleeAttack>().BackStabSwitchOn();
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            //Debug.Log("no");
            Player.GetComponentInChildren<MeleeAttack>().BackStabSwitchOff();
        }
    }
}
