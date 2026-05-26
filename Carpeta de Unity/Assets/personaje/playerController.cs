using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public static playerController PC;
    
    [SerializeField] private AudioClip saltoSonido;
    [SerializeField] private AudioClip moveSonido;

    Rigidbody rigid;
    public Animator anim;

    [Range(-1, 1)]
    [SerializeField] float position;

    Vector3 destiny;
    bool toRight;
    bool toLeft;

    bool inFloor;

    [Header("SETUP")]
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float timeToFalse = 0.3f;
    [SerializeField] float jumpForce = 5;

    void Awake()
    {
        PC = this;
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        destiny = transform.position;
    }

    void Update()
    {
        // mover derecha
        if (Input.GetKeyDown(KeyCode.RightArrow) && position < 1)
        {
            ToFalse();
            toRight = true;
            Invoke("ToFalse", timeToFalse);
            ControladorSonido.CS.EjecutarSonido(moveSonido);
        }

        // mover izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow) && position > -1)
        {
            ToFalse();
            toLeft = true;
            Invoke("ToFalse", timeToFalse);
            ControladorSonido.CS.EjecutarSonido(moveSonido);
        }

        if (Vector3.Distance(transform.position, destiny) < 0.1f)
        {
            if (toRight)
            {
                destiny.x = transform.position.x + 1.5f;
                position++;
            }

            if (toLeft)
            {
                destiny.x = transform.position.x - 1.5f;
                position--;
            }
        }

        Vector3 xDestiny = new Vector3(destiny.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, xDestiny, moveSpeed * Time.deltaTime);

        //  DOWN SOLO EN EL SUELO
        if (Input.GetButtonDown("Down") && inFloor)
        {
            ToFalse();
            anim.SetBool("down", true);
            CancelInvoke();
            Invoke("ToFalse", timeToFalse);

            ControladorSonido.CS.EjecutarSonido(moveSonido);

            rigid.AddForce(Vector3.up * -jumpForce, ForceMode.Impulse);
        }

        //  SALTO SOLO EN EL SUELO
        if (Input.GetButtonDown("Up") && inFloor)
        {
            ToFalse();
            anim.SetBool("up", true);
            Invoke("ToFalse", timeToFalse);

            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            ControladorSonido.CS.EjecutarSonido(saltoSonido);
        }

        // Animator
        anim.SetBool("inFloor", inFloor);
        anim.SetBool("toLeft", toLeft);
        anim.SetBool("toRight", toRight);
    }

    // DETECCIÓN DE SUELO MEJORADA
void OnCollisionEnter(Collision col)
{
    inFloor = true;
}

void OnCollisionExit(Collision col)
{
    inFloor = false;
}

    void ToFalse()
    {
        toLeft = false;
        toRight = false;
        anim.SetBool("down", false);
        anim.SetBool("up", false);
    }
}