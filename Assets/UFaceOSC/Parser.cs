using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Parser {
    public int found;
    private Raw raw;
    public Pose pose;
    public Gesture gesture;

    public Parser()
    {
      this.found = 0;
      this.raw  = new Raw();
      this.pose = new Pose();
      this.gesture = new Gesture();
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
      } else if (first == "pose") {
        this.SetPose(queue, values);
      } else if(first == "gesture") {
        this.SetGesture(queue, values);
      }
    }

    private void SetPose(Queue<string> queue, object[] values)
    {
      this.pose.SetValues(queue, values);
    }

    private void SetGesture(Queue<string> queue, object[] values)
    {
      this.gesture.SetValues(queue, values);
    }

    private void SetFound(object[] values)
    {
      this.found = (int)values[0];
    }

    private void SetRaw(object[] values)
    {
      raw.Clear();
      for (int i = 0; i < values.Length / 2; i++)
      {
        this.raw.AddPoint(new Vector2((float) values[i], (float) values[i + 1]));
      }
    }
    
    public Raw GetRaw()
    {
      return this.raw;
    }
  }
}
