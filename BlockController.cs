using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField]
    GameObject brickEffect;

    GameManager gameManager;
    [SerializeField]
    GameObject liveupPrefab;
    private void Awake()
    {
      gameManager= Object.FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ball")             //skor arttýrdýk
        {
            Instantiate(brickEffect,transform.position,transform.rotation);
            gameManager.UpdateScore(5);

            int randomChaince = Random.Range(1, 101);
            if(randomChaince > 60)
            {
                Instantiate(liveupPrefab,transform.position,transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
