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

using System;
using System.Collections.Generic;

using MsgPack.Serialization.CollectionSerializers;

namespace MsgPack.Serialization.EmittingSerializers
{
	/// <summary>
	///		A helper <see cref="CollectionMessagePackSerializer{TCollection, TItem}"/> for <see cref="DynamicMethodSerializerBuilder{TObject}"/>.
	/// </summary>
	/// <typeparam name="TCollection">The type of the collection.</typeparam>
	/// <typeparam name="TItem">The type of the item of collection.</typeparam>
	internal class CallbackCollectionMessagePackSerializer<TCollection, TItem> :
		CollectionMessagePackSerializer<TCollection, TItem>
		where TCollection : ICollection<TItem>
	{
		private readonly Func<SerializationContext, int, TCollection> _createInstance;

		/// <summary>
		///		Initializes a new instance of the <see cref="CallbackCollectionMessagePackSerializer{TCollection, TItem}"/> class.
		/// </summary>
		/// <param name="ownerContext">A <see cref="SerializationContext"/> which owns this serializer.</param>
		/// <param name="schema">
		///		The schema for collection itself or its items for the member this instance will be used to. 
		///		<c>null</c> will be considered as <see cref="PolymorphismSchema.Default"/>.
		/// </param>
		/// <param name="createInstance">The delegate to <c>CreateInstance</c> method body. This value must not be <c>null</c>.</param>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="ownerContext"/> is <c>null</c>.
		/// </exception>
		public CallbackCollectionMessagePackSerializer(
			SerializationContext ownerContext,
			PolymorphismSchema schema,
			Func<SerializationContext, int, TCollection> createInstance
		)
			: base( ownerContext, schema )
		{
			this._createInstance = createInstance;
		}

		protected override TCollection CreateInstance( int initialCapacity )
		{
			return this._createInstance( this.OwnerContext, initialCapacity );
		}
	}
}