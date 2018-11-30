using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Prototype pattern in which new 
/// Color objects are created by copying pre-existing, user-defined
/// Colors of the same type.
/// </summary>
namespace Prototype.Demonstration
{
    /// <summary>
    /// Prototype Design Pattern.
    /// </summary>
    class Program
    {
        static void Main()
        {
            ColorController colorController = new ColorController();

            // Initialize with standard colors
            colorController["yellow"] = new Color(255, 255, 0);
            colorController["orange"] = new Color(255, 128, 0);
            colorController["purple"] = new Color(128, 0, 255);

            // User adds personlized colors
            colorController["sunny"] = new Color(255, 54, 0);
            colorController["tasty"] = new Color(255, 153, 51);
            colorController["rainy"] = new Color(255, 0, 255);

            // User clones selected colors
            Color c1 = colorController["yellow"].Clone() as Color;
            Color c2 = colorController["tasty"].Clone() as Color;
            Color c3 = colorController["rainy"].Clone() as Color;

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    class Color : ColorPrototype
    {
        private int _yellow;
        private int _orange;
        private int _purple;

        // Constructor
        public Color(int yellow, int orange, int purple)
        {
            this._yellow = yellow;
            this._orange = orange;
            this._purple = purple;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine(
              "RGB color is cloned to: {0,3},{1,3},{2,3}",
              _yellow, _orange, _purple);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    /// <summary>
    /// Prototype manager
    /// </summary>
    class ColorController
    {
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}