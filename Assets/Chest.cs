using UnityEngine;

public class Chest : MonoBehaviour
{
    public int scoreRW = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chest opened! Score: " + scoreRW);
            Destroy(gameObject);
        }
    }
}
