using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using McMaster.Extensions.CommandLineUtils;

namespace MNG.GenData
{
  [Command(Description = "Read data from back-end service and generate a .csv file")]
  class Program
  {
    public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

    [Argument(0, Description = "Data to be read. Usually a table name.")]
    [Required]
    public string DataName { get; }

    [Argument(1, Description = "Output file name to be written.")]
    [Required]
    public string OutputFile { get; }


    [Option(Description = "Maximum of rows to be read.")]
    [Range(1, 999999)]
    public int MaxRows { get; } = 1;

    private int OnExecute()
    {
      var rnd = new Random();

      using(var writer = new StreamWriter(OutputFile))
      {
        writer.WriteLine("Id,Name,BirthYear");

        for (int n = 1; n <= rnd.Next(500); n++)
        {
          var id = n;
          var name = "User " + n;
          var birthYear = 1960 + rnd.Next(50);

          writer.WriteLine($"{id},{name},{birthYear}");
        } 
      }

      return 0;
    }
  }
}
