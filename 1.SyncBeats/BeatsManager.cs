using UnityEngine;
using UnityEngine.Events;

public class BeatsManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Intervals[] _intervals;
    

    // Update is called once per frame
    void Update()
    {
        foreach (Intervals interval in _intervals)
        {
            float sampledTIme = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLength(_bpm)));
            interval.CheckForNewInterval(sampledTIme);
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float _subdivisions;//How many beats per measure
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval;

    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * _subdivisions);//60f means 60 seconds,this line claculate jixia(biru sisipai => sixia) will be released per seconds
    }

    public void CheckForNewInterval(float interval)
    {
        if(Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }    
    }
}
