using UnityEngine;

public class SpecialYellowBlockScript : MonoBehaviour
{
    public float speed = 2f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float direction = Random.Range(0, 2) == 0 ? 1f : -1f;

        rb.velocity = new Vector2(speed * direction, 0);
    }
}