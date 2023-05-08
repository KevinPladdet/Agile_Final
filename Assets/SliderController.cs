using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] PlayerMovement playermovement;
    [Range(0,100)]
    public float stamina;
    public float maxStamina = 100;

    public RectTransform staminaBar;

    float percentUnit;
    float staminaPercentUnit;

    private void Start()
    {
        percentUnit= 1f / staminaBar.anchorMax.x;
        staminaPercentUnit = 100f / maxStamina;
    }
    private void Update()
    {
        stamina = playermovement.stamina;
        float currentStaminaPercent = stamina * staminaPercentUnit;

        staminaBar.anchorMax = new Vector2((currentStaminaPercent * percentUnit)/ 100f, staminaBar.anchorMax.y);

    }
}
