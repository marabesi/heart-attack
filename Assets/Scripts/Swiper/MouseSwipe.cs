using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSwipe : SwipeManager
{
    public override void DetectSwipe()
    {
        if ( Input.GetMouseButtonDown( 0 ) ) {
                _firstClickPos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
            } 
            
            if ( Input.GetMouseButtonUp( 0 ) ) {
                _secondClickPos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
                _currentSwipe = new Vector3( _secondClickPos.x - _firstClickPos.x, _secondClickPos.y - _firstClickPos.y );
 
                if ( _currentSwipe.magnitude < MinSwipeLength ) {
                    return;
                }
 
                _currentSwipe.Normalize();
 
                float x = 392.2344f; //Random.Range (389f, 395f);
                float y = 646.9063f; //Random.Range(651f, 641f);

                Vector2 whereSpawn = new Vector2 (x, y);
                GameObject newBullet = Instantiate (Bullet, whereSpawn, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().velocity = _currentSwipe * 2;
            }
    }
}