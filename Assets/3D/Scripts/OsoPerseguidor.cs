using UnityEngine;
using UnityEngine.AI;

public class OsoPerseguidor : MonoBehaviour
{
    public Transform objetivo;      // el zombie
    public float velocidad = 3.5f;  // menor que la del zombie
    NavMeshAgent agente;

    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.speed = velocidad;
    }

    void Update()
    {
        if (objetivo != null) agente.SetDestination(objetivo.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance.PerderJuego();
    }
}