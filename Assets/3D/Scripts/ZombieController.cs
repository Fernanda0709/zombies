using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ZombieController : MonoBehaviour
{
    public float velocidad = 4f;
    public float gravedad = -20f;
    public float sensibilidad = 2f;

    CharacterController cc;
    Animator anim;
    Vector3 velY;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;   // oculta y bloquea el mouse
        Cursor.visible = false;
    }

    void Update()
    {
        // El mouse gira al zombie
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        transform.Rotate(0, mouseX, 0);

        // Movimiento relativo a hacia dónde mira
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = (transform.right * h + transform.forward * v);
        bool moviendo = dir.magnitude > 0.1f;

        if (anim != null) anim.speed = moviendo ? 1f : 0f;

        if (moviendo)
            cc.Move(dir.normalized * velocidad * Time.deltaTime);

        if (cc.isGrounded && velY.y < 0) velY.y = -2f;
        velY.y += gravedad * Time.deltaTime;
        cc.Move(velY * Time.deltaTime);

        // Esc para liberar el mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}