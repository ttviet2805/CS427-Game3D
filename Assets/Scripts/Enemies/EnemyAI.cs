using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChageDirFloat = 2f;
    private enum State
    {
        Roaming
    }

    private State state;
    private EnemyPathFiding enemyPathFiding;

    private void Awake()
    {
        enemyPathFiding = GetComponent<EnemyPathFiding>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFiding.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChageDirFloat);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
