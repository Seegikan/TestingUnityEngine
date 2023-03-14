using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using DefaultNamespace;

namespace DefaultNamespace
{


    public class Movemente2D : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput _playerInput;

        //private InputMapping _mapping;

        [SerializeField]
        private float _moveSpeed = 0f;

        [SerializeField]
        private float _jumpForce = 0f;

        private IEnumerator movementRoutine;

        bool isMoving = false;
        private Vector2 _direction;

        [SerializeField]
        private UnityEvent OnMovementStopped;

        [SerializeField]
        private UnityEvent OnMovementStarted;

        public void SetDirection(InputAction.CallbackContext ctx) => _direction = ctx.ReadValue<Vector2>();

        protected void Start()
        {
            _playerInput.actions["Axis2D"].performed += _ =>
            {
                //var axis2D = ctx.ReadValue<Vector2>();
                if (_direction.magnitude == 0f || isMoving) return;

                isMoving = true;
                OnMovementStarted.Invoke();

            };

            _playerInput.actions["Axis2D"].canceled += _ =>
            {
                isMoving = false;
                OnMovementStopped.Invoke();
            };
        }

        //public void MoveBody(Vector2 axis) => transform.Translate(Vector2.right * Axis2D.x * _moveSpeed * Time.deltaTime);
        //public void MoveBody(InputAction.CallbackContext ctx) => transform.Translate(Vector2.right * ctx.ReadValue<Vector2>().x * _moveSpeed * Time.fixedDeltaTime);

        private void MoveBody() => transform.Translate(Vector2.right * _direction.x * _moveSpeed * Time.deltaTime);




        public void StartMoving()
        {
            movementRoutine = MovementRoutine();
            StartCoroutine(movementRoutine);
        }

        public void StopMoving()
        {
            StopCoroutine(movementRoutine);
            movementRoutine = null;
        }

        private IEnumerator MovementRoutine()
        {
            while (true)
            {
                MoveBody();
                yield return null;
            }
        }

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
        /*
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
}

