using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement EnemyPrefab;
    [SerializeField] Transform EnemyParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedSpawningEnemies());
    }

    IEnumerator RepeatedSpawningEnemies()
    {
        while (true)
        {
            var NewEnemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            NewEnemy.transform.parent = EnemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
