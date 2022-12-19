using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed;
    private float MaxSpeed;

    private Rigidbody2D rb2D;
    private GameObject NowNPC;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // 움직임 함수
    private void Move()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");

        float X = MoveX * Speed * 2;
        float Y = MoveY * Speed * 2;

        Vector3 GetVel = new Vector3(X, Y, 0);
        rb2D.velocity = GetVel;
    }

}