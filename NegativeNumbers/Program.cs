using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NegativeNumbers;

internal enum Op { Add, Subtract, Multiply, Divide }
internal enum CubeOp { GiveSide, GiveFaceArea, GiveTotalArea, GiveVolume }

internal record Problem(int A, int B, Op Operation, int Answer)
{
    public void Deconstruct(out int A, out int B, out Op Operation, out int Answer)
    {
        A = this.A;
        B = this.B;
        Operation = this.Operation;
        Answer = this.Answer;
    }
}

internal class CubeProblem
{
    private double _side;
    private CubeOp _op;
    private CubeProblem()
    {
    }

    private static CubeProblem FromSide(int side)
    {
        var c = new CubeProblem
        {
            _side = side,
            _op = CubeOp.GiveSide
        };
        return c;
    }

    private static CubeProblem FromFace(int face)
    {
        var side = Math.Sqrt(face);
        var c = new CubeProblem
        {
            _side = side,
            _op = CubeOp.GiveFaceArea,
        };
        return c;
    }

    private static CubeProblem FromTotalArea(int totalArea)
    {
        var side = Math.Sqrt(totalArea / 6);
        var c = new CubeProblem
        {
            _side = side,
            _op = CubeOp.GiveTotalArea,
        };
        return c;
    }

    private static CubeProblem FromVolume(int volume)
    {
        var side = Math.Pow(volume, (1 / 3.0));
        var c = new CubeProblem
        {
            _side = side,
            _op = CubeOp.GiveVolume,
        };
        return c;
    }

    public double Side => _side;
    public double Volume => _side * _side * _side;
    public double TotalArea => 6 * _side * _side;
    public double Face => _side * _side;
}


internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            PrintNegSheet();
            PrintCubeSheet();
        }
        catch (Exception ex)
        {
            var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
            var progname = Path.GetFileNameWithoutExtension(fullname);
            Console.Error.WriteLine($"{progname} Error: {ex.Message}");
        }
    }

    private static void PrintCubeSheet()
    {
        var problem = (from q in Enumerable.Range(1, 13)
                       from op in Enumerable.Range(0, Enum.GetNames(typeof(CubeOp)).Length)
    }

    private static void PrintNegSheet()
    {
        using var stream = new StreamWriter("neg-add-sheet.html");
        HtmlHelpers.WriteHead(stream);
        stream.WriteLine(@"<body><table class=""gcdtable"">");

        int count = 0;
        int cols = 2;
        foreach (var (A, B, Operation, Answer) in Problems())
        {
            if (count % cols == 0)
            {
                stream.WriteLine($"<tr>");
            }

            List<XElement> aXml, bXml;
            if (A < 0)
            {
                aXml = new[] { new XElement("mo", new XAttribute("form", "prefix"), "\u2212"), new XElement("mn", -A) }.ToList();
            }
            else
            {
                aXml = new[] { new XElement("mn", A) }.ToList();
            }

            if (B < 0)
            {
                bXml = new[] { new XElement("mo", new XAttribute("form", "prefix"), "\u2212"), new XElement("mn", -B) }.ToList();
            }
            else
            {
                bXml = new[] { new XElement("mn", B) }.ToList();
            }

            stream.WriteLine("<td>");
            var doc = new XDocument(new XElement("div",
                        new XElement("math",
                            new XElement("mstyle", new XAttribute("displaystyle", "true"),
                            new XElement("mrow",
                            aXml,
                            new XElement("mo", new XAttribute("form", "infix"), Operation switch
                            {
                                Op.Add => "+",
                                Op.Subtract => "\u2212",
                                Op.Multiply => "*",
                                Op.Divide => "/",
                            }),
                            bXml
                            )))));
            stream.WriteLine(doc);

            stream.WriteLine("</td>");

            if (count % cols == cols - 1)
            {
                stream.WriteLine($"</tr>");
            }
            count++;
        }

        stream.WriteLine("</table>");
        stream.WriteLine("</body>");
        stream.WriteLine("</html>");
    }

    private static IEnumerable<Problem> Problems()
    {
        var a = Enumerable.Range(-20, 40);
        var b = Enumerable.Range(-20, 40);
        var o = Enumerable.Range(0, 2).Cast<Op>();

        var problems = (from e1 in a
                        from e2 in b
                        from e3 in o
                        let answer = e3 switch
                        {
                            Op.Add => e1 + e2,
                            Op.Subtract => e1 - e2,
                            Op.Multiply => e1 * e2,
                            Op.Divide => e1 / e2,
                        }
                        where e1 != 0 && e2 != 0
                        where e1 < 0 || e2 < 0 || answer < 0
                        select new Problem(e1, e2, e3, answer)).ToList();
        Shuffle(problems);

        foreach (var problem in problems)
        {
            yield return problem;
        }
    }

    public static void Shuffle<T>(IList<T> list)
    {
        var rnd = new Random();

        for (int i = list.Count() - 1; i > 0; i--)
        {
            var j = rnd.Next(i + 1);
            (list[j], list[i]) = (list[i], list[j]);
        }
    }
}
