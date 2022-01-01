using System;
using System.Collections.Generic;

namespace Packet_Versions
{
    public class Packet
    {
        public int startIndex = 0;
        public int packetLength = 0;

        public long version = 0;
        public long typeID = 0;

        public char lenTypeID = '0';
        public long LiteralValue;

        public List<Packet> subPackets = new List<Packet>();

        public long versionTotal;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string binaryData = HexToBinary(System.IO.File.ReadAllText(@"C:\Users\lukej\OneDrive\Documents\Personal Projects\AdventOfCode\Packet Versions\HexCode.txt"));

            Packet p = PacketCalc(binaryData, 0);
            foreach (var entry in p.subPackets)
            {
                p.versionTotal += entry.version;
            }
            Console.WriteLine("Version: " + p.version + "   Type ID: " + p.typeID + "   Version Total: " + p.versionTotal);
        }

        static Packet PacketCalc(string binary, int start)
        {
            Packet p = new Packet();
            p.startIndex = start;

            p.version = BinaryToLong(binary[p.startIndex] + "" + binary[p.startIndex + 1] + "" + binary[p.startIndex + 2]);
            p.typeID = BinaryToLong(binary[p.startIndex + 3] + "" + binary[p.startIndex + 4] + "" + binary[p.startIndex + 5]);

            if (p.typeID == 4)
            {
                p = LiteralPacketValue(binary, p);
                long test = p.LiteralValue;
                return p;
            }

            //          vvv    Packet is an opeator    vvv

            p.lenTypeID = binary[p.startIndex + 6];

            int n = p.startIndex;
           
            if (p.lenTypeID == '0')
            {
                string lengthBinary = "";
                for (int i = n + 7; i < n + 22; i++)
                {
                    lengthBinary += binary[i];
                }
                long length = BinaryToLong(lengthBinary);

                int runningTotal = n + 22;
                while (runningTotal < 22 + length)
                {
                    Packet newP = PacketCalc(binary, runningTotal);
                    p.packetLength += newP.packetLength;
                    runningTotal += newP.packetLength;
                    p.LiteralValue += newP.LiteralValue;
                    foreach (var entry in newP.subPackets)
                    {
                        p.subPackets.Add(entry);
                    }
                }
            }

            else
            {
                string lengthBinary = "";
                for (int i = n + 7; i < n + 18; i++)
                {
                    lengthBinary += binary[i];
                }
                long length = BinaryToLong(lengthBinary);

                int runningTotal = 0;
                int prevLength = 0;
                while (runningTotal < length)
                {
                    Packet newP = PacketCalc(binary, p.startIndex + prevLength + 18);
                    p.packetLength += newP.packetLength;
                    prevLength += newP.packetLength;
                    runningTotal++;
                    p.LiteralValue += newP.LiteralValue;
                    foreach (var entry in newP.subPackets)
                    {
                        p.subPackets.Add(entry);
                    }
                }
            }

            return p;
        }

        static Packet LiteralPacketValue(string binary, Packet packet)
        {
            bool scanData = true;
            string total = "";
            int currInd = packet.startIndex;
            packet.packetLength += 6;
            currInd += 6;

            while (scanData)
            {
                if (binary[currInd] == '0')
                {
                    scanData = false;
                }

                string current = "";
                for (int i = currInd + 1; i < currInd + 5; i++)
                {
                    current += binary[i];
                }
                currInd += 5;
                total += current;
                packet.packetLength += 5;
            }

            packet.LiteralValue += BinaryToLong(total);

            return packet;
        }



        static long BinaryToLong(string binary)
        {
            long value = 0;
            int count = 0;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                value += (Convert.ToInt32(binary[i]) - 48) * (long)Math.Round(Math.Pow(2, count));
                count++;
            }
            return value;
        }

        static string HexToBinary(string hexString)
        {
            string binary = "";
            for (int i = 0; i < hexString.Length; i++)
            {
                char hex = hexString[i];
                switch (hex)
                {
                    case '0': binary += "0000"; break;
                    case '1': binary += "0001"; break;
                    case '2': binary += "0010"; break;
                    case '3': binary += "0011"; break;
                    case '4': binary += "0100"; break;
                    case '5': binary += "0101"; break;
                    case '6': binary += "0110"; break;
                    case '7': binary += "0111"; break;
                    case '8': binary += "1000"; break;
                    case '9': binary += "1001"; break;
                    case 'A': binary += "1010"; break;
                    case 'B': binary += "1011"; break;
                    case 'C': binary += "1100"; break;
                    case 'D': binary += "1101"; break;
                    case 'E': binary += "1110"; break;
                    case 'F': binary += "1111"; break;
                }
            }
            return binary;
        }
    }
}
