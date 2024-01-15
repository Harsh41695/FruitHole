using UnityEditor;
using UnityEngine;

public class HY_CloudAnim : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]
    float floatHeight = 1.0f;
    public float floatSpeed = 1.0f;

    void Update()
    {
        // Calculate the new Y position based on a sine wave
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Apply the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}