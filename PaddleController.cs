using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float leftTarget, rightTarget;
    GameManager gameManager;
    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (gameManager.gameOver)
        {
            return;
        }
        // Bu Plant�n Sa�-Sol Hareketini Sa�lad�
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right *h* Time.deltaTime*speed);
       
        
        
        // Bu k��eleri s�n�rlaman�n birinci yolu
        if(transform.position.x < leftTarget)
        {
            transform.position = new Vector2(leftTarget, transform.position.y);
        }
        if(transform.position.x > rightTarget)
        {
         transform.position = new Vector2(rightTarget,transform.position.y);
        }

        // Bu k��eleri s�n�rlaman�n ikinci yolu
        Vector2 temp = transform.position;
        temp.x= Mathf.Clamp(temp.x,leftTarget,rightTarget);
        transform.position=temp;
    }


    
    private void OnTriggerEnter2D(Collider2D other)  //Taglardan blocklara ulast�k blocktan gelen toplar canlar�m�z� artt�rd�
    {
       if(other.gameObject.tag == "liveupball")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "skorupball")
        {
            gameManager.UpdateLives(5);
            Destroy(other.gameObject);
        }
    }
}
