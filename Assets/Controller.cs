using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    private Rigidbody2D rb;

    public float jumpforce;
    public float movementSpeed = 5;
    public bool jumping = false;

    public bool touchesGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up)) {
            StartCoroutine("Jump");            
        }

        if (Input.GetKey(down))
        {
            StartCoroutine("Combine");
        }

        if (Input.GetKey(left))
        {
            rb.AddForce(Vector2.left * movementSpeed);
        }

        if (Input.GetKey(right))
        {
            rb.AddForce(Vector2.right * movementSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        touchesGround = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        touchesGround = false;
    }

    IEnumerator Combine() {
        yield return null;
    }

    IEnumerator Jump() {
        if (jumping) yield break;
        jumping = true;
        rb.AddForce(Vector2.up * jumpforce);

        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => touchesGround);
        jumping = false;
    }
}
