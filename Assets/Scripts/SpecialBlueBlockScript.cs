using UnityEngine;

public class SpecialBlueBlockScript : MonoBehaviour
{
    public Vector2 moveOffset = new Vector2(3f, 0f);
    public float speed = 1f;

    private Vector2 startPos;
    private Vector2 endPos;
    private float progress = 0f;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + moveOffset;
    }

    void Update()
    {
        progress += direction * speed * Time.deltaTime;

        if (progress >= 1f)
        {
            progress = 1f;
            direction = -1;
        }
        else if (progress <= 0f)
        {
            progress = 0f;
            direction = 1;
        }

        transform.position = Vector2.Lerp(startPos, endPos, progress);
    }
}