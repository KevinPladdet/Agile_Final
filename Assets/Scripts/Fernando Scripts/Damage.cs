using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Damage : MonoBehaviour
{
    public int health = 10;
    public Rigidbody rb;
    public float thrust;
    //KnockBack
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //when 0 hp enemy dies
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    //When hit take damage
    public void TakeDamage()
    {
        Debug.Log("Damaged");
        KnockBack();
        health--;
    }
    public void KnockBack()
    {
        rb.AddForce(transform.forward * -thrust);
    }
}
