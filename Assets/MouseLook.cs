using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float _rotationX = 0;

    public enum RotationAxes
    {
        Both = 0,
        X = 1,
        Y = 2
    }
    public RotationAxes axes = RotationAxes.Both;
    public float sensivity = 7;
    public float maxRotation = 60;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.axes)
        {
            case RotationAxes.X:
                this.transform.Rotate(0, Input.GetAxis("Mouse X") * this.sensivity, 0);

                break;
            case RotationAxes.Y:
                this._rotationX -= Input.GetAxis("Mouse Y") * this.sensivity;
                this._rotationX = Mathf.Clamp(this._rotationX, -this.maxRotation, this.maxRotation);

                var rotationY = this.transform.localEulerAngles.y;

                this.transform.localEulerAngles = new Vector3(this._rotationX, rotationY, 0);

                break;
            case RotationAxes.Both:
                this._rotationX -= Input.GetAxis("Mouse Y") * this.sensivity;
                this._rotationX = Mathf.Clamp(this._rotationX, -this.maxRotation, this.maxRotation);

                rotationY = this.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.sensivity;

                this.transform.localEulerAngles = new Vector3(this._rotationX, rotationY, 0);

                break;
        }
    }
}
