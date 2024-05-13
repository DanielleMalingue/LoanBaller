﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class EMSingleton<T> : MonoBehaviour where T : EMSingleton<T>{

	private static T m_Instance = null;
	
	public static T instance{
		get{
			if( m_Instance == null ){
				m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
				if( m_Instance == null ){
					m_Instance = new GameObject("EMMotionManager",typeof(T)).GetComponent<T>();
					m_Instance.Init();
				}
				
			}
			return m_Instance;
		}
	}
	
	private void Awake(){
		
		if( m_Instance == null ){
			m_Instance = this as T;
		}
	}
	
	public virtual void Init(){}
	
	
	private void OnApplicationQuit(){
		m_Instance = null;
	}
}
