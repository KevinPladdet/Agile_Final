using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
	public GameObject Enemy;
	public Animator anim;

	void Update()
	{
        if (Input.GetKeyDown("y"))
        {
			anim.SetBool("Idle", false);
			anim.SetBool("Foreward", false);
			anim.SetBool("Attacking", true);
		}        
		if (Input.GetKeyDown("u"))
        {
			anim.SetBool("Idle", false);
			anim.SetBool("Foreward", true);
			anim.SetBool("Attacking", false);
		}        
		if (Input.GetKeyDown("i"))
        {
			anim.SetBool("Idle", true);
			anim.SetBool("Foreward", false);
			anim.SetBool("Attacking", false);
		}
	}
}
