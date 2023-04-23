using System.IO;

namespace NegativeNumbers;

internal class HtmlHelpers
{
    public static void WriteHead(StreamWriter stream)
    {
        stream.WriteLine("<!doctype html>");
        stream.WriteLine("<html lang=\"en\">");
        stream.WriteLine("<head>");
        stream.WriteLine("<title>Nothing</title>");
        stream.WriteLine("<style type='text/css'>");
        stream.WriteLine("body {");
        stream.WriteLine("font-size:20pt;");
        stream.WriteLine("}");
        stream.WriteLine(".sumstable {");
        //stream.WriteLine("text-align:center;");
        stream.WriteLine("margin:0;");
        stream.WriteLine("border-collapse:collapse;");
        stream.WriteLine("}");
        stream.WriteLine(".qn {");
        stream.WriteLine("position:relative;");
        stream.WriteLine("left:-3em;");
        stream.WriteLine("top:-2em;");
        stream.WriteLine("height:5%;");
        stream.WriteLine("font-size:6pt;");
        stream.WriteLine("}");
        stream.WriteLine(".eqn {");
        stream.WriteLine("position:relative;");
        stream.WriteLine("height:50%;");
        stream.WriteLine("}");
        //stream.WriteLine(".sumstable,.sumstable td + td {");
        //stream.WriteLine("padding-left:20px;");
        ////stream.WriteLine("padding-top:20px;");
        //stream.WriteLine("padding-right:100px;");
        ////stream.WriteLine("padding-bottom:20px;");
        //stream.WriteLine("color:black;");
        //stream.WriteLine("white-space: nowrap;");
        //stream.WriteLine("border:solid 1px #dddddd;");
        //stream.WriteLine("}");
        stream.WriteLine(".sumstable,.sumstable td {");
        stream.WriteLine("table-layout:fixed;");
        //stream.WriteLine("padding-right:20px;");
        //stream.WriteLine("color:#dddddd;");
        //stream.WriteLine("white-space: nowrap;");
        stream.WriteLine("border:solid 1px #dddddd;");
        stream.WriteLine("height:3em;");
        stream.WriteLine("padding-left:1em;");
        stream.WriteLine("padding-right:1em;");
        stream.WriteLine("padding-bottom:1em;");
        stream.WriteLine("width:10em;");
        stream.WriteLine("}");


        stream.WriteLine(".gcdtable {");
        //stream.WriteLine("text-align:center;");
        stream.WriteLine("margin:0;");
        stream.WriteLine("border-collapse:collapse;");
        stream.WriteLine("}");

        stream.WriteLine(".gcdtable,.gcdtable td {");
        stream.WriteLine("table-layout:fixed;");
        //stream.WriteLine("padding-right:20px;");
        //stream.WriteLine("color:#dddddd;");
        //stream.WriteLine("white-space: nowrap;");
        stream.WriteLine("border:solid 1px #dddddd;");
        stream.WriteLine("height:3em;");
        stream.WriteLine("padding-left:1em;");
        stream.WriteLine("padding-right:1em;");
        stream.WriteLine("padding-bottom:2em;");
        stream.WriteLine("width:15em;");
        stream.WriteLine("}");

        stream.WriteLine(@".gcdtable tr:nth-child(9n) {
    page-break-after: always;
    page-break-inside: avoid;
}");


        stream.WriteLine(".answerstable {");
        stream.WriteLine("border-collapse:collapse;");
        stream.WriteLine("text-align:center;");
        stream.WriteLine("}");
        stream.WriteLine(".answerstable, .answerstable td {");
        stream.WriteLine("padding-left:20px;");
        stream.WriteLine("padding-right:20px;");
        stream.WriteLine("color:black;");
        stream.WriteLine("white-space: nowrap;");
        stream.WriteLine("border:solid 1px #dddddd;");
        stream.WriteLine("}");
        stream.WriteLine(".pageDivider {");
        stream.WriteLine("page-break-before: always;");
        stream.WriteLine("}");
        stream.WriteLine(".tickslabel {");
        stream.WriteLine("font-size: 12pt;");
        stream.WriteLine("}");
        stream.WriteLine("</style>");
        stream.WriteLine("<script>");
        stream.WriteLine("</script>");
        stream.WriteLine("</head>");
    }
}
