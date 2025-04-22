using UnityEngine;

public class Bultet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Bắn trúng player rùi");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
