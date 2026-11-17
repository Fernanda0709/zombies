using UnityEngine;

public class Cerebro : MonoBehaviour
{
    void Update() { transform.Rotate(0, 90 * Time.deltaTime, 0); }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SumarCerebro();
            Destroy(gameObject);
        }
    }
}