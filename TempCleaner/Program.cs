namespace TempCleaner
{
    internal class Program
    {
        static void Main(string[] args)
        {
                string tempPath = Path.GetTempPath();

                if (Directory.Exists(tempPath))
                {

                    var files = Directory.GetFiles(tempPath);
                    var subfolders = Directory.GetDirectories(tempPath);

                    foreach (var file in files)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete file: {file}. Reason: {ex.Message}");
                            continue;
                        }
                    }
                    foreach (var subfolder in subfolders)
                    {
                        try
                        {
                            DeleteDirectoryRecursively(subfolder);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete folder: {subfolder}. Reason: {ex.Message}");
                            continue;
                        }
                    }
                }

                Console.WriteLine($"{tempPath} is clear.");
                Console.WriteLine("Press Any key to exit...");
                Console.ReadKey();

                void DeleteDirectoryRecursively(string targetDir)
                {
                    var files = Directory.GetFiles(targetDir);
                    foreach (var file in files)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete file: {file}. Reason: {ex.Message}");
                            continue;
                        }
                    }

                    var subdirectories = Directory.GetDirectories(targetDir);
                    foreach (var subdirectory in subdirectories)
                    {
                        DeleteDirectoryRecursively(subdirectory);
                    }

                    try
                    {
                        Directory.Delete(targetDir);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not delete folder: {targetDir}. Reason: {ex.Message}");
                    }
                }
        }
    }
}
