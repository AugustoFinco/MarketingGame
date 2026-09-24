using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class moveScript : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animCtrl;
    public float velocidade;
    public float jumpForce;
    public float xInput;
    public float zInput;
    public bool canJump = true;
    public float jumpInput;
    public int jumpTimer = 60;
    public cameraScript Camera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animCtrl = GetComponent<Animator>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal"); // A(-1) e D(1)
        zInput = Input.GetAxis("Vertical"); // W e S
        jumpInput = Input.GetAxis("Jump");

        transform.Translate(new Vector3(xInput, 0 , 0) * velocidade * Time.deltaTime); //Esq e Dir
        transform.Translate(new Vector3(0, 0, zInput) * velocidade * Time.deltaTime); // Frente e Tr�s
        //trabalhar no pulo
        if (canJump) // if canJump = true, pode pular
        {
            if (jumpInput == 1)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canJump = false;
            }
            
        }
        else
        {
            jumpTimer--;

            if (jumpTimer <= 0)
            {
                canJump = true;
                jumpTimer = 60;
            }
        }

        #region animation
        //Animation // vars: isWalk(bool), isJump(bool), sideWay -1/0/1, backWalk(bool)

        if (xInput == 0 && zInput == 0)
        {
            animCtrl.SetBool("isWalk", false);
            animCtrl.SetFloat("sideWay", 0);
            animCtrl.SetBool("backWalk", false);
        }
        
        if (xInput == 0 && zInput > 0) //forward
        {
            animCtrl.SetBool("isWalk", true);
            animCtrl.SetFloat("sideWay", 0);
            animCtrl.SetBool("backWalk", false);
        }
        if (xInput == 0 && zInput < 0) //backward
        {
            animCtrl.SetBool("isWalk", false);
            animCtrl.SetFloat("sideWay", 0);
            animCtrl.SetBool("backWalk", true);
        }
        if (xInput < 0 && zInput == 0) //left
        {
            animCtrl.SetBool("isWalk", true);
            animCtrl.SetFloat("sideWay", -1);
            animCtrl.SetBool("backWalk", false);
        }
        if (xInput > 0 && zInput == 0) //right
        {
            animCtrl.SetBool("isWalk", true);
            animCtrl.SetFloat("sideWay", 1);
            animCtrl.SetBool("backWalk", false);
        }

        #endregion

        //mouse gira o personagem
        var angloX = Camera.turn.x;

        angloX += Input.GetAxis("Mouse X") * Camera.sense;
        transform.localRotation = Quaternion.Euler(0, angloX, 0);

    }


}
