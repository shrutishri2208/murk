using UnityEngine;


public class walls : MonoBehaviour
{

    public playerMovement pm;
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "leftWall")
        {
            //toMoveRight
            pm.moveRight();

        }
        else if (collisionInfo.collider.tag == "rightWall")
        {
            //toMoveLeft
            pm.moveLeft();
        }
    }


}
