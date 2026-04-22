using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 [SerializeField] private PlayerData playerData;
 public float currentHP;

 private PlayerInput playerInput;
 private Vector2 moveInput;

  void Awake()
  {
        // SOLUSI OTOMATIS: Jika slot di Inspector kosong, script akan 
        // membuat objek data sementara di memori agar tidak error.
 if (playerData == null)
         {
            playerData = ScriptableObject.CreateInstance<PlayerData>();
    }
  }
  void Start()
{
     playerInput = GetComponent<PlayerInput>();
 if (playerData != null)
  {
 currentHP = playerData.maxHP;
 }
 
 }
  
  
  void Update()
  {
    if (playerInput == null) return;

 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
 float h = moveInput.x;
 float v = moveInput.y;

 transform.Translate(new Vector3(h, v, 0) * playerData.moveSpeed * Time.deltaTime);
 }

 void OnCollisionStay2D(Collision2D collision)
 {
 if (collision.gameObject.CompareTag("Wall"))
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
}//apakah kode ini sudah sesuai instruksi