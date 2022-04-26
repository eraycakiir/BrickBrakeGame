using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrckeBrokenController : MonoBehaviour
{
    [SerializeField]
    private Sprite brokenImage;
    int count = 0;
    [SerializeField]
    GameObject brickBrokenEffect;

    GameManager gameManager;

    [SerializeField]
    GameObject skorupPrefab;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        count = 0;
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ball")        //Skor artýrdýk ve kýrýlma Imgsini monte ettik
        {
            count++;
            if (count == 1)
            {
                GetComponent<SpriteRenderer>().sprite = brokenImage;
                gameManager.UpdateScore(10);
            }
            else if (count == 2)
            {
                Instantiate(brickBrokenEffect, transform.position, transform.rotation);
                gameManager.UpdateScore(10);
                int randomChaince = Random.Range(1, 101);
                if (randomChaince > 60)
                {
                    Instantiate(skorupPrefab, transform.position, transform.rotation);
                }
            }

        }
    }
}
