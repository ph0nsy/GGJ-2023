using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 #if UNITY_EDITOR
 using UnityEditor;
 #endif

/// <summary>Class <c>PlayerController</c> manages player behaviour. It derives from <see cref="UnityEngine.MonoBehaviour"/>.</summary>
/// <remarks>This class is in charge of the player behaviour, managing its sprite and movement with the help of the player object's: 
/// <list type="bullet"> 
/// <item><see cref="UnityEngine.Rigidbody"/></item>
/// <item><see cref="UnityEngine.SpriteRenderer"/></item>
/// <item><see cref="GroundChecker"/></item>
///</list>
///</remarks>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    #region EditorVariables
    
    [Header("Player")]
    [SerializeField]
    public Rigidbody _rigidbody;
    
    [SerializeField]
    public BoxCollider _collider;

    [Range(1.0f, 10.0f)]
    public float _speed = 6.0f;

    [Range(1.0f, 20.0f)]
    public float _jumpForce = 6.0f;

    [Header("Sprite")]
    [SerializeField]
    public SpriteRenderer _spriteRenderer;
    [SerializeField]
    public Animator _animator;
//    private bool flipped;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        #region SetUp
        _rigidbody.freezeRotation = true;
//        flipped = false;
        #endregion
    }

    // Update is called once per frame, used for logic
    void Update()
    {       
        #region SpriteManagement
        /*
        if (Input.GetAxisRaw("Horizontal") > 0)
            _spriteRenderer.flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            _spriteRenderer.flipX = true;
        */
        #endregion
    }

    // Update is called by the physics engine based on the physics frames per second set and the framerate, used only for physic-related functions
    private void FixedUpdate() 
    {
        #region Movement
        Vector3 _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * Time.deltaTime * _speed;
        _animator.SetFloat("Horizontal",Input.GetAxisRaw("Horizontal"));
        _rigidbody.velocity = new Vector3(_movement.x, _rigidbody.velocity.y, _movement.z);
        _rigidbody.MovePosition(transform.position + _movement);

        if(IsGrounded()){
            _animator.SetBool("Air", false);
        }
        if (Input.GetKey(KeyCode.Space)){    
            if (IsGrounded()){
                _rigidbody.AddForce(Vector3.up*_jumpForce, ForceMode.Impulse);
                _animator.SetBool("Air",true);
            }
        }
        #endregion
    }

    private bool IsGrounded()
    {
        RaycastHit _hit;
        if (Physics.Raycast(transform.position+new Vector3(0,0.2f,0), Vector3.down, out _hit, 0.25f, LayerMask.GetMask("Ground"))){
            Debug.DrawRay(transform.position+new Vector3(0,0.2f,0), transform.TransformDirection(Vector3.down) * _hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return true;
        } else {
            Debug.DrawRay(transform.position+new Vector3(0,0.2f,0), transform.TransformDirection(Vector3.down) * 0.25f, Color.red);
            Debug.Log("Did not Hit");
            Debug.Log(_hit.collider);
            return false;
        }
    }
    
}
