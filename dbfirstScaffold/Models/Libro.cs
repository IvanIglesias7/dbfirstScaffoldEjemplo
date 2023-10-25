using System;
using System.Collections.Generic;

namespace dbfirstScaffold.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public long Isbn { get; set; }

    public int Edicion { get; set; }
}
