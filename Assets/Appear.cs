using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject[] instrcutions;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject go in instrcutions) {
            go.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
