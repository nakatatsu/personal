using System;
using System.IO;
using MsgPack.Serialization;

namespace Persistence
{
    interface IFile<T>
    {
        void Write(string filename, T target);
        T Read(string filename);
    }

    public class MsgpackFile<T> : IFile<T>
    {
        /// <summary>
        /// 渡されたオブジェクトをmessagepackファイルとして保存する
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="targetObject">保存するオブジェクト</param>
        public void Write(string filename, T target)
        {
            var stream = new MemoryStream();

            // シリアライザを宣言
            var serializer = MessagePackSerializer.Get<T>();

            // メッセージパック化
            serializer.Pack(stream, target);

            // バイトデータとして取得
            byte[] data = stream.ToArray();

            // 保存
            File.WriteAllBytes(filename, data);
        }


        /// <summary>
        /// ファイルから読みだしたオブジェクトを返す
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <returns></returns>
        public T Read(string filename)
        {
            // バイトデータを読み取り
            byte[] dataByFile = File.ReadAllBytes(filename);

            // ストリームに。
            var stream = new MemoryStream(dataByFile);

            // シリアライザを呼び出して
            var serializer = SerializationContext.Default.GetSerializer<T>();

            // ストリームからオブジェクトへデシリアライズ
            var deserializedObject = serializer.Unpack(stream);

            // ご帰還
            return deserializedObject;
        }
    }


}
