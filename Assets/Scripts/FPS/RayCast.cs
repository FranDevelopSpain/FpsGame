using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float range;
    public GameObject bullet_Player;
    public GameObject camera_Player;

    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireRay();
        }

    }
    void FireRay()
    {

        RaycastHit ray;
        if (Physics.Raycast(camera_Player.transform.position, camera_Player.transform.forward, out ray, range))
        {            
            GameObject efectFire = Instantiate(bullet_Player, ray.point, this.transform.rotation);
            Destroy(efectFire, 0.5f);

            if (ray.transform.CompareTag(("Enemy")))
            {
                Destroy(ray.transform.gameObject);
            }
        }

    }
}
