using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    public string target;
    public End end;

    public Vector3 cameraPos;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(target)) {
            MainCameraScript s = Camera.main.gameObject.GetComponent<MainCameraScript>();
            s.StartCoroutine("MoveCamera", cameraPos);
            Destroy(gameObject);
        }
    }

}
