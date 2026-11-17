using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour
{
    public float duracion = 0.6f;   // tiempo que tarda en aparecer
    Vector3 escalaFinal;
    bool escalaGuardada = false;

    void Awake()
    {
        GuardarEscala();

        // Siempre atravesable: el zombie la cruza sin chocar
        foreach (var c in GetComponentsInChildren<Collider>())
            c.isTrigger = true;
    }

    void GuardarEscala()
    {
        if (escalaGuardada) return;
        escalaFinal = transform.localScale;
        escalaGuardada = true;
    }

    void OnEnable()
    {
        GuardarEscala();
        StartCoroutine(Aparecer());
    }

    IEnumerator Aparecer()
    {
        transform.localScale = Vector3.zero;

        float t = 0;
        while (t < duracion)
        {
            t += Time.deltaTime;
            transform.localScale = escalaFinal * (t / duracion);
            yield return null;
        }

        transform.localScale = escalaFinal;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance.CruzarPuerta();
    }
}