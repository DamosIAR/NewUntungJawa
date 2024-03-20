using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // The object to focus on
    public float rotationSpeed = 5.0f;

    // Update is called once per frame
    public void Rotate()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;
            //direction.y = 0f; // We're not interested in vertical movement

            // Calculate the rotation needed to face the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
