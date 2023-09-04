using System;
using System.Collections.Generic;

namespace StartLab6.Models;

public partial class Auftrag
{
    public int AuftragId { get; set; }

    public int? KundeId { get; set; }

    public string? Titel { get; set; }

    public double? Preis { get; set; }

    public DateTime Datum { get; set; }

    public virtual Kunde? Kunde { get; set; }
}
