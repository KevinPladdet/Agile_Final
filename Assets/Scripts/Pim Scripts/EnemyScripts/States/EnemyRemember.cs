using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRemember : MonoBehaviour
{
    private Ray ray;
    private string lastHit;
    private float beginTime;
    private string lookingAt;
    public float maxDistance;
    public float timeToDetection;
    public bool forgor;
    [HideInInspector] public float lastPlayerSeenTime;

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);
        if (lookingAt == "Player")
        {
            lookingAt = "";
            lastPlayerSeenTime = Time.time;
            forgor = true;
        }
        else
        {
            if (Time.time - lastPlayerSeenTime > 10f)
            {
                forgor = false;
            }
        }
        PlayerDetection();
    }

    void PlayerDetection()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            Debug.Log("Hit");
            if (lastHit == hit.collider.gameObject.tag)
            {
                if ((Time.time - beginTime) > timeToDetection)
                {
                    lookingAt = hit.collider.gameObject.tag;
                    Debug.Log(lookingAt);
                }
            }
            else
            {
                beginTime = Time.time;
                lookingAt = "";
            }
            lastHit = hit.collider.gameObject.tag;
        }
        else
        {
            lastHit = "";
            lookingAt = "";
        }
    }
}