using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids.Player
{
    class SpaceShipClassLogs
    {
        //StreamWriter sw = new StreamWriter(@"E:\GB Univer практика\TestStreamWriteRead\TestExeptionsLogsFile.txt");
        StreamWriter sw = new StreamWriter(@"C:\Users\Стас\source\repos\WinFormsSpaceShipAsteroids\WinFormsSpaceShipAsteroids\Resources\SpaceShipLogs.txt");
        //  C:\Users\Стас\source\repos\WinFormsSpaceShipAsteroids\WinFormsSpaceShipAsteroids\Resources\SpaceShipLogs.txt
        int[] arr666 = new int[5];

        //StreamWriter
        //try
        //{
        //    arr666[9] = 10;
        //}
        //catch (Exception e)
        //{
        //    sw.WriteLine($" out of index array range ({DateTime.Now}{e.GetType()})");
        //    Console.WriteLine($" out of index array range ({e.GetType()})");
        //}

        //try
        //{
        //    StreamReader sr = new StreamReader("someFile.ini"); // some file to read...
        //}
        //catch (Exception e)
        //{
        //    sw.WriteLine($" error, file not found ({e.GetType()})");
        //}

        //Console.WriteLine("enter integer");
        //if (IntTryParse(Console.ReadLine(), out arr666[0]))
        //{
        //    Console.WriteLine($"parse is OK. num is {arr666[0]}");
        //}
        //else
        //{
        //    Console.WriteLine($"parse is crash . num is {arr666[0]}");
        //}

        //sw.Close();
    }
}
