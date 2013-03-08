
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget; 

namespace BluetoothChat
{
	public class Point{
		public int x;
		public int y;
		public int z;
		public double v;
		DateTime time;
		public Point(int _x, int _y, int _z){
			x = _x; y = _y; z = _z;
			time = DateTime.Now;
			v = Math.Sqrt(Math.Pow(x, 2)+Math.Pow(y, 2)+Math.Pow(z, 2));
		}

		public DateTime GetTime(){
			return time;
		}

		public double GetMax(bool x, bool y, bool z, bool v){
			double max = Double.MinValue;

			if (x && this.x > max)
				max = Convert.ToDouble (this.x);
			if (y && this.y > max)
				max = Convert.ToDouble (this.y);
			if (z && this.z > max)
				max = Convert.ToDouble (this.z);
			if (v && this.v > max)
				max = this.v;

			return max;
		}

		public double GetMin(bool x, bool y, bool z, bool v){
			double min = Double.MaxValue;
			
			if (x && this.x < min)
				min = Convert.ToDouble (this.x);
			if (y && this.y < min)
				min = Convert.ToDouble (this.y);
			if (z && this.z < min)
				min = Convert.ToDouble (this.z);
			if (v && this.v < min)
				min = this.v;

			return min;
		}
	}

	public class PointsCloud
	{
		public static DateTime MinX = DateTime.Now;
		public static DateTime MaxX = DateTime.Now;

		public static double MinY = Double.MinValue;
		public static double MaxY = Double.MinValue;

		public static bool x = true;
		public static bool y = true;
		public static bool z = true;
		public static bool v = true;

		private List<Point> visible;

		List<Point> points;	

		public PointsCloud(){
			points = new List<Point> ();
			visible = new List<Point> ();
		}

		public void AddPoint(Point p){
			points.Add (p);		
		}

		public void FindMinMaxLastSec(int sec){
			int i = points.Count - 1;
			MaxX = points.ElementAt(i).GetTime();
			MaxY = points.ElementAt(i).GetMax(x, y, z, v);
			MinY = points.ElementAt(i).GetMin(x, y, z, v);			 
			visible.RemoveRange(0, visible.Count);
			while ((points.Count>0) && (i>=0) && ((MaxX - points.ElementAt(i).GetTime()).Seconds < sec)) {
				visible.Add(points.ElementAt(i));
				MinX = points.ElementAt(i).GetTime();
				double curMax = points.ElementAt(i).GetMax(x, y, z, v);
				if (curMax > MaxY) MaxY = curMax;
				double curMin = points.ElementAt(i).GetMin(x, y, z, v);
				if (curMin < MinY) MinY = curMin;
				i-- ;		
			}
			if (MaxY - MinY < 8) {
				MaxY = MaxY + (8 - (MaxY - MinY))/2;
				MinY = MinY - (8 - (MaxY - MinY))/2;
			}
		}

		public List<Point> GetVisible(){
			return visible;
		}
	}
}

