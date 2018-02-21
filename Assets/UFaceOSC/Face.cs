using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Face {
    public int found;
    public Pose pose;
    public Gesture gesture;

    public void SetFound(int found) {
      this.found = found;
    }

    public void SetValues(Queue<string> queue, object[] values) {
      string first = queue.Dequeue();
      if (first == "pose") {
        this.pose.SetValues(queue, values);
      } else if (first == "gesture") {
        this.gesture.SetValues(queue, values);
      }
    }
  }
}
