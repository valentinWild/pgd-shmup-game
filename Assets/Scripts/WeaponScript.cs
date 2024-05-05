using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
  //--------------------------------
  // 1 - Designer variables
  //--------------------------------

  /// <summary>
  /// Projectile prefab for shooting
  /// </summary>
  public Transform shotPrefab;
  public Transform laserShotPrefab;

  /// <summary>
  /// Cooldown in seconds between two shots
  /// </summary>
  public float shootingRate = 0.25f;
  public float laserShootingRate = 6f;
  

  //--------------------------------
  // 2 - Cooldown
  //--------------------------------

  private float shootCooldown;
  private float laserShootCooldown;

  void Start()
  {
    shootCooldown = 0f;
    laserShootCooldown = 0f;
  }

  void Update()
  {
    if (shootCooldown > 0)
    {
        shootCooldown -= Time.deltaTime;
    }

    if (laserShootCooldown > 0)
    {
        laserShootCooldown -= Time.deltaTime;
    }
  }

  //--------------------------------
  // 3 - Shooting from another script
  //--------------------------------

  /// <summary>
  /// Create a new projectile if possible
  /// </summary>
  public void Attack(bool isEnemy)
  {
    if (CanAttack)
    {
      shootCooldown = shootingRate;

      // Create a new shot
      var shotTransform = Instantiate(shotPrefab) as Transform;

      // Assign position
      shotTransform.position = transform.position;

      // The is enemy property
      ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
      if (shot != null)
      {
        shot.isEnemyShot = isEnemy;
      }

      // Make the weapon shot always towards it
      MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
      if (move != null)
      {
        move.direction = this.transform.right; // towards in 2D space is the right of the sprite
      }
    }
  }

    public void AttackLaser(bool isEnemy)
    {
        if (CanAttackLaser)
        {

            laserShootCooldown = laserShootingRate;

            Renderer shotRenderer = laserShotPrefab.GetComponent<Renderer>();
            float shotWidth = shotRenderer.bounds.size.x;
            Vector3 spawnPosition = transform.position + new Vector3(shotWidth / 2, 0, 0) + new Vector3(1, 0, 0);
            // Create a new shot
            var shotTransform = Instantiate(laserShotPrefab, spawnPosition, Quaternion.identity) as Transform;

            // Assign position
            shotTransform.transform.parent = this.transform;

            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isLaserShot = true;
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right; // towards in 2D space is the right of the sprite
            }
        }
    }


    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
        return shootCooldown <= 0f;
        }
    }

    public bool CanAttackLaser
    {
        get
        {
            return laserShootCooldown <= 0f;
        }
    }

}
