using Unity.VisualScripting;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 Pos;
    private void Start()
    {
        Pos = transform.position;
    }
    private void FixedUpdate()
    {
        Pos.x -= speed;
        Pos.y -= speed;
        transform.position = Pos;

        if (Pos.x < -9 || Pos.y < -5) { Destroy(this.gameObject); }
    }
}
