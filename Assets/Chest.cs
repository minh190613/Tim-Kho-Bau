using UnityEngine;

public class Chest : MonoBehaviour
{
    public int scoreRW = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chest opened! Score: " + scoreRW);

            other.transform.GetComponent<MoveScirpt>().AddPoint(scoreRW);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Chest opened! Score: " + scoreRW);

            collision.collider.transform.GetComponent<MoveScirpt>().AddPoint(scoreRW);

            Destroy(gameObject);
        }
    }
}
