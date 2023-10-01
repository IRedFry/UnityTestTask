using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerInputAction actions;
    [SerializeField]
    private GameObject playerSprite;
    private MovingEntity moving;
    private void Awake()
    {
        actions = new PlayerInputAction();
        moving = GetComponent<MovingEntity>();
    }

    private void Update()
    {
        Vector2 moveVector = actions.Player.Move.ReadValue<Vector2>();
        if (moveVector != Vector2.zero)
        {
            moving.Move(moveVector);
            if (moveVector.x < 0)
                playerSprite.transform.localScale = new Vector3(-Mathf.Abs(playerSprite.transform.localScale.x), playerSprite.transform.localScale.y, playerSprite.transform.localScale.z);
            else
                playerSprite.transform.localScale = new Vector3(Mathf.Abs(playerSprite.transform.localScale.x), playerSprite.transform.localScale.y, playerSprite.transform.localScale.z);
        }
    }

    void OnEnable()
    {
        actions.Player.Enable();
    }
    void OnDisable()
    {
        actions.Player.Disable();
    }
}
