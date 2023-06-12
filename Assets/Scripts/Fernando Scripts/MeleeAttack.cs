using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("Backstab")]

    


    [Header("Combo System")]
    public GameObject enemy;
    private bool onEnemy;
    //ComboSystem
    private float comboTimer = 1f;

    private int comboStep = 1;

    private Vector3 direction;

    bool canAttack = true;

    private void Start()
    {

    }

    private void Update()
    {
        // Combo sequence
        if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy && comboStep == 1 && canAttack == true)
        {
            comboStep = 2;
            Debug.Log("1");
            StartCoroutine(PerformComboStep(0.5f, SmallAttack1));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy && comboStep == 2 && canAttack == true)
        {
            comboStep = 3;
            Debug.Log("2");
            StartCoroutine(PerformComboStep(0.5f, SmallAttack2));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy && comboStep == 3 && canAttack == true)
        {
            comboStep = 1;
            Debug.Log("3");
            StartCoroutine(PerformComboStep(1f, BigAttack));
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy && comboStep == 1 && canAttack == true)
        // ComboSystem
        if (comboStep > 1)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                comboTimer = 1;
                comboStep = 1;
            }
        }
    }

    private IEnumerator PerformComboStep(float delay, System.Action attackAction)
    {
        canAttack = false;
        yield return new WaitForSeconds(delay);
        attackAction.Invoke();
        comboTimer = 1.5f;
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if enemy is in range
        if (other.gameObject == enemy)
        {
            onEnemy = true;
            direction = other.transform.position - transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if enemy is out of range
        if (other.gameObject == enemy)
        {
            onEnemy = false;
        }
    }

    private void SmallAttack1()
    {
        enemy.GetComponent<Damage>().TakeDamage();
    }

    private void SmallAttack2()
    {
        enemy.GetComponent<Damage>().TakeDamage();
    }

    private void BigAttack()
    {
        enemy.GetComponent<Damage>().TakeDamage2();
    }
    private void BackStabCheck()
    {

    }
}