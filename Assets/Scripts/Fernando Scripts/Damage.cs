using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Damage : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody playerRB;

    public int health = 10;

    public float thrust;

    public Vector3 direction;
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
        //Debug.Log(hit);
    }
    //When hit take damage
    public void TakeDamage()
    {
        Debug.Log("Damaged");
        KnockBack();
        health--;
        
    }
    public void TakeDamage2()
    {
        Debug.Log("Damaged2");
        KnockBack();
        health -= 2;
    }
    public void KnockBack()
    {
        Debug.Log("KnockBack");
        rb.velocity = Vector3.zero;
        direction = playerRB.transform.position - transform.position;
        rb.AddForce(direction.normalized * -thrust, ForceMode.Impulse);
    }
}
