using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour {
    
    private float width;

    private void Awake() 
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;

    }

    private void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();    
        }

    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0f);
        //transform.position = (Vector2)transform.position + offset; // casting 중...
        transform.position = transform.position.AddVector(offset);
    }


}