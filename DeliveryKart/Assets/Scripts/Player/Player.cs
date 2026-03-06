using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 20f;

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
}