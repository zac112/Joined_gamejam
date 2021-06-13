using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combined : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        for(int i=0; i<transform.childCount; i++)
        {
            try
            {
                transform.GetChild(i).GetComponent<Controller>().touchesGround = true;             
            }
            catch (UnityException e)
            {
                print(e);
            }
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            try
            {
                transform.GetChild(i).GetComponent<Controller>().touchesGround = false;
            }
            catch (UnityException e)
            {
                print(e);
            }
        }
    }
}
