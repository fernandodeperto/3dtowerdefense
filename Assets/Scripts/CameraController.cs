using UnityEngine;

public class CameraController : MonoBehaviour {
    public float _panSpeed = 30f;
    public float _panBorder = 10f;
    public float _scrollingSpeed = 1000f;
    public float _minimumHeight = 10f;
    public float _maximumHeight = 80f;

    private bool __enableMovement = true;
    private Vector3 __startPosition;

    void Start () {
        __startPosition = transform.position;
	}
	
	void Update () {

        if (Input.GetKeyDown("f"))
        {
            __enableMovement = !__enableMovement;
        }

        if (!__enableMovement)
        {
            return;
        }

	    if (Input.GetKey("w") || Input.GetKey("up") || Input.mousePosition.y >= Screen.height - _panBorder)
        {
            transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.GetKey("down") || Input.mousePosition.y <= _panBorder)
        {
            transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.GetKey("left") || Input.mousePosition.x <= _panBorder)
        {
            transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.GetKey("right") || Input.mousePosition.x >= Screen.width - _panBorder)
        {
            transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("space"))
        {
            transform.position = __startPosition;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 currentPosition = transform.position;

        currentPosition.y -= scroll * _scrollingSpeed * Time.deltaTime;
        currentPosition.y = Mathf.Clamp(currentPosition.y, _minimumHeight, _maximumHeight);
        transform.position = currentPosition;
    }
}
