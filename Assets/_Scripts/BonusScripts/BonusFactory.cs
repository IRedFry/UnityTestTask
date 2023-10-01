using System.Collections.Generic;
using UnityEngine;

public class BonusFactory
{
    private static BonusFactory instance;

    private List<string> bonusNames = new List<string>();    
    private BonusFactory()
    {
        bonusNames.Add("BonusSpeed");
        bonusNames.Add("BonusAK");
    }

    public static BonusFactory GetInstance()
    {
        if (instance == null)
            instance = new BonusFactory();
        return instance;
    }

    public BonusBase CreateBonus(string bonusName)
    {
        if (bonusNames.Contains(bonusName))
        {
            BonusBase b;
            switch (bonusName)
            {
                case "BonusSpeed":
                    b = ScriptableObject.CreateInstance<BonusSpeed>();
                    b.bonusType = BonusBase.BonusType.Temporary;
                    break;
                case "BonusAK":
                    b =  ScriptableObject.CreateInstance<BonusAK>();
                    b.bonusType = BonusBase.BonusType.Weapon;
                    break;
                default:
                    b = null;
                    break;
            }
            b.bonusName = bonusName;
            return b;
        }
        return null;
    }

    public string GetRandomBonusName()
    {
        return bonusNames[UnityEngine.Random.Range(0, bonusNames.Count - 1)];
    }
}
