using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject enemy;
    private bool onEnemy;
    //ComboSystem
    public float comboTimer;

    public float staminaMeter = 100f;

    public float attackTimerSmall;
    public float attackTimerBig;

    private bool combo1 = true;
    private bool combo2;
    private bool combo3;

    private bool attack1;
    private bool attack2;


    public Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //combo sequence
        if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy == true && combo1 == true)
        {
            Debug.Log("1");
            SmallAttack1();
            attack1 = true;
            combo1 = false;
            combo2 = true;
}
        else if(Input.GetKeyDown(KeyCode.Mouse0) && onEnemy == true && combo2 == true)
        {
            Debug.Log("2");
            SmallAttack2();
            attack2 = true;
            combo2 = false;
            combo3 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy == true && combo3 == true)
        {
            Debug.Log("3");
            BigAttack();
            combo1 = true;
            combo2 = false;
            combo3 = false;
            attack1 = false;
            attack2 = false;
        }

        //ComboSystem
        if(combo1 == true || combo2 == true || combo3 == true)
        {
            comboTimer -= Time.deltaTime;
        }
        if (comboTimer <= 0)
        {
            comboTimer = 0;
            combo1 = true;
            combo2 = false;
            combo3 = false;
            attack1 = false;
            attack2 = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check if enemy is in range
        onEnemy = true;
        direction = other.transform.position - transform.position;
        //Debug.Log(onEnemy);
    }
    private void OnTriggerExit(Collider other)
    {
        //Check if enemy is in range
        onEnemy = false;
        //Debug.Log(onEnemy);
    }
    void SmallAttack1()
    {
        enemy.GetComponent<Damage>().TakeDamage();
        comboTimer = 1;
    }
    void SmallAttack2()
    {
        enemy.GetComponent<Damage>().TakeDamage();
        comboTimer = 1;
    }
    void BigAttack()
    {
        enemy.GetComponent<Damage>().TakeDamage2();
    }
    void SneakAttack()
    {
        
    }
}
