using System;
using System.IO;

namespace dotnetproject.Helpers;

public class EnvConfig {
    public Dictionary<string, string> EnvVariables = new Dictionary<string, string>();

    public void Load(string path) {
        try
        {
            if (!File.Exists(path)) {
                throw new FileNotFoundException($".env file cannot be found at path {path}");
            }

            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Split("=", StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2) {
                    continue;
                }

                EnvVariables.Add(parts[0], parts[1]);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex);
        }
    }
}