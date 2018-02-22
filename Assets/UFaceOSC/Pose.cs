using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Pose {
    public Vector2 position;
    public float scale;
    public Vector3 orientation;

    public Pose() {
      this.position = new Vector2();
      this.scale = 0;
      this.orientation = new Vector3();
    }

    public void SetValues(Queue<string> queue, object[] values) {
      string first = queue.Dequeue();
      if (first == "position") {
        this.position = new Vector2((float)values[0], (float)values[1]);
      } else if (first == "scale") {
        this.scale = (float)values[0];
      } else if (first == "orientation") {
        this.orientation = new Vector3((float)values[0], (float)values[1], (float)values[2]);
      }
    }
  }
}
