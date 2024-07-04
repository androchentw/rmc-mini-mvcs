﻿using System;
using UnityEngine;

namespace RMC.Mini.Experimental.ContextLocators
{
	/// <summary>
	/// EXPERIMENTAL: This is an alternative version of
	/// <see cref="IContext"/> that keeps a globally accessible
	/// reference to this context via <see cref="ContextLocator"/>.
	///
	/// USES: See <see cref="ContextLocator"/> for more info.
	/// 
	/// </summary>
	public class ContextWithLocator : BaseContext
	{
		//  Properties ------------------------------------
		
		/// <summary>
		/// FIXME: The lifespan of the <see cref="Singleton{T}"/> is too long due to a bug.
		/// So, this can optionally be used to help limit collisions of Contexts.
		///
		/// Its likely never needed in a typical game project, but the sample project
		/// contains dozens of samples each with a mini and when running unit testing
		/// they are not always cleaned up properly automatically (yet) during testing.
		/// </summary>
		protected readonly string _contextKey = "";
		
		//  Fields ----------------------------------------

		
		//  Initialization  -------------------------------
		public ContextWithLocator(string contextKey = "", bool allowDeletions = true) : base()
		{
			// ContextLocator is Experimental: This allows any scope, including
			// non-mini classes, to access any Context via ContextLocator.Instance.GetItem<T>();
			_contextKey = contextKey;
			ContextLocatorAddItem(allowDeletions);
		}

		public override void Dispose()
		{
			ContextLocatorRemoveItem();
		}
		
		
		//  Methods ---------------------------------------
		private void ContextLocatorAddItem(bool allowDeletions)
		{
			
			
#if UNITY_5_3_OR_NEWER
			
			if (ContextLocator.Instance.HasItem<ContextWithLocator>(_contextKey))
			{
				string message = $"Context with key '{_contextKey}' already exists. So, DELETING existing Context with that key. " +
				                 $"Must pass in unique contextKey. Optional: You can use `Guid.NewGuid().ToString()` to generate a unique key.";

				if (allowDeletions)
				{
					ContextLocator.Instance.RemoveItem<ContextWithLocator>( _contextKey);
					
					//KEEP LOG
					Debug.LogWarning(message);
				}
				else
				{
					throw new Exception(message);
				}
			}
			
			ContextLocator.Instance.AddItem(this, _contextKey);


#endif //if i'm in any version of unity (and thus NOT in Godot)
			
			
			
		}
		
		private void ContextLocatorRemoveItem()
		{
			
			
#if UNITY_5_3_OR_NEWER
			
			if (ContextLocator.Instance.HasItem<Context>(_contextKey))
			{
				ContextLocator.Instance.RemoveItem<Context>(_contextKey);
			}
			
#endif //if i'm in any version of unity (and thus NOT in Godot)
			
			
			
		}
	}
}