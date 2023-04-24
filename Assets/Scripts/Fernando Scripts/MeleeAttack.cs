using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject enemy;
    private bool onEnemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy == true)
        {
            SmallAttack();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check if enemy is in range
        onEnemy = true;
        //Debug.Log(onEnemy);
    }
    private void OnTriggerExit(Collider other)
    {
        //Check if enemy is in range
        onEnemy = false;
        //Debug.Log(onEnemy);
    }
    void SmallAttack()
    {
        enemy.GetComponent<Damage>().TakeDamage();
    }
    void BigAttack()
    {
        
    }
    void SneakAttack()
    {
        
    }
}
