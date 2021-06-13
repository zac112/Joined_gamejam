using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float multiplier = 1;
    public GameObject[] wp;
    public int index = 0;
    public int speed = 5;

    void Start()
    {
        StartCoroutine("Move");
    }

    IEnumerator Move() {

        yield return new WaitForSeconds(15);
        float c = 0f;

        Vector3 start = transform.position;
        while(c < speed)
        {
            c += Time.deltaTime;
            transform.position = Vector3.Lerp(start, wp[index].transform.position, c/ speed);
            yield return null;
        }

        while (true)
        {
            c = 0;
            index = (index + 1) % 2;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            start = transform.position;
            while (c < speed)
            {
                c += Time.deltaTime;
                transform.position = Vector3.Lerp(start, wp[index].transform.position, c / speed);
                yield return null;
            }                     
            yield return null;
        }
    }

}
