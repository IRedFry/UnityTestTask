using System.Collections;
using UnityEngine;

public class BonusApplier : MonoBehaviour
{
    private PlayerUnit playerUnit;
    private Inventory inventory;
    private void Awake()
    {
        playerUnit = GetComponent<PlayerUnit>();
        inventory = GetComponent<Inventory>();
    }
    public void ApplyBonus()
    {
        BonusBase bonus = inventory.PopBonus();
        if (bonus != null)
        {
            bonus.Use(playerUnit);
            if (bonus.bonusType == BonusBase.BonusType.Temporary)
                StartCoroutine("BonusEffect", bonus);
            else if (bonus.bonusType == BonusBase.BonusType.Weapon)
                playerUnit.PlayerAttacker.SetWeapon((BonusWeaponBase)bonus);
        }

    }

    protected IEnumerator BonusEffect(BonusBase bonus)
    {
        yield return new WaitForSeconds(bonus.bonusDuration);
        bonus.OnBonusEnd();
    }
}
