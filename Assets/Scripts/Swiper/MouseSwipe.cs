using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSwipe : SwipeManager
{
    public override void DetectSwipe()
    {
        if ( Input.GetMouseButtonDown( 0 ) ) {
                _firstClickPos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
            } else {
                SwipeDirection = Swipe.None;
                //Debug.Log ("None");
            }
            if ( Input.GetMouseButtonUp( 0 ) ) {
                _secondClickPos = new Vector2( Input.mousePosition.x, Input.mousePosition.y );
                _currentSwipe = new Vector3( _secondClickPos.x - _firstClickPos.x, _secondClickPos.y - _firstClickPos.y );
 
                // Make sure it was a legit swipe, not a tap
                if ( _currentSwipe.magnitude < MinSwipeLength ) {
                    SwipeDirection = Swipe.None;
                    return;
                }
 
                _currentSwipe.Normalize();
 
                // Swipe up
                if ( _currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f ) {
                    SwipeDirection = Swipe.Up;
                        
                    float x = Random.Range (389f, 395f);
                    float y = Random.Range(651f, 641f);

                    Vector2 whereSpawn = new Vector2 (x, y);
                    GameObject newBullet = Instantiate (Bullet, whereSpawn, Quaternion.identity);
                    newBullet.transform.Translate(10, 0, 0);

                    Debug.Log( "Up" );
                }
                    // Swipe down
                else if ( _currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f ) {
                    SwipeDirection = Swipe.Down;
                    Debug.Log( "Down" );
                }
                    // Swipe left
                else if ( _currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f ) {
                    SwipeDirection = Swipe.Left;
                    Debug.Log( "Left" );
                }
                    // Swipe right
                else if ( _currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f ) {
                    SwipeDirection = Swipe.Right;
                    Debug.Log( "right" );
                }     // Swipe up left
                else if ( _currentSwipe.y > 0 && _currentSwipe.x < 0 ) {
                    SwipeDirection = Swipe.UpLeft;
                    Debug.Log( "UpLeft" );
 
                }
                    // Swipe up right
                else if ( _currentSwipe.y > 0 && _currentSwipe.x > 0 ) {
                    SwipeDirection = Swipe.UpRight;
                    Debug.Log( "UpRight" );
 
                }
                    // Swipe down left
                else if ( _currentSwipe.y < 0 && _currentSwipe.x < 0 ) {
                    SwipeDirection = Swipe.DownLeft;
                    Debug.Log( "DownLeft" );
                    // Swipe down right
                } else if ( _currentSwipe.y < 0 && _currentSwipe.x > 0 ) {
                    SwipeDirection = Swipe.DownRight;
                    Debug.Log( "DownRight" );
                }
            }
    }
}