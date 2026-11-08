using UnityEngine;
using UnityEngine.UI;

public class SpecialRedBlockScript : MonoBehaviour
{
    public GameObject textObject;
    public int points;

    Text textComponent;
    PlayerScript playerScript;

    bool isX = false;
    bool isDestroyed = false;

    void Start()
    {
        textComponent = textObject.GetComponent<Text>();
        textComponent.text = "O";

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball") || isDestroyed)
            return;

        isX = !isX;
        textComponent.text = isX ? "X" : "O";

        var blocks = FindObjectsOfType<SpecialRedBlockScript>();

        foreach (var block in blocks)
        {
            if (!block.isX)
                return;
        }

        int totalPoints = 0;

        foreach (var block in blocks)
        {
            block.isDestroyed = true;

            totalPoints += block.points;

            Destroy(block.gameObject);
        }

        playerScript.BlockDestroyed(totalPoints);
    }
}
