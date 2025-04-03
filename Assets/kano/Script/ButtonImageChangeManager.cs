using UnityEngine;

public class ButtonImageChangeManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] ButtonImage;

    SpriteRenderer ThisSprite;

    private void Start()
    {
        this.ThisSprite = GetComponent<SpriteRenderer>();
    }

    public void SpriteChange(int num)
    {
        switch (num) {
        
            case 0:
                this.ThisSprite.sprite = ButtonImage[0]; break;
            case 1:
                this.ThisSprite.sprite = ButtonImage[1]; break;
            case 2:
                this.ThisSprite.sprite = ButtonImage[2]; break;
        }
    }
}
