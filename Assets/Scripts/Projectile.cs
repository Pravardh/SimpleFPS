using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(RemoveProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RemoveProjectile()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;
        if(collision.gameObject.layer == 3)
        {
            Debug.Log("Hitting Player!!");
        }
    }
}
