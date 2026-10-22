using UnityEngine;

public class ShotgunBullet2D : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 20f;
    public float lifeTime = 3f;

    [Header("Direction Mapping")]
    [Tooltip("Check this if your bullet sprite is drawn pointing up. Uncheck if it points right.")]
    public bool movesUpwards = false;

    private Rigidbody2D rb2d;

    private void Start()
    {
        Destroy(gameObject, lifeTime);

        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            Vector2 travelDirection = movesUpwards ? transform.up : transform.right;


            rb2d.linearVelocity = travelDirection * speed;

            rb2d.linearVelocity = travelDirection * speed;

        }
    }

    private void Update()
    {
        if (rb2d == null)
        {
            Vector3 localMoveDir = movesUpwards ? Vector3.up : Vector3.right;
            transform.Translate(localMoveDir * speed * Time.deltaTime, Space.Self);
        }
    }
}
