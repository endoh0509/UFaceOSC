using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Eye {
    public float left;
    public float right;

    public Eye() {
      this.left = 0;
      this.right = 0;
    }

    public void SetValues(Queue<string> queue, object[] values) {
      string first = queue.Dequeue();
      if (first == "left") {
        this.left = (float) values[0];
      } else if (first == "right") {
        this.right = (float) values[0];
      }
    }
  }
}
