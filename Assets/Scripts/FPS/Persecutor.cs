using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Persecutor : MonoBehaviour
{
    public NavMeshAgent persecutor;
    public GameObject player;
    public GameObject persecutor_SpawnFire;
    public GameObject bullet_Enemy;
    public float impulseForce;
    public float detection_range;
    public float detection_angle;

    // Start is called before the first frame update
    void Start()
    {
        persecutor = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        persecutor.SetDestination(player.transform.position);
        Detection_Player();
        
        
    }
    public void Shoot()
    {

        GameObject shoot = Instantiate(bullet_Enemy, persecutor_SpawnFire.transform.position, persecutor_SpawnFire.transform.rotation);
        shoot.GetComponent<Rigidbody>().AddForce(shoot.transform.forward * impulseForce);
        Destroy(shoot, 2);

    }
    public void Detection_Player()
    {
        Vector3 distPlayer = player.transform.position - this.transform.position;
        if (distPlayer.magnitude < detection_range)
        {
            if (Physics.Raycast(this.transform.position, distPlayer, out RaycastHit ray, detection_range))
            {
                float angle = Vector3.Angle(this.transform.forward, distPlayer);
                if (ray.transform.CompareTag("Player"))
                {
                    if ((angle < detection_angle))
                    {
                        persecutor.SetDestination(player.transform.position);
                        Shoot();

                    }
                }

            }
        }
    }

}