using TMPro;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    public RectTransform healthImageRect;
    public TextMeshProUGUI healthText;

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;

    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        health = maxHealth;
    }
    public float GetDamage(float amount)
    {
        health = Mathf.Max(0, health - amount);
        healthImageRect.sizeDelta = new Vector2(health / maxHealth, healthImageRect.sizeDelta.y);
        healthText.text = "Health: " + health + " / " + maxHealth;
        if (health == 0)
            OnDeath();

        return health;
    }

    public float Heal(float amount)
    {
        health = Mathf.Min(maxHealth, health + amount);
        return health;
    }

    protected abstract void OnDeath();
}
