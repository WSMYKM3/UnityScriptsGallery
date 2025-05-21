using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class PulseToBeat : MonoBehaviour
{
    [SerializeField] bool _useTestBeat;
    [SerializeField] float _pulseSize = 1.15f;//in pulse function, it enlarge by this value
    [SerializeField] float _returnSpeed = 5f;// Speed at which the object returns to its original size after pulsing.
    private Vector3 _startSize;
    void Start()
    {
        _startSize = transform.localScale;
        if ( _useTestBeat)
        {
            StartCoroutine(TestBeat());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //The rate of interpolation is controlled by _returnSpeed.
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, Time.deltaTime * _returnSpeed);
    }
    public void Pulse()
    {
        transform.localScale = _startSize * _pulseSize;
    }

    IEnumerator TestBeat()
    {
        while (true)
        {    
            yield return new WaitForSeconds(1f);// Wait for 1 second before continuing to the next line
            Pulse();
        }
    }
}
