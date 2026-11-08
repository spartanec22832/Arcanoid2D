using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
    public GameObject textObject;

    public int hitsToDestroy;
    public int points;

    Text textComponent;

    PlayerScript playerScript;

    void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();

            textComponent.text = hitsToDestroy.ToString();
        }

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        hitsToDestroy--;

        if (hitsToDestroy <= 0)
        {
            Destroy(gameObject);

            playerScript.BlockDestroyed(points);
        }
        else if (textComponent != null)
        {
            textComponent.text = hitsToDestroy.ToString();
        }
    }

}
