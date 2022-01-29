using UnityEngine;

public class EX_2_1_MyScript : MonoBehaviour {
  public float IntervalMax = 1.0f;
  public float IntervalMin;

  public GameObject TestPosition; // Use sphere to represent a position
  private MyIntervalBoundInY AnInterval;

  // Start is called before the first frame update
  private void Start() {
    AnInterval = new MyIntervalBoundInY();
  }

  // Update is called once per frame
  private void Update() {
    // Updates AnInterval with values entered by the user
    AnInterval.MinValue =
      IntervalMin <= IntervalMax ? IntervalMin : IntervalMax;
    AnInterval.MaxValue = IntervalMax;
    AnInterval.IntervalColor =
      MyDrawObject.NoCollisionColor; // assume point is outside

    // computes inside/outside of the current TestPosition.y value
    var pos = TestPosition.transform.localPosition;
    var isInside = pos.y >= IntervalMin && pos.y <= IntervalMax;


    if (isInside) {
      Debug.Log(
        "Position In Interval! (" + IntervalMin + ", " + IntervalMax + ")"
      );
      AnInterval.IntervalColor = MyDrawObject.CollisionColor;

      // The inside functionality is also supported by MyYInterval
      Debug.Assert(AnInterval.ValueInInterval(pos.y));
    }
  }
}