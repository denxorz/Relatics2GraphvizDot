using System.Xml.Serialization;

namespace Relatics2GraphvizDot.InputXml;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public partial class elements
{

    private elementsFactory factoryField;

    private elementsFactoryImport factoryImportField;

    private elementsItem itemField;

    /// <remarks/>
    public elementsFactory Factory
    {
        get
        {
            return factoryField;
        }
        set
        {
            factoryField = value;
        }
    }

    /// <remarks/>
    [XmlElement("Factory.Import")]
    public elementsFactoryImport FactoryImport
    {
        get
        {
            return factoryImportField;
        }
        set
        {
            factoryImportField = value;
        }
    }

    /// <remarks/>
    public elementsItem Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactory
{

    private elementsFactoryElement[] elementField;

    private string identifyByField;

    /// <remarks/>
    [XmlElement("Element")]
    public elementsFactoryElement[] Element
    {
        get
        {
            return elementField;
        }
        set
        {
            elementField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string identifyBy
    {
        get
        {
            return identifyByField;
        }
        set
        {
            identifyByField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryElement
{

    private string nameField;

    private string idField;

    /// <remarks/>
    public string name
    {
        get
        {
            return nameField;
        }
        set
        {
            nameField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImport
{

    private elementsFactoryImportElement[] elementField;

    private string identifyByField;

    /// <remarks/>
    [XmlElement("Element")]
    public elementsFactoryImportElement[] Element
    {
        get
        {
            return elementField;
        }
        set
        {
            elementField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string identifyBy
    {
        get
        {
            return identifyByField;
        }
        set
        {
            identifyByField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImportElement
{

    private decimal amountperminuteField;

    private string methodField;

    private elementsFactoryImportElementCarries carriesField;

    private elementsFactoryImportElementProvidesitemsto providesitemstoField;

    private elementsFactoryImportElementShipfrom shipfromField;

    private string idField;

    /// <remarks/>
    [XmlElement("amount per minute")]
    public decimal amountperminute
    {
        get
        {
            return amountperminuteField;
        }
        set
        {
            amountperminuteField = value;
        }
    }

    /// <remarks/>
    public string method
    {
        get
        {
            return methodField;
        }
        set
        {
            methodField = value;
        }
    }

    /// <remarks/>
    public elementsFactoryImportElementCarries carries
    {
        get
        {
            return carriesField;
        }
        set
        {
            carriesField = value;
        }
    }

    /// <remarks/>
    [XmlElement("provides items to")]
    public elementsFactoryImportElementProvidesitemsto providesitemsto
    {
        get
        {
            return providesitemstoField;
        }
        set
        {
            providesitemstoField = value;
        }
    }

    /// <remarks/>
    [XmlElement("Ship from")]
    public elementsFactoryImportElementShipfrom Shipfrom
    {
        get
        {
            return shipfromField;
        }
        set
        {
            shipfromField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImportElementCarries
{

    private elementsFactoryImportElementCarriesItem itemField;

    /// <remarks/>
    public elementsFactoryImportElementCarriesItem Item
    {
        get
        {
            return itemField;
        }
        set
        {
            itemField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImportElementCarriesItem
{

    private string idField;

    /// <remarks/>
    [XmlAttribute()]
    public string id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImportElementProvidesitemsto
{

    private elementsFactoryImportElementProvidesitemstoFactory factoryField;

    /// <remarks/>
    public elementsFactoryImportElementProvidesitemstoFactory Factory
    {
        get
        {
            return factoryField;
        }
        set
        {
            factoryField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImportElementProvidesitemstoFactory
{

    private string idField;

    /// <remarks/>
    [XmlAttribute()]
    public string id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImportElementShipfrom
{

    private elementsFactoryImportElementShipfromFactory factoryField;

    /// <remarks/>
    public elementsFactoryImportElementShipfromFactory Factory
    {
        get
        {
            return factoryField;
        }
        set
        {
            factoryField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsFactoryImportElementShipfromFactory
{

    private string idField;

    /// <remarks/>
    [XmlAttribute()]
    public string id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsItem
{

    private elementsItemElement[] elementField;

    private string identifyByField;

    /// <remarks/>
    [XmlElement("Element")]
    public elementsItemElement[] Element
    {
        get
        {
            return elementField;
        }
        set
        {
            elementField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string identifyBy
    {
        get
        {
            return identifyByField;
        }
        set
        {
            identifyByField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class elementsItemElement
{

    private string nameField;

    private string idField;

    /// <remarks/>
    public string name
    {
        get
        {
            return nameField;
        }
        set
        {
            nameField = value;
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string id
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }
}

