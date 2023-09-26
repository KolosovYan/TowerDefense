using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemyController
{
    [Header("Setting")]

    [SerializeField] private int currentHealth;
    [SerializeField] private int enemyCoinsReward;

    public void DealDamage(int damage)
    {
        SubtractHealth(damage);
    }

    private void SubtractHealth(int value)
    {
        currentHealth -= value;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            WalletController.AddCoins(enemyCoinsReward);
            Destroy(gameObject);
        }
    }
}
