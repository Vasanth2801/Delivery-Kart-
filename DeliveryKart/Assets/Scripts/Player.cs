using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 20f;

    [Header("Inputs")]
    [SerializeField] private float steerAmount;
    [SerializeField] private float moveAmount;

    private void Update()
    {
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}