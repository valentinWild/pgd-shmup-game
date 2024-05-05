using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{

    public int damage = 1;
    public bool isEnemyShot = false;
    public bool isLaserShot = false;

    // Start is called before the first frame update
    void Start()
    {

        if (isLaserShot)
        {   
            Destroy(gameObject, 2);
        }
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
