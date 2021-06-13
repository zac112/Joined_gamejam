using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    SpriteRenderer r;
    Color start = Color.white;
    Color end = new Color(0, 0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        r.color = end;
        StartCoroutine("Fadeout");
    }

    // Update is called once per frame
    IEnumerator Fadein()
    {        
        float c = 0;
        while (c < 1) {
            c += Time.deltaTime;
            r.color = Color.Lerp(start, end, c);
            yield return null;
        }
        yield return Fadeout();
    }

    IEnumerator Fadeout()
    {
        float c = 0;
        while (c < 1)
        {
            c += Time.deltaTime;
            r.color = Color.Lerp(end, start, c);
            yield return null;
        }
        yield return Fadein();
    }
}
