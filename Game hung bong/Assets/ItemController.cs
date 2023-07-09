using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    playerController player;
    GameController gameManager;
    public int score;
    public float speed;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Update()
    {

        float move_y = speed * Time.deltaTime;
        this.transform.position = this.transform.position + new Vector3(0, -move_y, 0);
        if (this.transform.position.y < -4.6)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !player.facing)
        {
            if (score < 0)
                gameManager.PlayAudio(1);
            else
                gameManager.PlayAudio(0);
            player.AddScore(score);
            Destroy(gameObject);
        }
    }
}
