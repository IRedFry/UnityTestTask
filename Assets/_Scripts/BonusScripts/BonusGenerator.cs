using System.Collections.Generic;
using UnityEngine;


public class BonusGenerator : MonoBehaviour
{
    public List<GameObject> bonusPrefabs = new List<GameObject>();

    public void GenerateRandomBonus(Vector2 position)
    {
        GameObject bonusPrefab = bonusPrefabs[Random.Range(0, bonusPrefabs.Count)];
        GameObject bonusInstance = Instantiate(bonusPrefab, new Vector3(position.x, position.y, -2), Quaternion.identity);
        bonusInstance.name = bonusPrefab.name;
    }
}
