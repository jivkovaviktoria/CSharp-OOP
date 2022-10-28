﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                    if (value <= 0)
                        throw new ArgumentException($"Length cannot be zero or negative.");
                    this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            { 
                    if (value <= 0)
                        throw new ArgumentException($"Width cannot be zero or negative.");
                    else this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                    if (value <= 0)
                        throw new ArgumentException($"Height cannot be zero or negative.");
                    this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2*this.Width*this.Length + 2*this.Length*this.Height + 2*this.Width*this.Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Width * this.Height * this.Length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
