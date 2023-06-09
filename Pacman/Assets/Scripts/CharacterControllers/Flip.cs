using UnityEngine;

public class Flip : MonoBehaviour
{
    
   SpriteRenderer _spriteRenderer;
   [SerializeField] Sprite[] _sprites = new Sprite[4];
   public void AssignSprite(int value) 
   {
        //value check
        _spriteRenderer.sprite = _sprites[value];
   }
   public void RotateSprite(Vector2 dir)
    {
        if (dir == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dir == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (dir == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (dir == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
