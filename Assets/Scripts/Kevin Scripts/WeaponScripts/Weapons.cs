using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapons : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite model;

    public int damage;
}
