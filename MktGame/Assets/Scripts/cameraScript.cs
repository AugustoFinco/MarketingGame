using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Vector2 turn;
    public float sense = 0.5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        // camera mexe para cima e para baixo
        turn.x += Input.GetAxis("Mouse X") * sense;
        turn.y += Input.GetAxis("Mouse Y") * sense;

        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0); //(-turn.y, turn.x, 0)
    
    }
}
