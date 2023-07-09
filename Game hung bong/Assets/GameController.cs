using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    playerController player;
    public GameObject[] listItem;
    public AudioSource audioSource;
    public AudioClip[] audioList = new AudioClip[2];
    float time = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        this.NewItem(0, 5, 0);
    }
    void Update()
    {
        if (time <= 0)
        {
            time = Random.Range(0, 4 - player.GetScore() / 100);
            float x = Random.Range(-4, 4);
            NewItem(x, 5, 0);
        }
        else
            time -= Time.deltaTime;
    }
    public void PlayAudio(int n)
    {
        if (audioSource)
            audioSource.PlayOneShot(audioList[n]);
    }
    public void NewItem(float x, float y, float z)
    {
        int randomInt = (int)Random.Range(0, 6);
        if (randomInt >= 4)
        {
            Instantiate(listItem[4], new Vector3(x, y, z), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else
            Instantiate(listItem[randomInt], new Vector3(x, y, z), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
