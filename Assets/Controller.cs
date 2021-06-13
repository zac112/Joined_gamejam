using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public Rigidbody2D rb;
    private Animator anim;
    AudioSource audioplayer;
    public GameObject instruction;

    public Sprite walkanim;

    public float jumpforce;
    public float movementSpeed = 5;
    public bool jumping = false;
    public GameObject lose;

    public bool touchesGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioplayer = GetComponent<AudioSource>();
        StartCoroutine("Move");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move() {
        while (true)
        {
            if (Input.GetKey(up))
            {
                instruction.SetActive(false);
                StartCoroutine("Jump");
            }

            if (Input.GetKey(down))
            {
                instruction.SetActive(false);
                StartCoroutine("Combine");
            }

            if (Input.GetKey(left))
            {
                instruction.SetActive(false);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                anim.SetTrigger("walk");
                while (Input.GetKey(left))
                {
                    rb.AddForce(Vector2.left * movementSpeed);
                    yield return null;
                }
                anim.ResetTrigger("walk");
                anim.SetTrigger("idle");
            }

            if (Input.GetKey(right))
            {
                instruction.SetActive(false);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                anim.SetTrigger("walk");
                while (Input.GetKey(right))
                {
                    rb.AddForce(Vector2.right * movementSpeed);
                    yield return null;
                }
                anim.ResetTrigger("walk");
                anim.SetTrigger("idle");
            }
            yield return null;
        }
    }

    IEnumerator Combine() {
        if (audioplayer.isPlaying) yield break;
        audioplayer.Play();
        anim.Play("talk");
        yield return new WaitWhile(() => audioplayer.isPlaying);
        anim.Play("idle");
        yield return null;
    }

    IEnumerator Jump() {
        if (jumping) yield break;
        jumping = true;
        anim.Play("jump");
        rb.AddForce(Vector2.up * jumpforce);

        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => touchesGround);
        jumping = false;
        anim.Play("idle");
    }

    private void OnBecameInvisible()
    {
        //lose.SetActive(true);
    }
}
