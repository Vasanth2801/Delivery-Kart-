using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float slowSpeed = 10f;

    [Header("Inputs")]
    [SerializeField] private float steerAmount;
    [SerializeField] private float moveAmount;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip musicClip;

    void Update()
    {
       MoveCar();
       PlaySound();
    }

    void MoveCar()
    {
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void PlaySound()
    {
        if((steerAmount > 0 ||  moveAmount > 0))
        {
            if(musicClip != null && musicSource != null)
            {
                musicSource.clip = musicClip;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        else if(steerAmount < 0 || moveAmount < 0)
        {
            if(musicClip != null && musicSource != null)
            {
                musicSource.clip = musicClip;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        else if(moveAmount == 0 || steerAmount == 0)
        {
            musicSource.Stop();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BoostSpeed")
        {
            moveSpeed = boostSpeed;
        }
    }
}