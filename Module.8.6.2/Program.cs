string directoryPath = "Folder";

if (!Directory.Exists(directoryPath))
{
    Console.WriteLine("Указанная папка не существует");
    return;
}
try
{
    long size = GetDirectorySize(directoryPath);
    Console.WriteLine($"Размер папки : {size} ");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Ошибка: Нет прав доступа для чтения файлов или папок.");
}
catch (Exception e)
{
    Console.WriteLine($"Произошла непредвиденная ошибка: {e.Message}");
}
long GetDirectorySize(string directoryPath)
{
    long size = 0;


    string[] fileNames = Directory.GetFiles(directoryPath);
    foreach (string fileName in fileNames)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        size += fileInfo.Length;
    }


    string[] subDirectoryNames = Directory.GetDirectories(directoryPath);
    foreach (string subDirectoryName in subDirectoryNames)
    {
        size += GetDirectorySize(subDirectoryName);
    }

    return size;
}