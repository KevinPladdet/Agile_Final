using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPlayer : MonoBehaviour
{
    Ray ray;
    private string LastHit;
    private float BeginTime;
    public float MaxDistance;
    public float TimeToDetection;


    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }
    void Update()
    {
        PlayerDetection();
    }

    void PlayerDetection()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, MaxDistance)) 
        {
            if(LastHit == hit.collider.gameObject.tag)
            {
                if((Time.time - BeginTime) > TimeToDetection)
                {
                    Debug.Log(LastHit);
                }
            }
            else
            {
                BeginTime = Time.time;
            }
            LastHit = hit.collider.gameObject.tag;
        }
        else
        {
            LastHit = "";
        }
    }
}
