using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    //public List<GameObject> Enemies;
    [Header("Backstab")]
    public bool CanBackStab = false;
    
    [Header("Combo System")]
    public GameObject enemy;
    private bool onEnemy;
    //ComboSystem
    private float comboTimer = 1f;

    private int comboStep = 1;

    private Vector3 direction;

    bool canAttack = true;

    private enum AttackType { None, Small, Small2, Big, Backstab }

    private AttackType currentAttack = AttackType.None;

    //public List<GameObject> Enemies;

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
            StartCoroutine(PerformComboStep(0.5f, SmallAttack1, AttackType.Small));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy && comboStep == 2 && canAttack == true)
        {
            comboStep = 3;
            Debug.Log("2");
            StartCoroutine(PerformComboStep(0.5f, SmallAttack2, AttackType.Small2));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && onEnemy && comboStep == 3 && canAttack == true)
        {
            comboStep = 1;
            Debug.Log("3");
            StartCoroutine(PerformComboStep(1f, BigAttack, AttackType.Big));
        }
        if (Input.GetKeyDown(KeyCode.F) && onEnemy && comboStep == 1 && canAttack == true && CanBackStab == true)
        {
            comboStep = 1;
            Debug.Log("BackStab");
            StartCoroutine(PerformComboStep(1f, BackStab, AttackType.Backstab));
        }
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

    private IEnumerator PerformComboStep(float delay, System.Action attackAction, AttackType preformedAttack)
    {
        currentAttack = preformedAttack;
        canAttack = false;
        yield return new WaitForSeconds(delay);
        //attackAction.Invoke();
        comboTimer = 1.5f;
        canAttack = true;
        currentAttack = AttackType.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            onEnemy = true;
            direction = other.transform.position - transform.position;
            Debug.Log(currentAttack);
            switch (currentAttack)
            {
                case AttackType.None:
                    break;
                case AttackType.Small:
            Debug.Log("Hit");
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                    break;
                case AttackType.Small2:
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                    break;
                case AttackType.Big:
                    other.gameObject.GetComponent<Damage>().TakeDamage2();
                    break;
                case AttackType.Backstab:
                    other.gameObject.GetComponent<Damage>().BackStab();
                    break;
                default:
                    break;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if enemy is out of range
        if (other.gameObject.CompareTag("Enemy"))
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
    private void BackStab()
    {
        enemy.GetComponent<Damage>().BackStab();
    }
    public void BackStabSwitchOn()
    {
        CanBackStab = true;
    }
    public void BackStabSwitchOff()
    {
        CanBackStab = false;
    }
}