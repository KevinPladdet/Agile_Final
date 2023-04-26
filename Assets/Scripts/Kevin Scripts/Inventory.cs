using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool HealingActive = true;
    public bool ThrowableActive = false;
    public bool DoneWaiting = true;

    public GameObject HealingItem;
    public GameObject ThrowableItem;

    void Update()
    {
        if(HealingActive && DoneWaiting)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                HealingItem.SetActive(false);
                ThrowableItem.SetActive(true);
                Debug.Log("Switched from Healing to Throwable");
                StartCoroutine(Waiting(0.2f));
                ThrowableActive = true;
                HealingActive = false;  
            }
        }

        if (ThrowableActive && DoneWaiting)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                HealingItem.SetActive(true);
                ThrowableItem.SetActive(false);
                Debug.Log("Switched from Throwable to Healing");
                StartCoroutine(Waiting(0.2f));
                HealingActive = true;
                ThrowableActive = false;
            }
        }

        if (HealingActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Healing item gets used
                Debug.Log("Player has been healed");
            }
        }

        if (ThrowableActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Player uses throwable
                Debug.Log("Kunai has been thrown");
            }
        }

        IEnumerator Waiting(float duration) // This code needs a waiting system, otherwise it switches weapons multiple times in the same frame
        {
            DoneWaiting = false;
            yield return new WaitForSeconds(duration);
            DoneWaiting = true;
        }
    }
}
