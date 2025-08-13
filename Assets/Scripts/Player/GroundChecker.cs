using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private MeshRenderer _renderer;


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        _renderer.enabled = _controller.isGrounded;
    }
}
