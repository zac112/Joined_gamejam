using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public List<GameObject> done = new List<GameObject>();
    public GameObject win;

    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        done.Add(collision.gameObject);
        if (done.Contains(players[0]) && done.Contains(players[1])) {
            win.SetActive(true);
        }
        else if (collision.name.Equals("CombinedPlayer"))
        {
            win.SetActive(true);
        }
    }
}
