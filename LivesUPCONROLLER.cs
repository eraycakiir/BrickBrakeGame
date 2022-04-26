using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUPCONROLLER : MonoBehaviour
{
    [SerializeField]
    public float speed;
    void Update()    //canýmýzý arttýran top methodu
    {
        transform.Translate(Vector2.down*Time.deltaTime*speed);
    }
}
