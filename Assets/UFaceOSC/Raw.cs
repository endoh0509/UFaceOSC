using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Raw {
    public List <Vector2> points;
    public Raw()
    {
      points = new List <Vector2>();
    }

    public Vector2[] GetPoints() {
      return this.points.ToArray();
    }

    public void AddPoint(Vector2 point)
    {
      points.Add(point);
    }

    public void Clear()
    {
      points.Clear();
    }
  }
}
