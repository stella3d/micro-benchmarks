using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class DataOrientedPerfTests : TestFixtureBase
{
	const int k_DataArrayLength = 1000000;

	float[] data = new float[k_DataArrayLength];
	SingleFloatWrapper[] wrapData = new SingleFloatWrapper[k_DataArrayLength];

	MixedData8[] data8 = new MixedData8[k_DataArrayLength];
	MixedData16[] data16 = new MixedData16[k_DataArrayLength];
	MixedData32[] data32 = new MixedData32[k_DataArrayLength];
	MixedData40[] data40 = new MixedData40[k_DataArrayLength];
	MixedData44[] data44 = new MixedData44[k_DataArrayLength];
	MixedData48[] data48 = new MixedData48[k_DataArrayLength];
	MixedData64[] data64 = new MixedData64[k_DataArrayLength];
	MixedData68[] data68 = new MixedData68[k_DataArrayLength];
	MixedData128[] data128 = new MixedData128[k_DataArrayLength];
	MixedData256[] data256 = new MixedData256[k_DataArrayLength];

	[OneTimeSetUp]
	public void Setup()
	{
		for (int i = 0; i < k_DataArrayLength; i++)
		{
			float f = k_DataArrayLength / (i + 1);

			data[i] = f;
			wrapData[i] = new SingleFloatWrapper(f);

			data8[i] = new MixedData8(f, i);
			data16[i] = new MixedData16(f, i);
			data32[i] = new MixedData32(f, i);
			data40[i] = new MixedData40(f, i);
			data44[i] = new MixedData44(f, i);
			data48[i] = new MixedData48(f, i);
			data64[i] = new MixedData64(f, i);
			data68[i] = new MixedData68(f, i);
			data128[i] = new MixedData128(f, i);
			data256[i] = new MixedData256(f, i);
		}
	}

	[SetUp]
	public void BeforeEach()
	{
		m_Timer.Reset();
	}

	[Test]
	public void OneFloat_AllByItself() 
	{
		m_Timer.Start();
		foreach (var entry in data)
			m_TempFloat = entry;

		Debug.Log("pure single floats, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	// this is ~%40-50 faster than a float[] under .net 4.5
	[Test]
	public void OneFloat_WrappedInStruct() 
	{
		m_Timer.Start();
		foreach (var entry in wrapData)
			m_TempFloat = entry.f;

		Debug.Log("struct-wrapped floats, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	// interestingly, this is ~%25 faster than a float[] under .net 4.5
	[Test]
	public void OneFloat_In8ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data8)
			m_TempFloat = entry.f;

		Debug.Log("8 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In16ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data16)
			m_TempFloat = entry.f;

		Debug.Log("16 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In32ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data32)
			m_TempFloat = entry.f;

		Debug.Log("32 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In40ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data40)
			m_TempFloat = entry.f;

		Debug.Log("40 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	// under Mono / .NET 3.5 compatability on my 2015 MBP, 44 bytes 
	// is the point at which the test gets an order of magnitude slower
	[Test]
	public void OneFloat_In44ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data44)
			m_TempFloat = entry.f;

		Debug.Log("44 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In48ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data48)
			m_TempFloat = entry.f;

		Debug.Log("48 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In64ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data64)
			m_TempFloat = entry.f;

		Debug.Log("64 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In68ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data68)
			m_TempFloat = entry.f;

		Debug.Log("68 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In128ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data128)
			m_TempFloat = entry.f;

		Debug.Log("128 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In256ByteStruct() 
	{
		m_Timer.Start();
		foreach (var entry in data256)
			m_TempFloat = entry.f;

		Debug.Log("256 byte structs, elapsed ticks: " + m_Timer.ElapsedTicks);
	}

}
