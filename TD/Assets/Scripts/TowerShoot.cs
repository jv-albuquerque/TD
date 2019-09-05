using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator anim = null;

    [Header("Properties")]
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform shootPosition = null;
    [SerializeField] private float cooldownToShoot = 1f;

    [SerializeField] private float attackRange = 1.5f;

    private Cooldown cdShoot;
    private bool lookingRight = true;


    private GameObject enemyToAttack = null;

    private EnemyController enemyController;

    private void Start()
    {
        cdShoot = new Cooldown(cooldownToShoot);
        enemyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyController>();

    }

    private void Update()
    {
        if (cdShoot.IsFinished)
        {
            TryShoot();
        }

        if (enemyToAttack)
        {
            if (lookingRight && enemyToAttack.GetComponent<Transform>().position.x < transform.position.x)
                Flip();
            else if (!lookingRight && enemyToAttack.GetComponent<Transform>().position.x > transform.position.x)
                Flip();
        }
    }

    private void TryShoot()
    {
        if (enemyToAttack != null &&
            Vector2.Distance(enemyToAttack.transform.position, transform.position) <= attackRange &&
            enemyToAttack.GetComponent<EnemyReceiveDamage>().IsActive)
        {
            cdShoot.Start();
            anim.SetTrigger("Shoot");
        }
        else
            FindEnemies();
    }


    public void Shoot()
    {
        GameObject proj = Instantiate(projectile, shootPosition.position, transform.rotation);
        proj.GetComponent<ProjectileMovement>().SetTarget = enemyToAttack;
    }

    private void FindEnemies()
    {
        enemyController.FindNearEnemy(transform.position, attackRange, ref enemyToAttack);
    }


    //Draw the Range of the attack
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Upgrade(int damage, float range, float newCD)
    {
        projectile.GetComponent<ProjectileMovement>().SetDamage = damage;
        attackRange = range;
        cdShoot = new Cooldown(newCD);
        cdShoot.Start();
    }

    private void Flip()
    {
        lookingRight = !lookingRight;
        anim.SetBool("LookingRight", lookingRight);
    }
}
