using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_falloff : MonoBehaviour
{
    public float force = 500;
    public start_animation[] players;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Animate");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartCoroutine("Animate");
        }
    }
    IEnumerator Animate() {
        yield return new WaitForSeconds(UnityEngine.Random.Range(3, 8));
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 pos = new Vector3(transform.position.x+Random.Range(-0.5f,0.5f), transform.position.y-0.5f, transform.position.z);
        Vector3 f = new Vector3(Random.Range(-5f, 5f), force, 0);

        rb.AddForceAtPosition(f, pos);

        yield return new WaitForSeconds(0.1f);
        GetComponent<BoxCollider2D>().enabled = false;
        foreach (start_animation s in players) {
            s.children += 1;
        }
    }
}
