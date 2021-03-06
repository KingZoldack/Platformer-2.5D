using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform targetA, targetB;

    [SerializeField]
    Transform _playerObject;

    [SerializeField]
    float _speed = 2f;

    bool _switchTargets = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_switchTargets)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetB.position, _speed * Time.deltaTime);
        }

        else if (_switchTargets)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetA.position, _speed * Time.deltaTime);
        }

        if (transform.position == targetB.position)
        {
            _switchTargets = true;
        }

        else if (transform.position == targetA.position)
        {
            _switchTargets = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
