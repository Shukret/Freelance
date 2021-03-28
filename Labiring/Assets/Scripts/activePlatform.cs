using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlatform : MonoBehaviour
{   
    // Update is called once per frame
    void Update()
    {
        //включение платформы, если она входит в зону "видимости"
        if (transform.position.x < 20)
        {
            gameObject.SetActive(true);
        }        
    }
}
