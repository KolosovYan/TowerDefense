using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private Transform cashedTransform;

    [Header("Setting")]

    [SerializeField] private float moveSpeed;
    [SerializeField] private int enemyDamage;

    public List<Transform> path;
    private Transform currentWaypoint;

    public void SetPath(List<Transform> waypoints)
    {
        path = waypoints;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        int index = 0;

        while (cashedTransform.position != path[path.Count - 1].position && BaseController.InGame)
        {
            currentWaypoint = path[index];
            cashedTransform.position = Vector2.MoveTowards(cashedTransform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

            if (cashedTransform.position == currentWaypoint.position)
                index++;
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
        BaseController.instance.HitBase(enemyDamage);
    }
}
