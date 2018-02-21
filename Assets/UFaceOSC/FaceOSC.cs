using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Parser {
    private Raw raw;
    private Face face;

    public Parser()
    {
      this.raw  = new Raw();
      this.face = new Face();
    }

    public void SetData(string address, object[] values)
    {
      var queue = new Queue<string>();
      foreach(string division in address.Trim('/').Split('/')) {
        queue.Enqueue(division);
      }
      string first = queue.Dequeue();
      if (first == "raw") {
        this.SetRaw(values);
      } else if (first == "found") {
        this.SetFound(values);
      } else if (first == "pose" || first == "gesture") {
        this.SetFace(queue, values);
      }
    }

    private void SetFace(Queue<string> queue, object[] values)
    {
      this.face.SetValues(queue, values);
    }

    private void SetFound(object[] values)
    {
      this.face.SetFound((int) values[0]);
    }

    private void SetRaw(object[] values)
    {
      raw.Clear();
      for (int i = 0; i < values.Length / 2; i++)
      {
        this.raw.AddPoint(new Vector2((float) values[i], (float) values[i + 1]));
      }
    }

    public Face GetFace()
    {
      return this.face;
    }

    public Raw GetRaw()
    {
      return this.raw;
    }
  }
}
