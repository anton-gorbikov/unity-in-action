using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/KeyboardMovement")]
public class KeyboardMovement : MonoBehaviour
{
    private CharacterController _character;

    public float movementSpeed = 5;
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        this._character = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * this.movementSpeed;
        var deltaZ = Input.GetAxis("Vertical") * this.movementSpeed;
        var movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, this.movementSpeed);
        movement.y = this.gravity;
        movement *= Time.deltaTime;
        movement = this.transform.TransformDirection(movement);

        this._character.Move(movement);
    }
}
