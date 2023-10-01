public class BonusAK : BonusWeaponBase
{
    private void Awake()
    {
        bonusDuration = 0;
        bulletAmount = 5;
        damageBonus = 30;
    }
    public override void OnBonusEnd()
    {
        player.PlayerAttacker.damageAmout -= damageBonus;
    }

    public override void Use(PlayerUnit player)
    {
        this.player = player;
        player.PlayerAttacker.damageAmout += damageBonus;
    }
}
