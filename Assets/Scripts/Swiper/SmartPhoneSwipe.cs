using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneSwipe : SwipeManager
{
    public override void DetectSwipe()
    {
        if ( Input.touches.Length == 0 ) {
            return;
        }

        Touch t = Input.GetTouch( 0 );
 
        if ( t.phase == TouchPhase.Began ) {
            _firstPressPos = new Vector2( t.position.x, t.position.y );
        }

        if ( t.phase == TouchPhase.Ended ) {
            _secondPressPos = new Vector2( t.position.x, t.position.y );
            _currentSwipe = new Vector3( _secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y );

            // Make sure it was a legit swipe, not a tap
            if ( _currentSwipe.magnitude < MinSwipeLength ) {
                SwipeDirection = Swipe.None;
                return;
            }

            _currentSwipe.Normalize();

            // Swipe up
            if ( _currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f ) {
                SwipeDirection = Swipe.Up;
                        
                // float x = Random.Range (389f, 395f);
                // float y = Random.Range(651f, 641f);


                // Vector2 whereSpawn = new Vector2 (x, y);
                // Instantiate (Bullet, whereSpawn, Quaternion.identity);
            }
                // Swipe down
            else if ( _currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f ) {
                SwipeDirection = Swipe.Down;
            }
                // Swipe left
            else if ( _currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f ) {
                SwipeDirection = Swipe.Left;
            }
                // Swipe right
            else if ( _currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f ) {
                SwipeDirection = Swipe.Right;
            }
                // Swipe up left
            else if ( _currentSwipe.y > 0 && _currentSwipe.x < 0 ) {
                SwipeDirection = Swipe.UpLeft;
            }
                // Swipe up right
            else if ( _currentSwipe.y > 0 && _currentSwipe.x > 0 ) {
                SwipeDirection = Swipe.UpRight;
            }
                // Swipe down left
            else if ( _currentSwipe.y < 0 && _currentSwipe.x < 0 ) {
                SwipeDirection = Swipe.DownLeft;

                // Swipe down right
            } else if ( _currentSwipe.y < 0 && _currentSwipe.x > 0 ) {
                SwipeDirection = Swipe.DownRight;
            }
        }
    }
}