using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public KeyCode dashKey;
    [Header("DashVars")]
    [SerializeField] private Transform dashPoint;
    
    private Vector3 endPosition;
    private Vector3 startPosition;

    [SerializeField] private float dashDistance;
    [SerializeField] private float dashTime; // in seconds
    private float timeElapsed = 0f;
    [SerializeField] private float dashCooldown;
    private bool isAvailable = true;

    [Header("Visuals")]
    [SerializeField] private AnimationCurve dashCurve;

    [SerializeField] private ParticleSystem dashParticles;
    [SerializeField] private ParticleSystem speedParticles;
    [SerializeField] private ParticleSystem cooldownParticles;

    void Update()
    {
        // Change controls when necessary. Currently it's RMB.
        if (Input.GetKeyDown(dashKey) && isAvailable)
            StartCoroutine(Dash());

        Debug.DrawRay(dashPoint.position, dashPoint.transform.forward, UnityEngine.Color.yellow); // Shows line forward in scene view.
    }

    // Dash is a coroutine, meaning it runs alongside other code in the Update functions.
    // This lets it act on its AnimationCurve without interfering with other code.
    private IEnumerator Dash()
    {
        StartCoroutine(DashCooldown(dashCooldown));
        if (Physics.OverlapBox(dashPoint.position, dashPoint.localScale / 2, dashPoint.rotation).Length > 1)
        {
            // Debug.Log("Box has been overlapped, no Dash available");
            yield return null;
        } else
        {
            if (dashParticles != null) { dashParticles.Play(); }

            if (speedParticles != null) { speedParticles.Play(); }
            
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

    // Returns exact Vector3 of the dash's end point.
    private Vector3 GetDashLocation()
    {
        RaycastHit hit;

        // if something is within a certain distance of dashPoint, set endPosition to hit. If not, use end of distance.
        if (Physics.Raycast(dashPoint.position, dashPoint.transform.forward, out hit, dashDistance))
        {
            // Debug.Log("Raycast Hit");
            return new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.forward * 0.5f; // goes backwards by .5 to not clip into walls.
        }
        else
        {
            // Debug.Log("Raycast no hit");
            return transform.position + transform.forward * dashDistance; // return forward + dashDistance
        }
    }

    private IEnumerator DashCooldown(float cooldown)
    {
        isAvailable = false;
        float dashCooldownTime = cooldown;
        while (dashCooldownTime > 0)
        {
            dashCooldownTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame(); // makes sure the while-loop runs at the same speed as Update.
        }
        if (cooldownParticles != null) { cooldownParticles.Play(); }
        isAvailable = true;
    }
}
