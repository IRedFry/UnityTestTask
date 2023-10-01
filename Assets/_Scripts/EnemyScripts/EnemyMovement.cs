using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public float targetRadius = 10.0f;
    public float targetError = 0.1f;

    [SerializeField]
    private Vector3 targetPoint = Vector3.negativeInfinity;
    [SerializeField]
    private GameObject enemySprite;
    private bool haveTarget = false;

    private EnemyAttacker enemyAttacker;
    private MovingEntity moving;
    private void Awake()
    {
        enemyAttacker = GetComponent<EnemyAttacker>(); 
        moving = GetComponent<MovingEntity>();
    }
    private void Update()
    {
        if (enemyAttacker.AttackDetector.canAttack)
        {
            targetPoint = enemyAttacker.AttackDetector.GetNearestTarget().transform.position;
            haveTarget = true;
        }

        if (!haveTarget)
        {
            float targetX = transform.position.x + Random.Range(-targetRadius, targetRadius);
            float targetY = transform.position.y + Random.Range(-targetRadius, targetRadius);
            targetPoint = new Vector3(targetX, targetY, -2);
            haveTarget = true;
        }
        else
        {
            if ((transform.position - targetPoint).magnitude <= targetError)
            {

                haveTarget = false;
                targetPoint = Vector3.negativeInfinity;
            }
            else
            {
                Vector3 delta = targetPoint - transform.position;
                moving.Move(delta);
                if (delta.x < 0)
                    enemySprite.transform.localScale = new Vector3(-Mathf.Abs(enemySprite.transform.localScale.x), enemySprite.transform.localScale.y, enemySprite.transform.localScale.z);
                else
                    enemySprite.transform.localScale = new Vector3(Mathf.Abs(enemySprite.transform.localScale.x), enemySprite.transform.localScale.y, enemySprite.transform.localScale.z);
            }
        }
    }
}
