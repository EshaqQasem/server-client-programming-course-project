using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Net;
using System.IO;
    
namespace whatsApp_1._0
{
    public class UncompleteFileMessage
    {
        public UncompleteFileMessage(FileMessage fileMessage)
        {
            Message = fileMessage;
            Directory.CreateDirectory(Message.Reciever + "\\" + Message.Sender);
            Message.Path = (Message.Reciever +"\\"+ Message.Sender+"\\" + Message.Id.ToString() + Message.FileName);


        }
        public void Append(FilePartMessage filePart)
        {
            FileStream stream = new FileStream(Message.Path, FileMode.Append);
            stream.Write(filePart.FilePart, 0, filePart.FilePart.Length);
            long fileSize = stream.Length;
            stream.Close();
            if (fileSize == Message.FileSize)
            {
                Message.IsComplete = true;
                OnRecieveCompelete(Message);
            }
        }

        public Action<FileMessage> OnRecieveCompelete;
        public UInt32 Id { set => Message.Id = value; get => Message.Id; }
        public FileMessage Message { get; set; }

    }
}
