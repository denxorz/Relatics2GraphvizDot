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

var graph = new DotGraph()
    .WithIdentifier("Satisfactory")
    .WithAttribute("overlap", "false")
    .WithAttribute("splines", "curved")
    .Directed();

foreach (var f in factoryNamesById.Values)
{
    Console.WriteLine($"Factory: {f.Id} {f.Name}");
    var pos = f.Pos;

    var factory = new DotNode()
        .WithIdentifier(f.Id)
        .WithShape(DotNodeShape.Rectangle)
        .WithLabel(f.Name)
        .WithAttribute("pos", $"\"{pos.X},{12 - pos.Y}!\"");

    graph.Add(factory);
}

foreach (var t in transportNamesById.Values)
{
    var transport = new DotEdge()
        .From(t.From.Id)
        .To(t.To.Id)
        .WithLabel($"{t.AmountPerMinute:N0}")
        .WithArrowHead(DotEdgeArrowType.Normal)
        .WithColor(t.Color)
        .WithStyle(t.Style);

    graph.Add(transport);
}

await using var writer = new StringWriter();
await graph.CompileAsync(new CompilationContext(writer, new CompilationOptions()));
var dot = writer.GetStringBuilder().ToString();

await File.WriteAllTextAsync("dot.txt", dot);

var graphViz = new GraphViz();
graphViz.LayoutAndRender(null, dot, "..\\test.png", "neato", "png");

record Factory(string Id, string Name)
{
    public Point Pos => Id switch
    {
        // Left, Top
        "FAC-1" => new(10, 6), // Temple
        "FAC-2" => new(3, 9), // Westcoast Towers
        "FAC-3" => new(6, 2), // Plastic
        "FAC-4" => new(2, 3), // Rocket
        "FAC-5" => new(11, 2), // Ficsonium
        "FAC-6" => new(5, 10), // Portal
        "FAC-7" => new(5, 12), // Booster church
        "FAC-8" => new(12, 3), // Utility Towers
        "FAC-9" => new(12, 8), // Ficsmas
        "FAC-10" => new(10, 8), // Dam
        "FAC-12" => new(8, 11), // Quartz(south)
        "FAC-13" => new(11, 10), // Turbo
        "FAC-14" => new(13, 8), // Virus
        "FAC-15" => new(14, 6), // Coppersheet
        "FAC-16" => new(13, 5), // Recycle
        "FAC-17" => new(14, 5), // Basics
        "FAC-18" => new(15, 5), // Coal power
        "FAC-19" => new(11, 1), // Nuc
        "FAC-20" => new(10, 9), // Fics
        "FAC-21" => new(7, 10), // Quartz(Vista)
        "FAC-22" => new(14, 2), // Heavy Frame (Lost crater)
        "FAC-23" => new(5, 6), // Castle
        "FAC-24" => new(12, 7), // Super computers
        "FAC-25" => new(13, 3), // Egel
        "FAC-26" => new(11, 0), // Fused frames(The North)
        "FAC-27" => new(14, 1), // Quartz(North)
        _ => MissingFactoryId(),
    };

    private Point MissingFactoryId()
    {
        Console.WriteLine($"Missing factory: {Id} {Name}");
        return new(0, 0);
    }
}

record Item(string Id, string Name);

record Transport(string Id, Item Item, decimal AmountPerMinute, string Method, Factory From, Factory To)
{
    public DotColor Color => Item.Name switch
    {
        "Rubber" => DotColor.DarkGray,
        "Plastic" => DotColor.CornflowerBlue,
        "Singularity" => DotColor.SkyBlue,
        "Computer" => DotColor.Darkorange,
        "Nuclear Pasta" => DotColor.Orange,
        "AluCase" => DotColor.Green,
        "AluSheet" => DotColor.GreenYellow,
        "Heavy Frame" => DotColor.PaleGreen,
        "Fused Modular Frame" => DotColor.Orchid,
        "Quartz Crystal" => DotColor.Pink,
        "Fics Ingot" => DotColor.Gold,
        "Reanimated SAM" => DotColor.HotPink,
        "Super Computer" => DotColor.IndianRed,
        _ => MissingItemType(),
    };

    public DotEdgeStyle Style => Method switch
    {
        "Drone" => DotEdgeStyle.Dashed,
        "Belt" => DotEdgeStyle.Bold,
        _ => DotEdgeStyle.Solid,
    };

    private DotColor MissingItemType()
    {
        Console.WriteLine($"Missing item type: {Item.Name}");
        return DotColor.Red;
    }
};
