using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float speed = 8f;

    private float horizontal;
    //private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private LayerMask ceilingLayer;

    //Jetpack
    [SerializeField] private float Jetpack = 5f;
    [SerializeField] private Slider fuelSlider;
    [SerializeField] private float fuel = 100f;
    [SerializeField] private float fuelBurnRate = 40f;
    [SerializeField] private float fuelRefillRate = 30f;
    //[SerializeField] private float RefillCD = 5f;

    private bool isFlying = false;
    private bool haveFuel = true;

    //private float timer = 0;
    private float currentFuel;

    //player hearts or lives
    private PlayerHearts hearts;

    private void Awake()
    {
        currentFuel = fuel;
    }

    // Update is called once per frame
    void Update()
    {
        if(hearts.IsAlive == true) {
            horizontal = Input.GetAxisRaw("Horizontal") * speed;

            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            fuelSlider.value = currentFuel / fuel;

            //Punish using all fuel
            //if (currentFuel < 0)
            //{
            //    haveFuel = false;
            //    currentFuel = 0;
            //}
            //if (!haveFuel)
            //{
            //    timer += Time.deltaTime;
            //    Debug.Log(timer);
            //    if (timer >= RefillCD)
            //    {
            //        haveFuel = true;
            //        timer = 0;
            //    }
            //}

            //Use Jetpack
            if (Input.GetButtonDown("Jump") && haveFuel)
            {
                isFlying = true;

                animator.SetBool("isUsingJetpack", true);

                //Jumping
                //rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
            //While in the air
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f || IsCeiling())
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                isFlying = false;

                animator.SetBool("isUsingJetpack", false);
            }
            if (IsGrounded())
            {
                animator.SetBool("onLanding", true);
            }
            else
                animator.SetBool("onLanding", false);

            flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (isFlying && haveFuel)
        {
            rb.AddForce(Vector2.up * Jetpack);

            currentFuel -= fuelBurnRate * Time.deltaTime;
        }
        if (!isFlying && haveFuel)
        {
            RefillFuel();
        }
    }

    private void RefillFuel()
    {
        if (currentFuel < fuel)
        {
            currentFuel += fuelRefillRate * Time.deltaTime;
        }
    }

    //Creates a circle below the feet to check if player is grounded
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);
    }

    private bool IsCeiling()
    {
        return Physics2D.OverlapCircle(ceilingCheck.position, 0.05f, ceilingLayer);
    }

    private void flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
