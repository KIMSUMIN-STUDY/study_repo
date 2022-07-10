using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{
    public bool isOveraped = false;

    private Renderer myRenderer;
    public Color touchColor;
    private Color orginColor;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        orginColor = myRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Triger 인 Collider와 충돌할때 자동으로 실행
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
            Debug.Log("Goal");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = false;
            myRenderer.material.color = orginColor;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
    }
}
