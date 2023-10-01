using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackDetecter : MonoBehaviour
{
    public List<string> targetTags = new List<string>();
    public bool canAttack { get; private set; }

    [SerializeField]
    protected List<Collider2D> targetColliders = new List<Collider2D>();

    public bool CheckTag(string tag)
    {
        if (targetTags.Contains(tag))
            return true;

        return false;
    }

    public GameObject GetNearestTarget()
    {
        return targetColliders.OrderBy(i => (i.transform.position - transform.position).magnitude).FirstOrDefault().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckTag(collision.tag))
        {
            canAttack = true;
            targetColliders.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckTag(collision.tag))
        {
            targetColliders.Remove(collision);
            if (targetColliders.Count == 0)
                canAttack = false;
        }
    }
}
