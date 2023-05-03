using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public float maxDistance = 20f; // distancia máxima permitida para seguir al jugador

    void Start() {}

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Verificar si el enemigo está dentro del radio de distancia permitido
        if (distanceToPlayer <= maxDistance) {
            enemy.SetDestination(player.position);
        }
    }
}
