using System.Drawing;
using System.Xml.Serialization;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using GraphVizNet;
using Relatics2GraphvizDot.InputXml;

XmlSerializer serializer = new XmlSerializer(typeof(elements));
using FileStream fileStream = new FileStream("test 2025-07-02 18_26 UTC+2.xml", FileMode.Open);
elements relaticsXml = (elements?)serializer.Deserialize(fileStream) ?? new();

var factoryNamesById = relaticsXml
    .Factory
    .Element
    .ToDictionary(f => f.id, f => new Factory(f.id, f.name));

var itemNamesById = relaticsXml
    .Item
    .Element
    .ToDictionary(f => f.id, f => new Item(f.id, f.name));

var transportNamesById = relaticsXml
    .FactoryImport
    .Element
    .ToDictionary(f => f.id, f => new Transport(
        f.id,
        f.carries.Item is not null ? itemNamesById[f.carries.Item.id] : new Item("?", "?"),
        f.amountperminute,
        f.method,
        factoryNamesById[f.Shipfrom.Factory.id],
        factoryNamesById[f.providesitemsto.Factory.id]));

var graph = new DotGraph().WithIdentifier("MyDirectedGraph").Directed();

foreach (var f in factoryNamesById.Values)
{
    graph.Add(
        new DotNode()
            .WithIdentifier(f.Id)
            .WithShape(DotNodeShape.Rectangle)
            .WithLabel(f.Name));
}

foreach (var t in transportNamesById.Values)
{
    graph.Add(
        new DotEdge()
            .From(t.From.Id)
            .To(t.To.Id)
            .WithLabel($"{t.AmountPerMinute:N0}")
            .WithArrowHead(DotEdgeArrowType.Normal)
            .WithColor(t.Color)
            .WithStyle(DotEdgeStyle.Dashed)
            .WithPenWidth(1.5));
}

await using var writer = new StringWriter();
await graph.CompileAsync(new CompilationContext(writer, new CompilationOptions()));
var dot = writer.GetStringBuilder().ToString();

var graphViz = new GraphViz();
graphViz.LayoutAndRenderDotGraph(dot, "..\\test.png", "png");

record Factory(string Id, string Name);
record Item(string Id, string Name);
record Transport(string Id, Item Item, decimal AmountPerMinute, string Method, Factory From, Factory To)
{
    public DotColor Color => Item.Name switch
    {
        "Rubber" => DotColor.DarkGray,
        _ => DotColor.Aqua,
    };
};
