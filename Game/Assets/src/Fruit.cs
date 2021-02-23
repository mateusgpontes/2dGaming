using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{   
    public GameObject Collected;
    public int Score;

    private SpriteRenderer SpriteRenderer;
    private CircleCollider2D CircleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CircleCollider2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            SpriteRenderer.enabled = false;
            CircleCollider2D.enabled = false;
            Collected.SetActive(true);

            int score = GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText(score);
            
            Destroy(gameObject, 0.50f);
        }
    }
}
