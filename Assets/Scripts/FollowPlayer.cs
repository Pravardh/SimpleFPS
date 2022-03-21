using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Transform Target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            SceneManager.LoadScene(2);
        }
    }
}
