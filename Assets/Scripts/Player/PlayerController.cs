using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private PlayerData playerData;
    private string MOVE = "Move";
    private string WALL = "Wall";
    //hardcode string jadi saya ganti pakai variabel
    public float currentHP ;
     public float speed ;
    private PlayerInput playerInput;
    private Vector2 moveInput;

    void Start()
    {
       playerInput = GetComponent<PlayerInput>();
       if (currentHP == 0 && playerData != null) 
       {
        currentHP = playerData.maxHP;
       }

       if (speed == 0 && playerData != null)
       {
        speed = playerData.moveSpeed;
       }
    }

    
    void Update()
    {
        if (playerInput == null) return;
        
        moveInput = playerInput.actions[MOVE].ReadValue<Vector2>();
        float h = moveInput.x;
        float v = moveInput.y;

        transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(WALL))
        {
            TakeDamage(playerData.takeDamage);
        }
    }

    void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}