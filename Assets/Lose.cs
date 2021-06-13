using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public GameObject lose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bird"))
        {
            //SceneManager.LoadScene("Lose", LoadSceneMode.Additive);
            lose.SetActive(true);
            print("Lose");
        }
    }
}
