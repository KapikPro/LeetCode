using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text;

using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

Stopwatch a = new Stopwatch();
a.Start();
int n = int.Parse(input.ReadLine()??"0");
for (int i = 0; i < n; i++)
{
    int quantity = int.Parse(input.ReadLine()??"0");
    StringBuilder s = new StringBuilder();
    
    for (int j = 0; j < quantity; j++)
    {
        s.Append(input.ReadLine());
    }
    Json? json = JsonSerializer.Deserialize<Json>(s.ToString(), new JsonSerializerOptions { MaxDepth = 800 });
    if (json == null)
    {
        Console.WriteLine("Invalid Json");
    }
    //Console.WriteLine("1---------------------------------------------------------");
    //Console.WriteLine(a.Elapsed);
    int result = 0;
    Solution(json ?? new Json(), false, ref result);
    output.WriteLine(result);
    //Console.WriteLine(a.Elapsed);
    //Console.WriteLine("2---------------------------------------------------------");
}

void Solution(Json json, bool flag, ref int result)
{
    Regex regex = new Regex(@".*\.hack$");
    if (flag == false)
    {
        for (int i = 0; i < json.Files?.Count; i++)
        {
            if (regex.IsMatch(json.Files[i]))
            {
                result += json.Files.Count;
                flag = true;
                break;
            }
        }
    }
    else
    {
        result += json.Files?.Count??0;
    }

    for (int i = 0; i < json.Folders?.Count; i++)
    {
        Solution(json.Folders[i], flag, ref result);
    }
}

class Json
{
    [JsonPropertyName("dir")]
    protected string? Dir{get; set; }
    [JsonPropertyName("files")]
    public IReadOnlyList<string>? Files{get; set; }
    [JsonPropertyName("folders")]
    public IReadOnlyList<Json>? Folders{get; set; }
}