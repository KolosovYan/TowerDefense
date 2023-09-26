using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private SpriteRenderer currentTowerRenderer;
    [SerializeField] private List<TowerData> towersData;
    [SerializeField] private CircleCollider2D AttackRangeCollider;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform cashedTransform;

    [Header("Settings")]

    [SerializeField] private float defaultAttackRange;
    [SerializeField] private int defaultAttackPower;
    [SerializeField] private float defaultAttackSpeed;

    public int UpgradeCost { get; private set; }
    private int AttackPower;
    private float AttackSpeed;
    private int currentTowerIndex;

    [SerializeField] private List<GameObject> EnemysInRange;

    private void OnEnable()
    {
        currentTowerIndex = 0;
        SetDefaultSettings();
        StartCoroutine(AttackTarget());
    }

    public bool CanUpgrade()
    {
        if (currentTowerIndex < towersData.Count)
            return true;
        else
        {
            Debug.Log("Can't Upgrade");
            return false;
        }
    }
    private void SetDefaultSettings()
    {
        UpgradeCost = UpgradeCost = towersData[currentTowerIndex].TowerCost;
        AttackPower = defaultAttackPower;
        AttackRangeCollider.radius = defaultAttackRange;
        AttackSpeed = defaultAttackSpeed;
    }

    private void SetTowerSettings()
    {
        currentTowerRenderer.sprite = towersData[currentTowerIndex].TowerSprite;
        UpgradeCost = towersData[currentTowerIndex].TowerCost;
        AttackPower = towersData[currentTowerIndex].TowerAttackPower;
        AttackSpeed = towersData[currentTowerIndex].TowerAttackSpeed;
        AttackRangeCollider.radius = towersData[currentTowerIndex].TowerAttackRange;
    }

    public void UpgradeTower()
    {
        SetTowerSettings();
        currentTowerIndex++;
        //Debug.Log($"Current Tower Index {currentTowerIndex} CurrentCount{towersData.Count}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            EnemysInRange.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EnemysInRange.Remove(other.gameObject);
    }

    private IEnumerator AttackTarget()
    {
        while (BaseController.InGame)
        {
            if (EnemysInRange.Count != 0)
            {
                Attack(EnemysInRange[0]);
                yield return new WaitForSeconds(AttackSpeed);
            }

            else
            {
                yield return new WaitWhile(() => EnemysInRange.Count != 0);
            }
        }

    }

    private void Attack(GameObject target)
    {
        Bullet temp = Instantiate(bulletPrefab, cashedTransform.position, Quaternion.identity);
        temp.SetTargetNDamage(target.transform, AttackPower);
    }
}
