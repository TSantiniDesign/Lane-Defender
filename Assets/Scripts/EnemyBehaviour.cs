using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float savedSpeed;
    [SerializeField] private float health;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savedSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            speed = 0;
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 10f);
            health--;
            Invoke("ReturnSpeed", .2f);
        }
    }

    void ReturnSpeed()
    {
        speed = savedSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Speed", speed);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed *
                Time.deltaTime);
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 100f);
            Destroy(gameObject);
        }
    }
}
