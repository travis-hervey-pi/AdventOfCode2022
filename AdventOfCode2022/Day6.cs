namespace AdventOfCode2022
{
    internal static class Day6
    {
        public static void Execute()
        {
            // Setup
            // nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg
            var data = File.ReadAllText("input.txt");
            var startPacketPosition = 0;
            var startMessagePacket = 0;
            var packetBuffer = new Queue<char>();
            var messageBuffer = new Queue<char>();

            for (int i = 0; i < data.Length; i++)
            {
                packetBuffer.Enqueue(data[i]);
                if(packetBuffer.Count == 4 && startPacketPosition == 0)
                {
                    if (packetBuffer.Distinct().Count() == 4)
                    {
                        startPacketPosition = i + 1;
                    }
                    packetBuffer.Dequeue();
                }
                messageBuffer.Enqueue(data[i]);
                if (messageBuffer.Count == 14 && startMessagePacket == 0)
                {
                    if (messageBuffer.Distinct().Count() == 14)
                    {
                        startMessagePacket = i + 1;
                    }
                    messageBuffer.Dequeue();
                }
            }

            Console.WriteLine(startPacketPosition);
            Console.WriteLine(startMessagePacket);
            Console.ReadKey();
        }
    }
}
