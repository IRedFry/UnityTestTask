using UnityEngine;

public class PlayerAttacker : AttackingEntity
{
    public SpriteRenderer weaponSprite;

    private BonusWeaponBase weaponBonus;
    private bool hasWeapon = false;
    private int bulletAmount = 0;

    public void SetWeapon(BonusWeaponBase wBonus)
    {
        if (weaponBonus != null)
            ClearWeapon();
        weaponBonus = wBonus;
        hasWeapon = true;
        bulletAmount = wBonus.bulletAmount;
        weaponSprite.sprite = wBonus.bonusSprite;
    }
    public override void Attack(GameObject target)
    {
        if (target.tag == "Enemy")
        {
            target.GetComponent<EnemyHealth>().GetDamage(damageAmout);
            Vector2 forceDirection = (target.transform.position - transform.position).normalized;
            target.GetComponent<MovingEntity>().ApplyForce(forceDirection, forceAmout);
        }
    }

    public override void Attack()
    {
        if (AttackDetector.canAttack)
        {
            Attack(AttackDetector.GetNearestTarget());
            if (hasWeapon)
            {
                bulletAmount--;
                if (bulletAmount == 0)
                    ClearWeapon();
            }
        }
    }

    private void ClearWeapon()
    {
        hasWeapon = false;
        weaponBonus.OnBonusEnd();
        weaponSprite.sprite = null;
        weaponBonus = null;
    }
}
