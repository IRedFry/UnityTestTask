using UnityEngine;

public class EnemyHealth : LivingEntity
{
    [SerializeField]
    private BonusGenerator bonusGenerator;

    protected override void OnAwake()
    {
        base.OnAwake();
        bonusGenerator = GameObject.Find("BonusGenerator").GetComponent<BonusGenerator>();
    }
    protected override void OnDeath()
    {
        LeaveBonus();
        Destroy(gameObject);
    }

    private void LeaveBonus()
    {
        bonusGenerator.GenerateRandomBonus(transform.position);
    }
}
