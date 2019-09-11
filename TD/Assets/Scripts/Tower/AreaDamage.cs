using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsEnemy = ~0;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int damage = 10;
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Damage()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsEnemy);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyReceiveDamage>().Damage = damage;
        }
    }

    public int SetDamage { get => damage; set => damage = value; }
}
