using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Gameplay/New Tower Data")]
public class TowerData : ScriptableObject
{
    public Sprite TowerSprite;
    public int TowerCost;
    public int TowerAttackPower;
    public float TowerAttackRange;
    public float TowerAttackSpeed;
}
