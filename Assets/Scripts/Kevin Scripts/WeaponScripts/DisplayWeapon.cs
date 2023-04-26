using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayWeapon : MonoBehaviour
{

    public Weapons weapon;

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public Image modelImage;

    public TMP_Text damageText;
        
    void Start()
    {
        nameText.text = weapon.name;
        descriptionText.text = weapon.description;

        modelImage.sprite = weapon.model;

        damageText.text = weapon.damage.ToString();
    }
}
