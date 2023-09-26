using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private Tower towerPrefab;
    [SerializeField] private Transform cashedTransform;

    [Header("Settings")]

    [SerializeField] private int towerPlaceCost;

    private Tower tower;

    private bool CanPlaceTower()
    {
        return tower == null;
    }

    private void OnMouseDown()
    {
        if (CanPlaceTower() && WalletController.CheckEnoughCoins(towerPlaceCost))
        {
            WalletController.SubtractCoins(towerPlaceCost);
            tower = Instantiate(towerPrefab, cashedTransform);
        }

        else if (!CanPlaceTower() && WalletController.CheckEnoughCoins(tower.UpgradeCost) && tower.CanUpgrade())
        {
            WalletController.SubtractCoins(tower.UpgradeCost);
            tower.UpgradeTower();
        }
    }
}
