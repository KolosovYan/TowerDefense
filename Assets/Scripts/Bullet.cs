using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private Transform cashedTransform;

    [Header("Settings")]

    [SerializeField] private float bulletSpeed;

    private Transform target;
    private int damage;
    private IEnemyController enemyController;

    public void SetTargetNDamage(Transform enemy, int dmg)
    {
        target = enemy;
        damage = dmg;
        enemyController = target.GetComponent<IEnemyController>();
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while(target != null && Vector2.Distance(cashedTransform.position, target.position) > 0.5)
        {
            cashedTransform.position = Vector2.MoveTowards(cashedTransform.position, target.position, bulletSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
            if (target == null)
            {
                Destroy(gameObject);
            }
        }
        if (target != null)
            enemyController.DealDamage(damage);
        Destroy(gameObject);
    }
}
