using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexBG : MonoBehaviour
{
    public float velocityY = 2f;
    Material mat;
    Vector2 offset;
    void Awake()
    {
        mat=GetComponent<MeshRenderer>().material;
        offset=new Vector2(0,velocityY);
    }

    // Update is called once per frame
    void Update()
    {
        Scorll();
    }

    void Scorll()
    {
        mat.mainTextureOffset += offset * Time.deltaTime;
    }
}
