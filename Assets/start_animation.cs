using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_animation : MonoBehaviour
{
    public int children = 0;
    public GameObject wp;
    public GameObject mark;

    private void Start()
    {
        StartCoroutine("Animate");
    }
    IEnumerator Animate() {
        yield return new WaitUntil(() => children >= 3);
        yield return new WaitForSeconds(Random.Range(3,6));

        Vector3 pos = transform.position;
        float c = 0;
        while (c < 4) {
            c += Time.deltaTime;
            transform.position = Vector3.Lerp(pos, wp.transform.position, c/4);
            yield return null;
        }
        
        mark.SetActive(true);
        yield return new WaitForSeconds(2);
        mark.SetActive(false);

        c = 0;
        pos = transform.position;
        while (c < 4)
        {
            c += Time.deltaTime;
            transform.position = Vector3.Lerp(pos, new Vector3(3,12,0), c / 4);
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}
