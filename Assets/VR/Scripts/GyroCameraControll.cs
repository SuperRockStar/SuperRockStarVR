using UnityEngine;

public class GyroCameraControll : MonoBehaviour
{
    [Range(0, 355)]
    public float minAngle = 50f;
    [Range(0, 355)]
    public float maxAngle = 310f;




    void Update()
    {


        transform.Rotate(Vector3.right * Input.acceleration.y * 2.0f);
        if (transform.eulerAngles.x >= minAngle && transform.eulerAngles.x <= (minAngle))
            transform.eulerAngles = new Vector3(0f, 0f, minAngle);
        if (transform.eulerAngles.x <= maxAngle && transform.eulerAngles.x >= (maxAngle))
            transform.eulerAngles = new Vector3(0f, 0f, maxAngle);

        transform.Rotate(Vector3.down * Input.acceleration.y * 2.0f);
        if (transform.eulerAngles.z >= minAngle && transform.eulerAngles.z <= (minAngle))
            transform.eulerAngles = new Vector3(0f, 0f, minAngle);
        if (transform.eulerAngles.z <= maxAngle && transform.eulerAngles.z >= (maxAngle))
            transform.eulerAngles = new Vector3(0f, 0f, maxAngle);
    }
}