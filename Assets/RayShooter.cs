using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        this._camera = this.GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var point = new Vector3(this._camera.pixelWidth / 2, this._camera.pixelHeight / 2, 0);
            var ray = this._camera.ScreenPointToRay(point);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                this.StartCoroutine(this.SphereIndicator(hit.point));
            }
        }
    }

    void OnGUI()
    {
        int size = 12;
        var positionX = this._camera.pixelWidth / 2 - size / 2;
        var positionY = this._camera.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(positionX, positionY, size, size), "*");
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = position;

        yield return new WaitForSeconds(5);

        Destroy(sphere);
    }
}
