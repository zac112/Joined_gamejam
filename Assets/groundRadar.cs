using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundRadar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        transform.parent.GetComponent<Controller>().touchesGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<Controller>().touchesGround = false;
    }
}
