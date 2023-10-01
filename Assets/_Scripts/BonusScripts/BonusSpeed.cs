public class BonusSpeed : BonusBase
{

    public override void Use(PlayerUnit player)
    {
        this.player = player;
        this.player.PlayerMoving.speed *= 2.0f;
    }

    public override void OnBonusEnd()
    {
        player.PlayerMoving.speed /= 2.0f;
    }
}
