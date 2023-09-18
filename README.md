# DLLReader
How to use dotnet to read value from dll :

consider we have a dll file , and we access the code of creating that dll , something like here :

// Ignore Spelling: Vishkav

namespace produce.dll;


public class ProduceDll
{
    public string firstvalue { get; set; } = "this is first value that is read from dll file";
    public DateTimeOffset firstvalueTime { get; set; } = new DateTimeOffset(2023, 2, 2, 2, 2, 2, TimeSpan.Zero);

}

----------------------------------------------------

now you can see my code and use it to read value of this dll file

good lock
