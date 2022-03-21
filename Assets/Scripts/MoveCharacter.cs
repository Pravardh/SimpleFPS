using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCharacter : MonoBehaviour
{
    CharacterController controller;
    float dirx, dirz;

    public Transform muzzleFlash;
    public GameObject projectile;
    public Camera cam;
    public ParticleSystem Flash;

    public float movementSpeed = 8.0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null) return;

        HandleMovement();
    }

    void HandleMovement()
    {
        dirx = Input.GetAxis("Horizontal");
        dirz = Input.GetAxis("Vertical");

        MoveForward(dirz);
        MoveRight(dirx);

        PlayerGravity();

        if(Input.GetKeyDown(KeyCode.Mouse0))
            PlayerShoot();
    }

    void MoveForward(float dirz)
    {
        controller.Move(transform.forward * dirz * Time.deltaTime * movementSpeed);
    }

    void MoveRight(float dirx)
    {

        controller.Move(transform.right * dirx * Time.deltaTime * movementSpeed);
    }

    void PlayerGravity()
    {
        controller.Move(transform.up * -5 * Time.deltaTime);
    }

    void PlayerShoot()
    {
        Flash.Play();
        RaycastHit Hit;
        bool bIsHit = Physics.Raycast(cam.transform.position, cam.transform.forward, out Hit, 1000);
        if(bIsHit)
        {
            Debug.Log(Hit.collider.name); 
            HealthManager Target = Hit.collider.gameObject.GetComponent<HealthManager>();
            if (Target)
                Target.DamagePlayer(10, gameObject);
        }
            
    }

    void PlayerDeath()
    {
        Debug.Log("Player Dead lol");
        SceneManager.LoadScene(2);
    }

}

