using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntety
{
    public float moveSpeed = 5;
    PlayerController controller;
    GunController gunController;
    protected override void Start()
    {
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
    }
    void Update()
    {
        
        //movement input
        Vector3 moveInput = new Vector3(CrossPlatformInputManager.GetAxisRaw("HorizontalMove"), 0, CrossPlatformInputManager.GetAxisRaw("VerticalMove"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //rotation input
        Vector3 targetDirection = new Vector3(CrossPlatformInputManager.GetAxis("HorizontalAim"), 0f, CrossPlatformInputManager.GetAxis("VerticalAim"));
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = targetRotation;
        }

        //weapon input/**/
        gunController.Shoot();
    }
}