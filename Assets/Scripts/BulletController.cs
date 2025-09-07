using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(20, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
