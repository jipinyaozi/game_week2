using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject leftleg;
    public GameObject rightleg;
    Rigidbody2D leftlegRB;
    Rigidbody2D rightlegRB;
    public Rigidbody2D rb;
    public Animator anim;
    float speed = 1.5f;
    float stepWait = 0.5f;
    public float jumpforce = 10;
    private bool isonground;
    public float posRadius;
    public LayerMask ground;
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        leftlegRB = leftleg.GetComponent<Rigidbody2D>();
        rightlegRB = rightleg.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("walk_right");
                StartCoroutine(MoveRight(stepWait));
            }
            else
            {
                anim.Play("walk_left");
                StartCoroutine(Moveleft(stepWait));
            }
        }
        else
        {
            anim.Play("idle");
        }
        isonground = Physics2D.OverlapCircle(playerPos.position, posRadius, ground);
        if(isonground == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpforce);
        }
    }
    IEnumerator MoveRight(float seconds)
    {
        leftlegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightlegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
    }
    IEnumerator Moveleft(float seconds)
    {
        rightlegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftlegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
    }
}
