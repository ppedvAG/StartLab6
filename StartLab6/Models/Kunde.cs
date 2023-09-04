using System;
using System.Collections.Generic;

namespace StartLab6.Models;

public partial class Kunde
{
    public int KundeId { get; set; }

    public string? Name { get; set; }

    public string? Plz { get; set; }

    public string? Land { get; set; }

    public string? Ort { get; set; }

    public DateTime Datum { get; set; }

    public virtual ICollection<Auftrag> Auftrags { get; set; } = new List<Auftrag>();
}
