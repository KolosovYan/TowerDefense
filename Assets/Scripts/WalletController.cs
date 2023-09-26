using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletController : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private UI_Manager ui_Manager;

    public static WalletController instance;
    [SerializeField] private int CurrentCoins;

    private void Start()
    {
        instance = instance == null ? this : instance;
        ui_Manager.UpdateCoinsText(CurrentCoins);
    }

    public static bool CheckEnoughCoins(int value)
    {
        bool temp = instance.CurrentCoins >= value ? true : false;
        if (!temp)
        {
            instance.ui_Manager.NotEnoughCoins(value);
        }
        return temp;
    }

    public static void AddCoins(int value)
    {
        instance.CurrentCoins += value;
        instance.ui_Manager.UpdateCoinsText(instance.CurrentCoins);
    }

    public static void SubtractCoins(int value)
    {
        instance.CurrentCoins -= value;
        instance.ui_Manager.UpdateCoinsText(instance.CurrentCoins);
    }
}
