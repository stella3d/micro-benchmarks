using UnityEngine;
using NUnit.Framework;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class HeapVsStack
{
	const int k_DataArrayLength = 10000;

    static Vector3 m_TempVector;

    class HeapData
    {
        public float confidence { get; set; }
        public Vector3 direction { get; set; }

        public HeapData(float confidence, Vector3 direction)
        {
            this.confidence = confidence;
            this.direction = direction;
        }
    }

    struct StackData
    {
        public float confidence { get; set; }
        public Vector3 direction { get; set; }

        public StackData(float confidence, Vector3 direction)
        {
            this.confidence = confidence;
            this.direction = direction;
        }
    }

    HeapData[] heapData = new HeapData[k_DataArrayLength];
    StackData[] stackData = new StackData[k_DataArrayLength];

	long accessHeapTicks, accessStackTicks;
	long setHeapTicks, setStackTicks;

    Stopwatch m_Timer = new Stopwatch();
    float m_TempFloat;

    [OneTimeSetUp]
	public void Setup()
	{
		for (int i = 0; i < k_DataArrayLength; i++)
		{
			float f = k_DataArrayLength / (i + 1);
            Vector3 direction = UnityEngine.Random.onUnitSphere;
            heapData[i] = new HeapData(f, direction);
            stackData[i] = new StackData(f, direction);
		}
	}

	[SetUp]
	public void BeforeEach()
	{
		m_Timer.Reset();
	}

	[Test]
	public void AccessHeapData() 
	{
		m_Timer.Start();
        foreach (var entry in heapData)
        {
            m_TempFloat = entry.confidence;
            m_TempVector = entry.direction;
        }

        accessHeapTicks = m_Timer.ElapsedTicks;
		Debug.Log("access on heap, elapsed ticks: " + accessHeapTicks);
    }

    [Test]
    public void AccessStackData()
    {
        m_Timer.Start();
        foreach (var entry in stackData)
        {
            m_TempFloat = entry.confidence;
            m_TempVector = entry.direction;
        }

        accessStackTicks = m_Timer.ElapsedTicks;
        Debug.Log("access on stack, elapsed ticks: " + accessStackTicks);
    }

    [Test]
    public void SetHeapData()
    {
        Vector3 direction = UnityEngine.Random.onUnitSphere;

        m_Timer.Start();
        for (int i = 0; i < k_DataArrayLength; i++)
            heapData[i].direction = direction;

        setHeapTicks = m_Timer.ElapsedTicks;
        Debug.Log("set on heap, elapsed ticks: " + accessHeapTicks);
    }

    [Test]
    public void SetStackData()
    {
        Vector3 direction = UnityEngine.Random.onUnitSphere;

        m_Timer.Start();
        for (int i = 0; i < k_DataArrayLength; i++)
            stackData[i].direction = direction;

        setStackTicks = m_Timer.ElapsedTicks;
        Debug.Log("set on stack, elapsed ticks: " + accessHeapTicks);
    }

    [OneTimeTearDown]
	public void TearDown()
	{
		var ratio = ((float)accessHeapTicks / (float)accessStackTicks) + " to 1";
		var diff = (float)(accessHeapTicks - accessStackTicks) / (float)k_DataArrayLength;
		
		Debug.Log("Heap access time to Stack access time ratio : " + ratio);
		Debug.Log("An average of " + diff + " ticks diff per call");

        var setRatio = ((float)setHeapTicks / (float)setStackTicks) + " to 1";
        var setDiff = (float)(setHeapTicks - setStackTicks) / (float)k_DataArrayLength;

        Debug.Log("Heap set time to Stack set time ratio : " + setRatio);
        Debug.Log("An average of " + setDiff + " ticks diff per call");
    }

}
