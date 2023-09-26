using UnityEngine;

public class BaseController : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private UI_Manager ui_Manager;

    [Header("Settings")]

    [SerializeField] private int baseMaxHealth;

    private int baseCurrentHealth;
    public static BaseController instance;
    public static bool InGame;

    private void Start()
    {
        instance = instance == null ? this : instance;
        baseCurrentHealth = baseMaxHealth;
        ui_Manager.UpdateHPText(baseCurrentHealth);
        InGame = true;
    }

    public void HitBase(int damage)
    {
        baseCurrentHealth -= damage;
        if (baseCurrentHealth <= 0)
        {
            InGame = false;
            baseCurrentHealth = 0;
            ui_Manager.ShowLoseText();
        }
        ui_Manager.UpdateHPText(baseCurrentHealth);
    }
}
