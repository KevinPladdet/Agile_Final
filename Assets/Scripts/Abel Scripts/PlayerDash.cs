using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
    }

    // Dash is a coroutine, meaning it runs alongside other code in the Update functions.
    // This lets it act on its AnimationCurve without interfering with other code.
    private IEnumerator Dash()
    {
        RaycastHit hit;

        // WIP: if something is within a certain distance of dashPoint, set endPosition to hit. If not, use end of distance.
        if (Physics.Raycast(dashPoint.position, dashPoint.transform.TransformDirection(Vector3.forward), out hit))
        {
            endPosition = hit.point;
        } else
        {
        }

            startPosition = transform.position;
        endPosition = new Vector3(transform.position.x + dashDistance, transform.position.y, transform.position.z); // CHANGE TO RAYCAST!
        timeElapsed = 0;

        while (timeElapsed < dashTime)
        {
            timeElapsed += Time.deltaTime; // sets time elapsed in seconds
            float percentageComplete = timeElapsed / dashTime; // gets a decimal number between 0 - 1

            // Lerp interpolates the movement between both positions linearly,
            // but by adding the Dash AnimationCurve it seems more smooth.
            transform.position = Vector3.Lerp(startPosition, endPosition, dashCurve.Evaluate(percentageComplete));
            yield return new WaitForEndOfFrame(); // makes sure the while-loop runs at the same speed as Update.
        }
    }
}
