using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPlayer : MonoBehaviour
{
    Ray ray;
    private string LastHit;
    private float BeginTime;
    private string LookingAt;
    public float MaxDistance;
    public float TimeToDetection;
    public bool seenPlayer;


    void Start()
    {

    }
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position,Vector3.forward, Color.green);
        if (LookingAt == "Player")
        {
            LookingAt = "";
            seenPlayer = true;
        }
        PlayerDetection();

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
                    Debug.Log(LookingAt);
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
