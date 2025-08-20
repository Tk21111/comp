using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveBack;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        transform.position += new Vector3(inputX, inputY, 0) * moveSpeed * Time.deltaTime;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            cam.orthographicSize -= scroll * 5;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 2f, 20f);
        }
    }
}
