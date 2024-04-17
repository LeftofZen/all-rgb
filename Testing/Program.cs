// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Text;

var hil = "a";
var Width = 256;
var iterations = ((int)Math.Log2(Width)) - 1;
iterations = 0;
for (int i = 0; i < iterations; ++i)
{
	hil = HilbertReplace(hil);
}

// length is 4^iterations 

Console.WriteLine(hil);
Console.WriteLine($"iterations={iterations} length={hil.Length}");
Console.ReadLine();

static string HilbertReplace(string curve)
{
	var sb = new StringBuilder();
	foreach (var c in curve)
	{
		sb.Append(HilbertReplaceC(c));
	}
	return sb.ToString();
}

static string HilbertReplaceC(char c)
{
	if (c == 'a')
	{
		return "d↑a→a↓b";
	}
	if (c == 'b')
	{
		return "c←b↓b→a";
	}
	if (c == 'c')
	{
		return "b↓c←c↑d";
	}
	if (c == 'd')
	{
		return "a→d↑d←c";
	}
	return string.Empty;
}