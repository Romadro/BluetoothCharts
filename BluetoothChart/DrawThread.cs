
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
using Android.Graphics;

using System.Runtime.CompilerServices;

using Java.Lang;
using Java.Util;

namespace BluetoothChat
{
	class DrawThread : Thread
	{
		private bool runFlag;
		private ISurfaceHolder surfaceHolder;	
		private PointsCloud points;

		private int MarginB = 50;
		private int MarginL = 50;
		private int MarginU = 10;
		private int MarginR = 10;

		public DrawThread(ISurfaceHolder surfaceHolder){
			this.surfaceHolder = surfaceHolder;			
		}

		public void SetRunning(bool run) {
			runFlag = run;
		}

		private int ConvertXtoX(Canvas canvas, DateTime next){
			DateTime MaxX = PointsCloud.MaxX;
			DateTime MinX = PointsCloud.MinX;
			
			double totalMills = (MaxX - MinX).TotalMilliseconds;
			int totalPixsX = (canvas.Width - MarginL - MarginR);

			double a = (next - MinX).TotalMilliseconds;
			double b = a / totalMills;
			double c = b * totalPixsX;
			return (MarginL + Convert.ToInt32 (c));
		}

		private int ConvertYtoY(Canvas canvas, double nextY){
			double MaxY = PointsCloud.MaxY;
			double MinY = PointsCloud.MinY;
			
			double totalDiff = MaxY - MinY;
			int totalPixsY = (canvas.Height - MarginU - MarginB);
			
			double a = (MaxY - nextY);
			double b = a / totalDiff;
			double c = b * totalPixsY;
			return (MarginU + Convert.ToInt32 (c));
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		private void DrawGraphics(Canvas canvas){

			if (!(PointsCloud.x || PointsCloud.y || PointsCloud.z || PointsCloud.v))
				return;

			Paint mPaint = new Paint();
			mPaint.Dither = true;
			mPaint.SetStyle (Paint.Style.Stroke);
			mPaint.Color = Color.White;
			mPaint.StrokeJoin = Paint.Join.Bevel;
			mPaint.StrokeCap = Paint.Cap.Round;
			mPaint.StrokeWidth = 3;

			Path x = new Path ();
			Path y = new Path ();
			Path z = new Path ();
			Path v = new Path ();

			// max min
			DateTime MaxX = PointsCloud.MaxX;
			DateTime MinX = PointsCloud.MinX;
			
			// разметка вертикальные линии
			if (MaxX.Equals (MinX))
				return;


			// 
			List<Point> d = points.GetVisible ();
			for (int i = 0; i<d.Count; i++) {
				Point cur = d.ElementAt(i);
				if (PointsCloud.x) {
					if (i == 0) x.MoveTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.x));
					else        x.LineTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.x));
				}
				if (PointsCloud.y) {
					if (i == 0) y.MoveTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.y));
					else        y.LineTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.y));
				}
				if (PointsCloud.z) {
					if (i == 0) z.MoveTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.z));
					else        z.LineTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.z));
				}
				if (PointsCloud.v) {
					if (i == 0) v.MoveTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.v));
					else        v.LineTo(ConvertXtoX(canvas, cur.GetTime()), 
					                     ConvertYtoY(canvas, cur.v));
				}
			}

			mPaint.Color = Color.Yellow;
			if (PointsCloud.x) canvas.DrawPath (x, mPaint);
			mPaint.Color = Color.Green;
			if (PointsCloud.y) canvas.DrawPath (y, mPaint);
			mPaint.Color = Color.White;
			if (PointsCloud.z) canvas.DrawPath (z, mPaint);
			mPaint.Color = Color.Red;
			if (PointsCloud.v) canvas.DrawPath (v, mPaint);

		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		private void DrawDecart(Canvas canvas){
			canvas.DrawColor (Color.Black);
			Paint mPaint = new Paint();
			mPaint.Dither = true;
			mPaint.SetStyle (Paint.Style.Stroke);
			mPaint.Color = Color.White;
			mPaint.StrokeJoin = Paint.Join.Bevel;
			mPaint.StrokeCap = Paint.Cap.Round;
			mPaint.StrokeWidth = 3;
			Path path = null;
			// оси
			path = new Path ();
			path.MoveTo (MarginL,         MarginU);
			path.LineTo (MarginL,         canvas.Height-MarginB);
			canvas.DrawPath (path, mPaint);
			// max min
			DateTime MaxX = PointsCloud.MaxX;
			DateTime MinX = PointsCloud.MinX;

			// разметка вертикальные линии
			if (MaxX.Equals (MinX))
				return;

			double totalMills = (MaxX - MinX).TotalMilliseconds;
			int totalPixs = (canvas.Width - MarginL - MarginR);
			int delta = Convert.ToInt32(System.Math.Ceiling(1/((totalPixs * 1000 / totalMills) / 96)));

			DateTime next = MinX; 
			next = next.AddMilliseconds (-next.Millisecond);
			next = next.AddSeconds (1);

			mPaint.StrokeWidth = 1;

			while (next.CompareTo(MaxX)<0) {
				double a = (next - MinX).TotalMilliseconds;
				double b = a / totalMills;
				double c = b * totalPixs;
				int pix = Convert.ToInt32 (c);
				mPaint.SetStyle (Paint.Style.Stroke);
				canvas.DrawLine (MarginL + pix, MarginU, MarginL + pix, canvas.Height-MarginB, mPaint);
				mPaint.TextSize = 20;
				mPaint.SetStyle(Paint.Style.Fill);
				canvas.DrawText (next.ToLongTimeString(), 
				                 MarginL + pix , canvas.Height-MarginB + MarginB/2, mPaint );
				next = next.AddSeconds (delta);
			}

			if (!(PointsCloud.x || PointsCloud.y || PointsCloud.z || PointsCloud.v))
				return;

			double MaxY = PointsCloud.MaxY;
			double MinY = PointsCloud.MinY;

			double totalDiff = MaxY - MinY;
			totalPixs = (canvas.Height - MarginU - MarginB);

			delta = Convert.ToInt32(System.Math.Ceiling(1/((totalPixs / totalDiff) / 96)));

			if (totalDiff != 0) {
				double nextY = MaxY;
				nextY = Convert.ToDouble (System.Math.Ceiling (nextY));

				while (nextY>MinY) {
					double a = (MaxY - nextY);
					double b = a / totalDiff;
					double c = b * totalPixs;
					int pix = Convert.ToInt32 (c);
					mPaint.SetStyle (Paint.Style.Stroke);
					canvas.DrawLine (MarginL, MarginU + pix, canvas.Width - MarginR, MarginU + pix, mPaint);
					mPaint.TextSize = 20;
					mPaint.SetStyle(Paint.Style.Fill);
					canvas.DrawText (nextY.ToString(), 
					                 0 , MarginU + pix, mPaint );
					nextY = nextY - delta;
				}
			}
		}

		public override void Run(){
			while (runFlag) {
			}
		}

		public void Redraw(PointsCloud points, int sec)
		{
			if (runFlag) {
				this.points = points;
				points.FindMinMaxLastSec (sec);
				
				Canvas canvas;
				canvas = null;
				try {
					canvas = surfaceHolder.LockCanvas();
					DrawDecart(canvas);
					DrawGraphics(canvas);
				} 
				finally {
					if (canvas != null) {
						// отрисовка выполнена. выводим результат на экран
						surfaceHolder.UnlockCanvasAndPost(canvas);
					}
				}
			}
		}
	}
}

