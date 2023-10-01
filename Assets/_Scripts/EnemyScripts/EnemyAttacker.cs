using UnityEngine;

public class EnemyAttacker : AttackingEntity
{
    public override void Attack(GameObject target)
    {
        if (target.tag == "Player")
        {
            target.GetComponent<PlayerHealth>().GetDamage(damageAmout);
            Vector2 forceDirection = (target.transform.position - transform.position).normalized;
            target.GetComponent<MovingEntity>().ApplyForce(forceDirection, forceAmout);
        }
    }

    public override void Attack()
    {
        if (AttackDetector.canAttack)
            Attack(AttackDetector.GetNearestTarget());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Attack();
        }
    }

}
