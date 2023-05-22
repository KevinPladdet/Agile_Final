using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPlayer : MonoBehaviour
{
    Ray ray;
    private string LastHit;
    private float BeginTime;
    public string LookingAt;
    public float MaxDistance;
    public float TimeToDetection;
    public bool seenPlayer;


    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }
    void Update()
    {
        Debug.DrawRay(transform.position,Vector3.forward, Color.green);
        PlayerDetection();
        Debug.Log("Looking at " + LookingAt);
        if(LookingAt == "Player")
        {
            seenPlayer = true;
        }

    }

    void PlayerDetection()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, MaxDistance)) 
        {
            Debug.Log("hit");
            if(LastHit == hit.collider.gameObject.tag)
            {
                if((Time.time - BeginTime) > TimeToDetection)
                {
                    LookingAt = hit.collider.gameObject.tag;
                }
            }
            else
            {
                BeginTime = Time.time;
                LookingAt = "";
            }
            LastHit = hit.collider.gameObject.tag;
        }
        else
        {
            LastHit = "";
            LookingAt = "";
        }
    }
}
