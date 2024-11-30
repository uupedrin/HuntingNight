using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEnemy : MonoBehaviour
{
    private void OnDestroy()
    {
        TopEnemyManager.instance.enemies.Remove(gameObject);
    }
}
