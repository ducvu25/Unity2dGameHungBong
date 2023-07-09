using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float speed = 3f;
    int score = 0;
    public bool facing = false;
    float time_facing = 0f;
    bool gameOver = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.Run();
        this.Facing();
        if (time_facing > 0)
            time_facing -= Time.deltaTime;
        if (time_facing < 0)
        {
            facing = false;
            time_facing = 0;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void Run()
    {
        float move_x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if ((move_x < 0 && this.transform.position.x <= -4)
         || (move_x > 0 && this.transform.position.x >= 4))
            move_x = -move_x;
        this.transform.position = this.transform.position + new Vector3(move_x, 0, 0);
    }
    void Facing()
    {
        if (Input.GetAxis("Vertical") != 0 && facing == false)
        {
            facing = true;
            time_facing = 1.5f;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
    public void AddScore(int value)
    {
        score += value;
        // if (score < 0)
        //     gameOver = true;
    }
    public int GetScore()
    {
        return score;
    }
}
