using UnityEngine;

public class MovCamPlayerController : MonoBehaviour
{
    public Camera camera1P;
    public Camera camera3P;
    public KeyCode trocaCamera;
    public  bool ativo1P = true;
    private float mouseX = 0f;
    private float mouseY = 0f;
    public float sensibilidade = 3f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(trocaCamera))
        {
            ativo1P = !ativo1P;
        }
        if (ativo1P)
        {
            camera1P.enabled = true;
            camera3P.enabled = false;
            rotacaoCamera();
        }
        else
        {
            camera1P.enabled = false;
            camera3P.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void rotacaoCamera()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseX += Input.GetAxis("Mouse X") * sensibilidade;
            mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;
            mouseY = Mathf.Clamp(mouseY, -30f, 30f);
            mouseX = Mathf.Clamp(mouseX, -45f, 45f);
            transform.localEulerAngles = new Vector3(mouseY, mouseX, 0f);
        }
    }
}
