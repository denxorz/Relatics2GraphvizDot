using System.Xml.Serialization;
using GiGraph.Dot.Entities.Graphs;
using Relatics2GraphvizDot.InputXml;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Nodes.Style;
using System.Drawing;
using GraphVizNet;
using GiGraph.Dot.Types.Nodes;

XmlSerializer serializer = new XmlSerializer(typeof(elements));
using FileStream fileStream = new FileStream("test 2025-07-02 18_26 UTC+2.xml", FileMode.Open);
elements result = (elements?)serializer.Deserialize(fileStream) ?? new();

var factoryNamesById = result
    .Factory
    .Element
    .ToDictionary(f => f.id, f => new Factory(f.id, f.name));

var itemNamesById = result
    .Item
    .Element
    .ToDictionary(f => f.id, f => new Item(f.id, f.name));

var transportNamesById = result
    .FactoryImport
    .Element
    .ToDictionary(f => f.id, f => new Transport(
        f.id,
        f.carries.Item is not null ? itemNamesById[f.carries.Item.id] : new Item("?", "?"),
        f.amountperminute,
        f.method,
        factoryNamesById[f.Shipfrom.Factory.id],
        factoryNamesById[f.providesitemsto.Factory.id]));

Console.WriteLine(result.Factory);



var graph = new DotGraph(directed: true);

foreach(var f in factoryNamesById.Values)
{
    graph.Nodes.Add(f.Id, node =>
    {
        node.Label = f.Name;
        node.Shape = DotNodeShape.Rectangle;
    });
}

foreach (var t in transportNamesById.Values)
{
    graph.Edges.Add(t.From.Id, t.To.Id, edge =>
    {
        edge.Label = $"{t.AmountPerMinute:N0}";
        edge.Style.LineColor = t.Color;
    });
}

var graphViz = new GraphViz();
graphViz.LayoutAndRenderDotGraph(graph.ToDot(), "test.png", "png");

record Factory(string Id, string Name);
record Item(string Id, string Name);
record Transport(string Id, Item Item, decimal AmountPerMinute, string Method, Factory From, Factory To)
{
    public Color Color => Item.Name switch
    {
        "Rubber" => Color.DarkGray,
        _ => Color.Aqua,
    };
};
