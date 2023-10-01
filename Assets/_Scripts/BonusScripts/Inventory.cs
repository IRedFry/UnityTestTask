using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private BonusBase bonus;
    [SerializeField]
    private int bonusCount = 0;
    [SerializeField]
    private Image bonusImage;
    [SerializeField]
    private TextMeshProUGUI quantityText;

    public Sprite emptyBonusImage;
    public BonusBase PopBonus()
    {
        if (bonusCount == 0)
            return null;
        else
        {
            bonusCount--;
            if (bonusCount == 1)
                quantityText.text = "";
            else if (bonusCount == 0)
                bonusImage.sprite = emptyBonusImage;
            
            return bonus;
        }
    }

    public void ChangeBonus(BonusBase newBonus)
    {
        if (bonusCount != 0 && bonus.bonusName == newBonus.bonusName)
        {
            bonusCount++;
            quantityText.text = bonusCount.ToString();
        }
        else
        {
            bonus = newBonus;
            bonusImage.sprite = newBonus.bonusSprite;
            bonusCount = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bonus")
        {
            BonusBase b = BonusFactory.GetInstance().CreateBonus(collision.collider.name);
            if (b != null)
            {
                b.bonusSprite = collision.collider.GetComponent<SpriteRenderer>().sprite;
                ChangeBonus(b);
            }
            Destroy(collision.gameObject);
        }
    }
}
