using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;

    public float Speed = 25f;

    private void Update()
    {

        if(GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(Target.position, Vector3.up, Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(Target.position, Vector3.up, -Speed * Time.deltaTime);
        }
    }
}
