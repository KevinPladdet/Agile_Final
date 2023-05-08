using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
	public GameObject character;
	public Animator anim;

	void Update()
	{
		if (Input.GetKey("w"))
		{
			anim.SetBool("Foreward", true);

			anim.SetBool("Idle", false);
			anim.SetBool("Back", false);
			anim.SetBool("Left", false);
			anim.SetBool("Right", false);
		}
		if (Input.GetKey("a"))
		{
			anim.SetBool("Left", true);

			anim.SetBool("Idle", false);
			anim.SetBool("Foreward", false);
			anim.SetBool("Back", false);
			anim.SetBool("Right", false);
		}
		if (Input.GetKey("s"))
		{
			anim.SetBool("Back", true);

			anim.SetBool("Idle", false);
			anim.SetBool("Foreward", false);
			anim.SetBool("Left", false);
			anim.SetBool("Right", false);
		}
		if (Input.GetKey("d"))
		{
			anim.SetBool("Right", true);

			anim.SetBool("Idle", false);
			anim.SetBool("Foreward", false);
			anim.SetBool("Back", false);
			anim.SetBool("Left", false);
		}
		if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false)
		{
			anim.SetBool("Idle", true);

			anim.SetBool("Back", false);
			anim.SetBool("Foreward", false);
			anim.SetBool("Left", false);
			anim.SetBool("Right", false);
		}
	}
}
