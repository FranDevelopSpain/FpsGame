using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    public float velocity = 10f;
    public float rotate = 70f;
    public GameObject bullet;
    public GameObject gun;
    public float bulletAddForce = 500;
   
    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotate * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotate * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(1, 0, 0) * rotate * Time.deltaTime, Space.Self);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(-1, 0, 0) * rotate * Time.deltaTime, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shoot = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            shoot.GetComponent<Rigidbody>().AddForce(shoot.transform.forward * bulletAddForce);
            Destroy(shoot, 3);

        }

    }
}
