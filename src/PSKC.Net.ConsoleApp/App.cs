using System;
using System.IO;
using PSKC.Net.Helper;
using PSKC.Net.Xml;

namespace PSKC.Net.ConsoleApp
{
    public class App
    {
        public void Run(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Invalid call");
                ShowHelp();
                return;
            }

            if (args[0].Equals("-h"))
            {
                ShowHelp();
                return;
            }

            if(args[0].Equals("-f"))
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("No file specified");
                    ShowHelp();
                    return;
                }

                var filePath = args[1];
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("specified file doesn't exist");
                    return;
                }

                var keyContainer = PSKCHelper.ToKeyContainer(filePath);
                ToConsole(keyContainer);

            }

        }

        private void ShowHelp()
        {
            Console.WriteLine(
                "dotnet run PSKC.Net.ConsoleApp -f <file_path>");
        }



        private void ToConsole(KeyContainer keyContainer)
        {
            if (keyContainer.KeyPackages.Count <= 0)
            {
                Console.WriteLine("No KeyPackages found");
                return;
            }

            foreach (var keyPackage in keyContainer.KeyPackages)
            {
                if (keyPackage.DeviceInfo != null)
                {
                    if(!string.IsNullOrWhiteSpace(keyPackage.DeviceInfo.Manufacturer))
                        Console.WriteLine($"Device Manufacturer: {keyPackage.DeviceInfo.Manufacturer}");
                    if (!string.IsNullOrWhiteSpace(keyPackage.DeviceInfo.SerialNo))
                        Console.WriteLine($"Device SerialNo: {keyPackage.DeviceInfo.SerialNo}");
                }

                var key = keyPackage.Key;
                if (key != null)
                {
                    if (!string.IsNullOrWhiteSpace(key.Id))
                        Console.WriteLine($"Key Id: {key.Id}");
                    if (!string.IsNullOrWhiteSpace(key.Algorithm))
                        Console.WriteLine($"Key Algorithm: {key.Algorithm}");

                    var algorithmParameters = key.AlgorithmParameters;
                    if(!string.IsNullOrWhiteSpace(algorithmParameters?.ResponseFormat?.Encoding))
                        Console.WriteLine($"Key AlgorithmParameters ResponseFormat Encoding: {algorithmParameters.ResponseFormat.Encoding}");

                    if (!string.IsNullOrWhiteSpace(algorithmParameters?.ResponseFormat?.Length))
                        Console.WriteLine($"Key AlgorithmParameters ResponseFormat Length: {algorithmParameters.ResponseFormat.Length}");

                    if (!string.IsNullOrWhiteSpace(key.Data?.Secret?.PlainValue))
                    {
                        var hex = PSKCHelper.Base64EncodedBinaryToHex(key.Data.Secret.PlainValue);
                        Console.WriteLine($"Key Data Secret PlainValue (B64): {key.Data.Secret.PlainValue}");
                        Console.WriteLine($"Key Data Secret PlainValue (Hex): {hex}");
                    }

                    if (!string.IsNullOrWhiteSpace(key.Data?.Counter?.PlainValue))
                    {
                        Console.WriteLine($"Key Data Counter PlainValue: {key.Data.Counter.PlainValue}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}