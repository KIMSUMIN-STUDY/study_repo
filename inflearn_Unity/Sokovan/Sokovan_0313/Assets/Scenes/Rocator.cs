using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float frame = 60 * Time.deltaTime;

        transform.Rotate(frame,frame,frame);
    }
}
