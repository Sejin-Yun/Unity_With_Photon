using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private float rotAngle = 90.0f;

    Animator animator;
    public GameObject bullet;
    public Transform firePosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalk", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            if(Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isRun", true);
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isRun", false);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotAngle *  Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotAngle * Time.deltaTime);
        }

        if(Input.GetMouseButton(1))
        {
            animator.SetBool("isAim", true);
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("isShoot");
                Instantiate(bullet, firePosition.position, firePosition.rotation);
            }
        }
        else
        {
            animator.SetBool("isAim", false);
        }
        
    }
}
