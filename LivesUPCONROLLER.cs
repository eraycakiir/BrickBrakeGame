using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUPCONROLLER : MonoBehaviour
{
    [SerializeField]
    public float speed;
    void Update()    //can�m�z� artt�ran top methodu
    {
        transform.Translate(Vector2.down*Time.deltaTime*speed);
    }
}
