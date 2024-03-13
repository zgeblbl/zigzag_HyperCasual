 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    CurrentDirection cr;
    public bool gameOver;
    private GameManager gameManager;
    public ParticleSystem deadEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        gameOver = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        if (!gameOver)
        {
            RayCastDetector();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeDirection();
                PlayerStop();
            }
        }else
        {
            return;
        }
        
    }
    private void RayCastDetector()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
            PlayerStop();
            gameOver = true;
            this.gameObject.SetActive(false);
            gameManager.LevelEnd();
            Instantiate(deadEffect,this.transform.position, Quaternion.identity);
        }
    }

    private enum CurrentDirection
    {
        right,
        left
    }
    private void ChangeDirection()
    {
        MovePlayer();
        if (cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }else if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
    }
    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
            rb.AddForce((Vector3.forward).normalized*speed*Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.left)
        {
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }

    }
    private void PlayerStop()
    {
        rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            PlayerStop();
            this.gameObject.SetActive(false);
        }
    }

}
