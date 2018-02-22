using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Parser {
    public static int POINTS_LENGTH = 66;
    public int found;
    public Pose pose;
    public Gesture gesture;
    public float[] raw;

    public Parser()
    {
      this.found = 0;
      this.raw  = new float[POINTS_LENGTH * 2];
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
      for (int i = 0; i < POINTS_LENGTH * 2; i++)
      {
        this.raw[i] = (float)values[i];
      }
    }

    public Vector2[] GetRawPoints() {
      Vector2[] rawPoints = new Vector2[POINTS_LENGTH];
      for (int i = 0; i < POINTS_LENGTH; i += 2)
      {
        rawPoints[i] = new Vector2(raw[i], raw[i + 1]);
      }
      return rawPoints;
    }
  }
}
