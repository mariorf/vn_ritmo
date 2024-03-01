using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Transform leftBoundary;
    public Transform rightBoundary;

    void Update()
    {
        if (!DialogueManager.Instance.isDialoguePlaying)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
            
            Vector3 newPosition = transform.position + movement;
            
            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary.position.x, rightBoundary.position.x);

            transform.position = newPosition;
        }
    }
}