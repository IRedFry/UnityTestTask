using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;
    public PlayerHealth PlayerHealth
    {
        get => playerHealth;
        private set => playerHealth = value;
    }

    [SerializeField]
    private MovingEntity playerMoving;
    public MovingEntity PlayerMoving
    {
        get => playerMoving;
        private set => playerMoving = value;
    }

    [SerializeField]
    private PlayerAttacker playerAttacker;
    public PlayerAttacker PlayerAttacker
    {
        get => playerAttacker;
        private set => playerAttacker = value;
    }

}
