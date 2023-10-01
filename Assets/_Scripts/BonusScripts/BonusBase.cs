using UnityEngine;

public abstract class BonusBase : ScriptableObject
{

    public enum BonusType { Temporary = 0, Armor, Weapon};

    public Sprite bonusSprite;

    public string bonusName;

    public float bonusDuration = 2.0f;
    public BonusType bonusType;

    protected PlayerUnit player;
    public abstract void Use(PlayerUnit player);
    public abstract void OnBonusEnd();
}
