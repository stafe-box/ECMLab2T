using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace ECMLab2T
{
    class Client
    {
        static void Run()
        {
            using (NamedPipeClientStream Client = new(".", "channel", PipeDirection.InOut))
            {
                Client.Connect();
                try
                {
                    while (true)
                    {
                        byte[] bytes = new byte[Unsafe.SizeOf<SomeData>()];
                        Client.Read(bytes, 0, bytes.Length);
                        SomeData receivedData = Unsafe.As<byte, SomeData>(ref bytes[0]);
                        Console.WriteLine($"Received data: n = {receivedData.n}, m = {receivedData.m}");

                        receivedData.n *= receivedData.m;
                        byte[] modified_bytes = new byte[Unsafe.SizeOf<SomeData>()];
                        Unsafe.As<byte, SomeData>(ref modified_bytes[0]) = receivedData;
                        Client.Write(modified_bytes, 0, modified_bytes.Length);
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
