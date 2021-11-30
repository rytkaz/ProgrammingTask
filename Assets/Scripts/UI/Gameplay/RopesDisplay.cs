using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RopesDisplay : MonoBehaviour
{
    [SerializeField] private Transform RopesRoot;
    [SerializeField] private GameObject RopePrefab;
    [SerializeField] private float RopeConnectionSpeed;

    public UnityEvent OnRopeAnimationsFinished;

    private bool IsAnimationPlaying = false;
    private List<RectTransform> SpawnedRopes = new List<RectTransform>();
    private int LastUsedRopeIndex = -1;
    private List<RopeData> RopesQueue = new List<RopeData>();

    public void Hide()
    {
        foreach(var rope in SpawnedRopes)
        {
            rope.gameObject.SetActive(false);
        }

        LastUsedRopeIndex = -1;
    }

    public void ConnectPoints(Vector2 startPoint, Vector2 endPoint)
    {
        RopesQueue.Add(new RopeData(startPoint, endPoint));
        if (!IsAnimationPlaying)
        {
            StartCoroutine(AnimateRope());
        }
    }

    private IEnumerator AnimateRope()
    {
        IsAnimationPlaying = true;
        LastUsedRopeIndex++;
        if(LastUsedRopeIndex >= SpawnedRopes.Count)
        {
            SpawnedRopes.Add(Instantiate(RopePrefab, RopesRoot).GetComponent<RectTransform>());
        }

        RectTransform ropeToAnimate = SpawnedRopes[LastUsedRopeIndex];
        ropeToAnimate.gameObject.SetActive(true);
        ropeToAnimate.localPosition = RopesQueue[0].StartPoint;
        ropeToAnimate.sizeDelta = new Vector2(ropeToAnimate.sizeDelta.x, 0);
        float distance = Vector2.Distance(RopesQueue[0].StartPoint, RopesQueue[0].EndPoint);
        ropeToAnimate.up = RopesQueue[0].StartPoint - RopesQueue[0].EndPoint;

        while(ropeToAnimate.sizeDelta.y < distance)
        {
            ropeToAnimate.sizeDelta += new Vector2(0, RopeConnectionSpeed * Time.deltaTime);
            yield return null;
        }

        RopesQueue.RemoveAt(0);
        IsAnimationPlaying = false;
        OnRopeAnimationComplete();
    }

    private void OnRopeAnimationComplete()
    {
        if(RopesQueue.Count > 0)
        {
            StartCoroutine(AnimateRope());
        }
        else
        {
            OnRopeAnimationsFinished?.Invoke();
        }
    }

    private struct RopeData
    {
        public Vector2 StartPoint;
        public Vector2 EndPoint;

        public RopeData(Vector2 startPoint, Vector2 endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
