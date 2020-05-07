using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement EnemyPrefab;
    [SerializeField] Transform EnemyParentTransform;
    [SerializeField] Text SpawnedEnemies;
    [SerializeField] int Score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedSpawningEnemies());
        SpawnedEnemies.text = Score.ToString();
    }

    IEnumerator RepeatedSpawningEnemies()
    {
        while (true)
        {
            AddScore();
            var NewEnemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            NewEnemy.transform.parent = EnemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        Score++;
        SpawnedEnemies.text = Score.ToString();
    }
}
