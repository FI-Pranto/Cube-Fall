using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    float minX = -1.4f, maxX = 1.4f;

    public GameObject[] trapPlatforms;
    public GameObject normalPlatform;
    public GameObject star;
    float posX;
    Vector2 pos;
    int idx;
    int rateOfStar;

    GameObject tempGameObject;
    public GameObject player;

    public GameObject platfrom;

    public Button play;



    public void Play()
    {
        player.SetActive(true);
        platfrom.SetActive(true);
        play.gameObject.SetActive(false);
        
        StartCoroutine(SwpanPlatform());
    }

    IEnumerator SwpanPlatform()
    {
        while (true)
        {

            rateOfStar=Random.Range(0, 2);
            
             posX=Random.Range(minX, maxX);
            pos=new Vector2(posX,transform.position.y);
            tempGameObject=Instantiate(normalPlatform, pos, Quaternion.identity);

            if (rateOfStar == 0)
            {
                Instantiate(star, new Vector2(pos.x,pos.y+0.4f), Quaternion.identity).transform.SetParent(tempGameObject.transform);
                

            }


            yield return new WaitForSeconds(1f);

            rateOfStar = Random.Range(0, 2);

            posX = Random.Range(minX, maxX);
            idx=Random.Range(0, trapPlatforms.Length);
            pos = new Vector2(posX, transform.position.y);
            tempGameObject=Instantiate(trapPlatforms[idx], pos, Quaternion.identity);
            if (rateOfStar == 0)
            {
                Instantiate(star, new Vector2(pos.x, pos.y + 0.4f), Quaternion.identity).transform.SetParent(tempGameObject.transform);
            }

            yield return new WaitForSeconds(1f);




        }

    }

    
}
