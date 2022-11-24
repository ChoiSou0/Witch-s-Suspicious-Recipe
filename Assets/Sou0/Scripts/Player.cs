using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer sp;

    public float Player_Speed;



    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
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

        if (X > 0)
            sp.flipX = false;
        else if (X < 0)
            sp.flipX = true;

        transform.position = new Vector2(transform.position.x + X,
            transform.position.y + Y);
    }
    
}