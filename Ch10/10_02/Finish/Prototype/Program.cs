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
            // TODO
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