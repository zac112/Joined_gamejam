using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomin : MonoBehaviour
{
    Vector3 end = new Vector3(4, 4, 1);
    Vector3 start = new Vector3(0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Zoom");
        transform.localScale = start;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Cat")) {
            Destroy(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bird"))
        {
            Destroy(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Birdgoal"))
        {
            Destroy(go);
        }
    }

    IEnumerator Zoom() {
        float c = 0;
        float speed = 2;
        while (c < speed) {
            c += Time.deltaTime;
            transform.localScale = Vector3.Lerp(start, end, c / speed);
            yield return null;
        }
    }
}
