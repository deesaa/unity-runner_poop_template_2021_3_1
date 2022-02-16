﻿using ECS.Views;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public abstract class LinkableView : MonoBehaviour, ILinkable
	{
		protected EcsEntity Entity;
		public int Hash => transform.GetHashCode();
		public Transform Transform => transform;
		public int UnityInstanceId => gameObject.GetInstanceID();

		public virtual void Link(EcsEntity entity)
		{
			Entity = entity;
		}

		public virtual void Destroy()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying)
				Destroy(gameObject);
			else
				DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
		}

		public virtual void Disable()
		{
			
		}

		/*protected  void DestroyObject()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying)
				Destroy(gameObject);
			else
				DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
		}*/
	}
}