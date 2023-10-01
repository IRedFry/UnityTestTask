using UnityEngine;

public abstract class AttackingEntity : MonoBehaviour
{
    public float damageAmout;
    public float forceAmout = 10.0f;

    [SerializeField]
    private AttackDetecter attackingDetector;
    public AttackDetecter AttackDetector
    {
        get => attackingDetector;
        private set => attackingDetector = value;
    }
    public abstract void Attack(GameObject target);
    public abstract void Attack();


}
