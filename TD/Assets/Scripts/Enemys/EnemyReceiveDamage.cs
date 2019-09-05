using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int shield = 0;

    private bool active = true;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyController>();
        // todo: get move component
    }

    //todo: Create a health bar in the enemy
    //This is the function that receve the damage
    public int Damage
    {
        set
        {
            if (value > shield)
                hp -= value - shield;

            //todo: Unable the object until it needs to be called again;
            if (hp <= 0)
            {
                //todo: stop componet to move
                active = false;

                enemyController.RemoveEnemy(gameObject);

                GameObject.Destroy(gameObject);
            }
        }
    }

    public bool IsActive
    {
        get
        {
            return active;
        }
    }

    public int SetHP
    {
        set
        {
            hp = value;
        }
    }

    public int SetShield
    {
        set
        {
            shield = value;
        }
    }
}
