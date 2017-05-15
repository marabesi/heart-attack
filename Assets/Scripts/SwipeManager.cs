using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Swipe {
    None,
    Up,
    Down,
    Left,
    Right,
    UpLeft,
    UpRight,
    DownLeft,
    DownRight
};
 
public abstract class SwipeManager : MonoBehaviour {
    public float MinSwipeLength = 5f;
 
    protected Vector2 _firstPressPos;
    protected Vector2 _secondPressPos;
    protected Vector2 _currentSwipe;
 
    protected Vector2 _firstClickPos;
    protected Vector2 _secondClickPos;
    
    public GameObject Bullet;

    public static Swipe SwipeDirection;
    public float ReturnForce = 10f;

    private void Update() {
        DetectSwipe();
    }
 
    public abstract void DetectSwipe();
}