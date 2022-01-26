using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    float rotateDegreesPerSecond = 360;

    //GameObject sphere;
    //GameObject cube;
    //Material sphereMaterial;
    //Material cubeMaterial;

    [SerializeField] private LayerMask mouseColliderLayerMask = new LayerMask();

    private void Start()
    {
        //sphere = this.gameObject.transform.GetChild(0).gameObject;
        //cube = this.gameObject.transform.GetChild(1).gameObject;
        //sphereMaterial = sphere.GetComponent<Material>();
        //cubeMaterial = cube.GetComponent<Material>();
    }

    private void Update()
    {
        //Debug.Log("Mouseposition: " + GetMouseWorldPosition());
        RotateTarget();
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = GetMouseWorldPosition();
            //Debug.Log("Targetposition: " + transform.position);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    sphereMaterial.color = Color.green;
    //    cubeMaterial.color = Color.green;
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    sphereMaterial.color = Color.red;
    //    cubeMaterial.color = Color.red;
    //}

    private void RotateTarget()
    {
        transform.Rotate(new Vector3(0, rotateDegreesPerSecond, 0) * Time.deltaTime);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, mouseColliderLayerMask))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
