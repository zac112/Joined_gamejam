using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    Controller player;

    public GameObject combination;
    bool collision = false;
    bool combining = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Bird") || other.tag.Equals("Cat"))
        {
            collision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Bird") || other.tag.Equals("Cat"))
        {
            collision = false;
        }
    }

    private void Update()
    {        
        StartCoroutine("Combine");
    }

    IEnumerator Combine() {
        while (true)
        {
            if (collision && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.DownArrow))
            {
                if (!combining)
                {
                    combining = true;
                    Instantiate(combination, transform.position, transform.rotation);
                    //Instantiate(combination, transform);                
                    Destroy(GameObject.FindGameObjectWithTag("Bird"));
                    Destroy(GameObject.FindGameObjectWithTag("Cat"));
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
