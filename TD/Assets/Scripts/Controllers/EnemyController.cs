using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();

        //Find all enemies in the sceane, only necessary in the test fase
        //-----------------------
        GameObject[] tempEnemies;
        tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in tempEnemies)
        {
            enemies.Add(enemy);
        }

        tempEnemies = null;
        //-----------------------
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    // Find the enemy that is in the range of the tower
    public void FindNearEnemy(Vector2 towerPosition, float towerRange, ref GameObject enemyInRange)
    {
        enemyInRange = null;
        foreach (var enemy in enemies)
        {
            //todo: choose the enemy closest to the finish position
            if (enemy != null && Vector2.Distance(enemy.transform.position, towerPosition) <= towerRange)
                enemyInRange = enemy;
        }
    }
}
