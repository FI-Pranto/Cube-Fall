using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float movingSpeed;
    float boundaryY = 6f;
 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up*movingSpeed*Time.deltaTime);
        if (transform.position.y > boundaryY)
        {
            Destroy(gameObject);
        }
    }
}
