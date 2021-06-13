using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public Vector3 start = new Vector3(0, -1f, -10);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start;
    }

    public IEnumerator MoveCamera(Vector3 newPos)
    {
        print(newPos);
        float endTime = Time.time + 2f;
        Vector3 pos = Camera.main.transform.position;
        float c = 0;
        while (c < 5)
        {
            c += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(pos, newPos, c / 2);
            yield return null; 
        }
    }

}
