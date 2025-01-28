using UnityEngine;

public class Gift : MonoBehaviour
{

    private int index;

    [SerializeField] private Vendor vendor;
    
    void Update()
    {

#if UNITY_EDITOR
        MouseTouchTest();
#endif
        
        TouchGift();
    }

    private void MouseTouchTest()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Collider2D hit = Physics2D.OverlapPoint(mousePosition);
            if (hit != null && hit.gameObject == gameObject)
            {
                index++;
                if (index == 5)
                {
                    vendor.Gift();
                }
            }
        }

    }

    private void TouchGift()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D hit = Physics2D.OverlapPoint(touchPosition);
                if (hit != null && hit.gameObject == gameObject)
                {
                    index++;
                    Debug.Log(index);
                    if (index == 50)
                    {
                        vendor.Gift();
                    }
                }
            }
        }
    }

}
