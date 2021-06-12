using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    List<string> done = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDone(string target) {
        done.Add(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (done.Contains("Cat") && done.Contains("Bird")) {
            print("Next level!");
        }
    }
}
