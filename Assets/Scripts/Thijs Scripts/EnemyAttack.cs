using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    float distance;
    float lastAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 2f && Time.time - lastAttack > 1)
        {
            player.GetComponent<PlayerHealth>().currentHealth -= 10;
            lastAttack = Time.time;
            Debug.Log("Attack");
        }
    }
}
