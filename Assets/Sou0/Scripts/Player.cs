using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Player_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");

        float X = MoveX * Player_Speed * 0.01f;
        float Y = MoveY * Player_Speed * 0.01f;

        transform.position = new Vector2(transform.position.x + X,
            transform.position.y + Y);
    }

    private void Interaction()
    {
        
    }
}