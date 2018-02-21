using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Mouth {
    public float width;
    public float height;

    public void SetValues(Queue<string> queue, object[] values) {
      string first = queue.Dequeue();
      if (first == "width") {
        this.width = (float) values[0];
      } else if (first == "height") {
        this.height = (float) values[0];
      }
    }
  }
}
