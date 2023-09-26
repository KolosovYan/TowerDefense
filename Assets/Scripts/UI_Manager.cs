using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private Text coinsText;
    [SerializeField] private GameObject LoseText;
    [SerializeField] private Text nemText;
    [SerializeField] private Text hpText;

    public void UpdateCoinsText(int coins)
    {
        coinsText.text = coins.ToString();
    }

    public void ShowLoseText()
    {
        LoseText.SetActive(true);
    }

    public void NotEnoughCoins(int cost)
    {
        StartCoroutine(ShowNECText(cost));
    }

    public void UpdateHPText(int value)
    {
        hpText.text = value.ToString();
    }

    private IEnumerator ShowNECText(int value)
    {
        nemText.text = $"Not enough money, need {value} coins";
        yield return new WaitForSeconds(0.5f);
        nemText.text = string.Empty;
    }
}
