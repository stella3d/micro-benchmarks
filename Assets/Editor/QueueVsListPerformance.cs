using System;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Debug = UnityEngine.Debug;

public class QueueVsListPerformance : TestFixtureBase
{
  const int k_DataArrayLength = 10000;

  MeshRenderer[] objects = new MeshRenderer[k_DataArrayLength];

  Queue<MeshRenderer> m_Queue;
  List<MeshRenderer> m_List;

  long listTicks;
  long queueTicks;

  [OneTimeSetUp]
  public void Setup()
  {
    m_Queue = new Queue<MeshRenderer>(k_DataArrayLength);
    m_List = new List<MeshRenderer>(k_DataArrayLength);

    for (int i = 0; i < k_DataArrayLength; i++)
    {
      var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
      var mr = cube.GetComponent<MeshRenderer>();
      objects[i] = mr;
      m_Queue.Enqueue(mr);
      m_List.Add(mr);
    }
  }

  [SetUp]
  public void BeforeEach()
  {
    m_Timer.Reset();
  }

  [Test]
  public void AccessByList() 
  {
    m_Timer.Start();

    for (int i = 0; i < k_DataArrayLength; i++)
    {
      m_List.Remove(objects[i]);
    }

    listTicks = m_Timer.ElapsedTicks;
    Debug.Log("access by List<T>, elapsed ticks: " + listTicks);
  }

  [Test]
  public void AccessByQueue() 
  {
    MeshRenderer renderer;
    m_Timer.Start();

    for (int i = 0; i < k_DataArrayLength; i++)
    {
      renderer = m_Queue.Dequeue();
    }

    queueTicks = m_Timer.ElapsedTicks;
    Debug.Log("access by Queue<T>, elapsed ticks: " + queueTicks);
  }

  [OneTimeTearDown]
  public void TearDown()
  {
    var ratio = ((float)queueTicks / (float)listTicks) + " to 1";
    var diff = (float)(listTicks - queueTicks) / (float)k_DataArrayLength;

    Debug.Log("Dequeue to Remove time ratio : " + ratio);
    Debug.Log("An average of " + diff + " ticks saved per call");

    if (objects != null)
      foreach (var obj in objects)
        GameObject.DestroyImmediate(obj);
  }

}
