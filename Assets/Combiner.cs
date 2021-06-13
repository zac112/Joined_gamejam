using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    Controller player;

    public GameObject combination;
    public GameObject instruction;
    public bool collision = false;
    public bool combining = false;

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
                    GameObject go = Instantiate(combination, transform.position, transform.rotation);
                    go.name = "CombinedPlayer";
                    yield return new WaitForEndOfFrame();
                    GameObject[] gos = GameObject.FindGameObjectsWithTag("Bird");
                    Join(gos[0], go);
                    Join(gos[1], go);
                    //Instantiate(combination, transform);                
                    //Destroy(GameObject.FindGameObjectWithTag("Bird"));
                    //Destroy(GameObject.FindGameObjectWithTag("Cat")); 
                    yield return new WaitForSeconds(2f);
                    yield return Separation(go);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Separation(GameObject combination) {
        while (true)
        {
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.DownArrow))
            {
                Separate(combination);
                yield return new WaitForSeconds(0.1f);
                Destroy(combination);
                combining = false;
                break;
            }
            yield return null;
        }
        
    }
    private void Join(GameObject player, GameObject combination) {
        player.transform.SetParent(combination.transform);        
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<Controller>().rb = combination.GetComponent<Rigidbody2D>();
        Destroy(player.GetComponent<Rigidbody2D>());
        if(instruction != null)
            Destroy(instruction);
    }

    private void Separate(GameObject combination)
    {
        print("Separated");
        for (int i = 0; i < 2; i++) {
            GameObject player = combination.transform.GetChild(i).gameObject;
            Rigidbody2D rb = combination.transform.GetChild(i).gameObject.AddComponent<Rigidbody2D>();
            player.GetComponent<Controller>().rb = rb;
            player.GetComponent<BoxCollider2D>().enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        combination.transform.DetachChildren();
        
        /*GameObject player = combination.transform.GetChild(0).gameObject;

        player.transform.SetParent(null);
        player.GetComponent<Controller>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.AddComponent<Rigidbody2D>();*/
        
    }
}
