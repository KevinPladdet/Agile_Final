using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Damage : MonoBehaviour
{
    public int health = 10;
    private Rigidbody rb;
    public Rigidbody playerRB;
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
        rb.velocity = Vector3.zero;
        rb.AddForce( direction.normalized * -thrust, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Melee"))
        {
            Debug.Log("KnockBack");
            direction = other.transform.position - transform.position;
            KnockBack();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
