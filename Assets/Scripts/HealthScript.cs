using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int hp = 2;
    public bool isEnemy = true;

    void OnTriggerEnter2D (Collider2D collider) 
    {

        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();

        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                if (!shot.isLaserShot)
                {
                    Destroy(shot.gameObject);
                }

                if (hp <= 0)
                {
                    SpecialEffectsHelper.Instance.Explosion(transform.position);
                    SoundEffectsHelper.Instance.MakeExplosionSound();
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
