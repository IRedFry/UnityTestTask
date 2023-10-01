using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    public float speed = 4.0f;

    private Vector2 forceVector = Vector2.zero;
    [SerializeField]
    private float forceAmount = 0.0f;
    [SerializeField]
    private float forceFadeSpeed = 0.5f;

    public void Move(Vector2 direction)
    {
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void ApplyForce(Vector2 direction, float amount)
    {
        forceVector = direction.normalized;
        forceAmount = amount;
    }

    private void FixedUpdate()
    {
        if (forceAmount != 0.0f)
        {
            transform.Translate(forceVector * forceAmount * Time.deltaTime);
            forceAmount *= forceFadeSpeed;
            if (forceAmount < 0.1f)
            {
                forceAmount = 0.0f;
                forceVector = Vector2.zero;
            }
        }
    }
}
