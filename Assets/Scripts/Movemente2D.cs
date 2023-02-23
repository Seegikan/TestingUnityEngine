using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Movemente2D : MonoBehaviour
{
    //[SerializeField] private UnityEvent<Vector2> Moved;

   private InputMapping _mapping;

    [SerializeField] 
    private float _moveSpeed = 0f;

    [SerializeField]
    private float _jumpForce = 0f;

    //public void MoveBody(Vector2 axis) => transform.Translate(Vector2.right * Axis2D.x * _moveSpeed * Time.deltaTime);
    public void MoveBody(InputAction.CallbackContext ctx) => transform.Translate(Vector2.right * ctx.ReadValue<Vector2>().x * _moveSpeed * Time.fixedDeltaTime);
    public void JumpBody(InputAction.CallbackContext ctx) => transform.Translate(Vector2.up * ctx.ReadValue<Vector2>().y * _moveSpeed * Time.deltaTime);

    /*

    private void Awake()
    {
        _mapping = new InputMapping();
    }

    private void OnEnable()
    {
       _mapping.Enable();
    }

    private void OnDisable()
    {
        _mapping.Disable();

       // _mapping.Default.Axis2D.performed -= MoveBody(ctx.)
    }

    void Start()
    {
        //Moved.AddListener(MoveBody);//Subcribimos la funcion

        /*_mapping.Default.Axis2D.performed += Context =>
        {
            MoveBody(Context.ReadValue<Vector2>());
        };*/
    /*
    }

    void Update()
    {
        //Moved.Invoke(Axis2D); //Evento
        //MoveBody();
    }

    //void MoveBody() => transform.Translate(Vector3.right * Axis2D * MoveSpeed * Time.deltaTime);

    //private Vector2 Axis2D => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    public void MoveBody(Vector2 axis) => transform.Translate(Vector2.right * Axis2D.x * _moveSpeed * Time.deltaTime);
    //private Vector2 Axis2D => _mapping.Default.Axis2D.ReadValue<Vector2>();
    */
}
