#region -- License Terms --
// 
// MessagePack for CLI
// 
// Copyright (C) 2015 FUJIWARA, Yusuke
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
#endregion -- License Terms --

#if UNITY_5 || UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WII || UNITY_IPHONE || UNITY_ANDROID || UNITY_PS3 || UNITY_XBOX360 || UNITY_FLASH || UNITY_BKACKBERRY || UNITY_WINRT
#define UNITY
#endif

using System;
#if !UNITY
using System.Collections.Generic;
#endif // !UNITY

using MsgPack.Serialization.CollectionSerializers;

namespace MsgPack.Serialization.ReflectionSerializers
{
#if !UNITY
	internal sealed class ReflectionDictionaryMessagePackSerializer<TDictionary, TKey, TValue> : DictionaryMessagePackSerializer<TDictionary, TKey, TValue>
		where TDictionary : IDictionary<TKey, TValue>
#else
	internal sealed class ReflectionDictionaryMessagePackSerializer : UnityDictionaryMessagePackSerializer
#endif // !UNITY
	{
#if !UNITY
		private readonly Func<int, TDictionary> _factory;
#else
		private readonly Func<int, object> _factory;
#endif // !UNITY

#if !UNITY
		public ReflectionDictionaryMessagePackSerializer(
			SerializationContext ownerContext,
			Type targetType,
			PolymorphismSchema itemsSchema 
		)
			: base( ownerContext, itemsSchema )
		{
			this._factory = ReflectionSerializerHelper.CreateCollectionInstanceFactory<TDictionary, TKey>( targetType );
		}
#else
		public ReflectionDictionaryMessagePackSerializer(
			SerializationContext ownerContext,
			Type abstractType,
			Type concreteType,
			Type keyType,
			Type valueType,
			CollectionTraits traits,
			PolymorphismSchema itemsSchema 
		)
			: base( ownerContext, abstractType, keyType, valueType, traits, itemsSchema )
		{
			this._factory = ReflectionSerializerHelper.CreateCollectionInstanceFactory( abstractType, concreteType, keyType );
		}
#endif // !UNITY

#if !UNITY
		protected override TDictionary CreateInstance( int initialCapacity )
#else
		protected override object CreateInstance( int initialCapacity )
#endif // !UNITY
		{
			return this._factory( initialCapacity );
		}
	}
}