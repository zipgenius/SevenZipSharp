using SevenZip;

// Ask user to enter the path of a .7z or a .zip archive.
Console.Write("Please, enter the path to a .7z or a .zip archive file:\n");

// Wait for user input, then strip quotes from the path, if any
string arcPath = Console.ReadLine().Replace("\"",""); 

if (Path.GetExtension(arcPath.ToLower()) == ".7z" || Path.GetExtension(arcPath.ToLower()) == ".zip")
{
    // Set library path or SevenZipSharp won't work.
    SevenZipBase.SetLibraryPath("Libs\\7z64.dll");
    SevenZipExtractor sz = new SevenZipExtractor(arcPath);
    Console.WriteLine("");

    // Output some archive info
    FileInfo arcInfo = new FileInfo(arcPath);
    Console.WriteLine(new string('-', 70));
    Console.WriteLine("Archive: " + arcPath);
    Console.WriteLine("Files: "+ sz.ArchiveFileData.Count.ToString());
    Console.WriteLine("Size (bytes): " + arcInfo.Length.ToString()+" bytes");
    Console.WriteLine(new string('-', 70));

    Console.WriteLine("");

    // Output table headers
    Console.WriteLine("{0,-55} {1,-25} {2,-20} {3,-15}", "Filename", "Last Modified", "Orig. Size (bytes)", "Pack. Size (bytes)");
    Console.WriteLine(new string('-', 120));

    // Output fake file details
    foreach (ArchiveFileInfo entry in sz.ArchiveFileData)
    {
        Console.WriteLine("{0,-55} {1,-25} {2,-20} {3,-15}",
            entry.FileName,
            entry.LastWriteTime.ToString(),
            entry.Size.ToString(),
            entry.PackedSize.ToString());
    }

    // Separate headers from data with a row
    Console.WriteLine(new string('-', 120));
} else
{
    Console.WriteLine("WARNING: this is just a sample app and it's not meant to open any kind of archive.");
}