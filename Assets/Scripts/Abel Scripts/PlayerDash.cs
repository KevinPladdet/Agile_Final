using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private Transform dashPoint;
    
    private Vector3 endPosition;
    private Vector3 startPosition;
    public Vector3 resetPosition;

    [SerializeField] private float dashDistance;
    [SerializeField] private float dashTime; // in seconds
    private float timeElapsed = 0f;

    [SerializeField] private AnimationCurve dashCurve;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(Dash());
        }
        Debug.DrawRay(dashPoint.position, dashPoint.transform.forward, UnityEngine.Color.yellow);

        // For debugging purposes, remove when finished.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.position = new Vector3(-4, 1.04f, 0);
        }
    }

    // Dash is a coroutine, meaning it runs alongside other code in the Update functions.
    // This lets it act on its AnimationCurve without interfering with other code.
    private IEnumerator Dash()
    {
        if (Physics.OverlapBox(dashPoint.position, dashPoint.localScale / 2, dashPoint.rotation).Length > 1)
        {
            Debug.Log("Box has been overlapped, no Dash available");
            yield return null;
        } else
        {
            startPosition = transform.position;
            endPosition = GetDashLocation();
            timeElapsed = 0;

            while (timeElapsed < dashTime)
            {
                timeElapsed += Time.deltaTime; // sets time elapsed in seconds
                float percentageComplete = timeElapsed / dashTime; // gets a decimal number between 0 - 1

                // Lerp interpolates the movement between both positions linearly,
                // but adding the Dash AnimationCurve makes it more smooth.
                transform.position = Vector3.Lerp(startPosition, endPosition, dashCurve.Evaluate(percentageComplete));
                yield return new WaitForEndOfFrame(); // makes sure the while-loop runs at the same speed as Update.
            }
        }
    }

    private Vector3 GetDashLocation()
    {
        RaycastHit hit;

        // if something is within a certain distance of dashPoint, set endPosition to hit. If not, use end of distance.
        if (Physics.Raycast(dashPoint.position, dashPoint.transform.forward, out hit, dashDistance))
        {
            Debug.Log("Raycast Hit");
            return new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.forward * 0.5f;
        }
        else
        {
            Debug.Log("Raycast no hit");
            return transform.position + transform.forward * dashDistance; // return forward + dashDistance
        }
    }
}
