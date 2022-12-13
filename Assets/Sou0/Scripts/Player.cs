using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Player_Speed;

    private GameObject NowNPC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Interaction();
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            NowNPC.GetComponentInParent<NPC>().ActionKey();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        NowNPC = collision.gameObject;
        Debug.Log(NowNPC);
    }
}