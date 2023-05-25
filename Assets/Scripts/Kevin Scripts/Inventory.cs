using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool HealingActive = true;
    public bool ThrowableActive = false;
    public bool DoneWaiting = true;
    public bool PlayerGotHealed;

    public GameObject HealingItem;
    public GameObject ThrowableItem;

    private static AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(HealingActive && DoneWaiting)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _audioSource.Play();
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
                _audioSource.Play();
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
                PlayerGotHealed = true; // Healing item gets used (Player heals 40 HP)
            }
        }

        if (ThrowableActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Player uses throwable
                Debug.Log("Kunai has been thrown"); 
                // The same person who is making the player / the attacks will make a kunai system and link it with this script
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
