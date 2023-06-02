using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patroller : MonoBehaviour

{
    public NavMeshAgent centinel;
    public GameObject player;
    public GameObject centinel_point1;
    public GameObject centinel_point2;
    public int destination_actually;
    public float margin = 1;
    public float detection_range = 20;
    public float detection_angle = 45;
    public float impulseForce;
    public GameObject point_Spawn;
    public GameObject bullet_Enemy;

    void Start()
    {
        centinel = this.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Detection_Player();
        Patroller_Enemy();
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
                        centinel.SetDestination(player.transform.position);
                        Shoot();

                    }
                }

            }
        }
    }
    void Patroller_Enemy()
    {
        Vector3 destiny_Distance = this.transform.position - centinel.destination;
        if (destiny_Distance.magnitude < margin)
        {
            if (destination_actually == 1)
            {
                destination_actually = 2;
                centinel.SetDestination(centinel_point2.transform.position);
            }
            else
            {
                destination_actually = 1;
                centinel.SetDestination(centinel_point1.transform.position);
            }
        }
    }
    public void Shoot()
    {

        GameObject shoot = Instantiate(bullet_Enemy, point_Spawn.transform.position, point_Spawn.transform.rotation);
            shoot.GetComponent<Rigidbody>().AddForce(shoot.transform.forward * impulseForce);
            Destroy(shoot, 2);
            
        }
    }